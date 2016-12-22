using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.GPU;
using System.Diagnostics;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;

namespace Webcam_cs
{
    class DIP
    {
        private static MotionHistory _motionHistory;
        private static IBGFGDetector<Bgr> _forgroundDetector;

        public static void initial()
        {
            _motionHistory = new MotionHistory(
                    1.0, //in second, the duration of motion history you wants to keep
                    0.05, //in second, parameter for cvCalcMotionGradient
                    0.5); //in second, parameter for cvCalcMotionGradient   
        }

        public static Image<Bgr, Byte> FaceDetection(Image<Bgr, Byte> image)
        {
            //Image<Bgr, Byte> image = new Image<Bgr, byte>("lena.jpg"); //Read the files as an 8-bit Bgr image  

            Stopwatch watch;
            String faceFileName = "haarcascade_frontalface_default.xml";
            String eyeFileName = "haarcascade_eye.xml";

            if (GpuInvoke.HasCuda)
            {
                using (GpuCascadeClassifier face = new GpuCascadeClassifier(faceFileName))
                using (GpuCascadeClassifier eye = new GpuCascadeClassifier(eyeFileName))
                {
                    watch = Stopwatch.StartNew();
                    using (GpuImage<Bgr, Byte> gpuImage = new GpuImage<Bgr, byte>(image))
                    using (GpuImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
                    {
                        Rectangle[] faceRegion = face.DetectMultiScale(gpuGray, 1.1, 10, Size.Empty);
                        foreach (Rectangle f in faceRegion)
                        {
                            //draw the face detected in the 0th (gray) channel with blue color
                            image.Draw(f, new Bgr(Color.Blue), 2);
                            using (GpuImage<Gray, Byte> faceImg = gpuGray.GetSubRect(f))
                            {
                                //For some reason a clone is required.
                                //Might be a bug of GpuCascadeClassifier in opencv
                                using (GpuImage<Gray, Byte> clone = faceImg.Clone())
                                {
                                    Rectangle[] eyeRegion = eye.DetectMultiScale(clone, 1.1, 10, Size.Empty);

                                    foreach (Rectangle e in eyeRegion)
                                    {
                                        Rectangle eyeRect = e;
                                        eyeRect.Offset(f.X, f.Y);
                                        image.Draw(eyeRect, new Bgr(Color.Red), 2);
                                    }
                                }
                            }
                        }
                    }
                    watch.Stop();
                }
            }
            else
            {
                //Read the HaarCascade objects
                using (HaarCascade face = new HaarCascade(faceFileName))
                using (HaarCascade eye = new HaarCascade(eyeFileName))
                {
                    watch = Stopwatch.StartNew();
                    using (Image<Gray, Byte> gray = image.Convert<Gray, Byte>()) //Convert it to Grayscale
                    {
                        //normalizes brightness and increases contrast of the image
                        gray._EqualizeHist();

                        //Detect the faces  from the gray scale image and store the locations as rectangle
                        //The first dimensional is the channel
                        //The second dimension is the index of the rectangle in the specific channel
                        MCvAvgComp[] facesDetected = face.Detect(
                           gray,
                           1.1,
                           10,
                           Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                           new Size(20, 20));

                        foreach (MCvAvgComp f in facesDetected)
                        {
                            //draw the face detected in the 0th (gray) channel with blue color
                            image.Draw(f.rect, new Bgr(Color.Blue), 2);

                            //Set the region of interest on the faces
                            gray.ROI = f.rect;
                            MCvAvgComp[] eyesDetected = eye.Detect(
                               gray,
                               1.1,
                               10,
                               Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                               new Size(20, 20));
                            gray.ROI = Rectangle.Empty;

                            foreach (MCvAvgComp e in eyesDetected)
                            {
                                Rectangle eyeRect = e.rect;
                                eyeRect.Offset(f.rect.X, f.rect.Y);
                                image.Draw(eyeRect, new Bgr(Color.Red), 2);
                            }
                        }
                    }
                    watch.Stop();
                }
            }


            return image;
            //display the image 
            //ImageViewer.Show(image, String.Format(
            //   "Completed face and eye detection using {0} in {1} milliseconds",
            //   GpuInvoke.HasCuda ? "GPU" : "CPU",
            //   watch.ElapsedMilliseconds));
        }

        public static Image<Gray, Byte> CannyEdge(Image<Bgr, Byte> img)
        {

            //Get and sharpen gray image (don't remember where I found this code; prob here on SO)
            Image<Gray, Byte> graySoft = img.Convert<Gray, Byte>().PyrDown().PyrUp();
            Image<Gray, Byte> gray = graySoft.SmoothGaussian(3);
            gray = gray.AddWeighted(graySoft, 1.5, -0.5, 0);

            Image<Gray, Byte> bin = gray.ThresholdBinary(new Gray(149), new Gray(255));

            Gray cannyThreshold = new Gray(149);
            Gray cannyThresholdLinking = new Gray(149);
            Gray circleAccumulatorThreshold = new Gray(1000);

            Image<Gray, Byte> cannyEdges = bin.Canny(cannyThreshold, cannyThresholdLinking);


            ////Circles
            //CircleF[] circles = cannyEdges.HoughCircles(
            //    cannyThreshold,
            //    circleAccumulatorThreshold,
            //    4.0, //Resolution of the accumulator used to detect centers of the circles
            //    15.0, //min distance 
            //    5, //min radius
            //    0 //max radius
            //    )[0]; //Get the circles from the first channel

            ////draw circles (on original image)
            //foreach (CircleF circle in circles)
            //    img.Draw(circle, new Bgr(Color.Brown), 2);
            return cannyEdges;

        }

        public static Image<Bgr, Byte> MotionDetection(Image<Bgr, Byte> image)
        {

            using (MemStorage storage = new MemStorage()) //create storage for motion components
            {
                if (_forgroundDetector == null)
                {
                    //_forgroundDetector = new BGCodeBookModel<Bgr>();
                    //_forgroundDetector = new FGDetector<Bgr>(Emgu.CV.CvEnum.FORGROUND_DETECTOR_TYPE.FGD);
                    _forgroundDetector = new BGStatModel<Bgr>(image, Emgu.CV.CvEnum.BG_STAT_TYPE.FGD_STAT_MODEL);
                }

                _forgroundDetector.Update(image);

                //capturedImageBox.Image = image;

                //update the motion history
                _motionHistory.Update(_forgroundDetector.ForgroundMask);

                #region get a copy of the motion mask and enhance its color
                double[] minValues, maxValues;
                Point[] minLoc, maxLoc;
                _motionHistory.Mask.MinMax(out minValues, out maxValues, out minLoc, out maxLoc);
                Image<Gray, Byte> motionMask = _motionHistory.Mask.Mul(255.0 / maxValues[0]);
                #endregion

                //create the motion image 
                Image<Bgr, Byte> motionImage = new Image<Bgr, byte>(motionMask.Size);
                //display the motion pixels in blue (first channel)
                motionImage[0] = motionMask;

                //Threshold to define a motion area, reduce the value to detect smaller motion
                double minArea = 100;

                storage.Clear(); //clear the storage
                Seq<MCvConnectedComp> motionComponents = _motionHistory.GetMotionComponents(storage);

                //iterate through each of the motion component
                foreach (MCvConnectedComp comp in motionComponents)
                {
                    //reject the components that have small area;
                    if (comp.area < minArea) continue;

                    // find the angle and motion pixel count of the specific area
                    double angle, motionPixelCount;
                    _motionHistory.MotionInfo(comp.rect, out angle, out motionPixelCount);

                    //reject the area that contains too few motion
                    if (motionPixelCount < comp.area * 0.05) continue;

                    //Draw each individual motion in red
                    DrawMotion(motionImage, comp.rect, angle, new Bgr(Color.Red));
                }

                // find and draw the overall motion angle
                double overallAngle, overallMotionPixelCount;
                _motionHistory.MotionInfo(motionMask.ROI, out overallAngle, out overallMotionPixelCount);
                DrawMotion(motionImage, motionMask.ROI, overallAngle, new Bgr(Color.Green));

                //Display the amount of motions found on the current image
                //UpdateText(String.Format("Total Motions found: {0}; Motion Pixel count: {1}", motionComponents.Total, overallMotionPixelCount));

                //Display the image of the motion
                //motionImageBox.Image = motionImage;

                return motionImage;
            }
        }
        private static void DrawMotion(Image<Bgr, Byte> image, Rectangle motionRegion, double angle, Bgr color)
        {
            float circleRadius = (motionRegion.Width + motionRegion.Height) >> 2;
            Point center = new Point(motionRegion.X + motionRegion.Width >> 1, motionRegion.Y + motionRegion.Height >> 1);

            CircleF circle = new CircleF(
               center,
               circleRadius);

            int xDirection = (int)(Math.Cos(angle * (Math.PI / 180.0)) * circleRadius);
            int yDirection = (int)(Math.Sin(angle * (Math.PI / 180.0)) * circleRadius);
            Point pointOnCircle = new Point(
                center.X + xDirection,
                center.Y - yDirection);
            LineSegment2D line = new LineSegment2D(center, pointOnCircle);

            image.Draw(circle, color, 1);
            image.Draw(line, color, 2);
        }

        public static Image<Bgr, Byte> SharpDetect(Image<Bgr, Byte> img)
        {
            //Convert the image to grayscale and filter out the noise
            Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();

            Gray cannyThreshold = new Gray(180);
            Gray cannyThresholdLinking = new Gray(120);
            Gray circleAccumulatorThreshold = new Gray(120);

            CircleF[] circles = gray.HoughCircles(
                cannyThreshold,
                circleAccumulatorThreshold,
                5.0, //Resolution of the accumulator used to detect centers of the circles
                10.0, //min distance 
                5, //min radius
                0 //max radius
                )[0]; //Get the circles from the first channel

            Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
            LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                1, //Distance resolution in pixel-related units
                Math.PI / 45.0, //Angle resolution measured in radians.
                20, //threshold
                30, //min Line width
                10 //gap between lines
                )[0]; //Get the lines from the first channel

            #region Find triangles and rectangles
            List<Triangle2DF> triangleList = new List<Triangle2DF>();
            List<MCvBox2D> boxList = new List<MCvBox2D>();

            using (MemStorage storage = new MemStorage()) //allocate storage for contour approximation
                for (Contour<Point> contours = cannyEdges.FindContours(); contours != null; contours = contours.HNext)
                {
                    Contour<Point> currentContour = contours.ApproxPoly(contours.Perimeter * 0.05, storage);

                    if (contours.Area > 250) //only consider contours with area greater than 250
                    {
                        if (currentContour.Total == 3) //The contour has 3 vertices, it is a triangle
                        {
                            Point[] pts = currentContour.ToArray();
                            triangleList.Add(new Triangle2DF(
                               pts[0],
                               pts[1],
                               pts[2]
                               ));
                        }
                        else if (currentContour.Total == 4) //The contour has 4 vertices.
                        {
                            #region determine if all the angles in the contour are within the range of [80, 100] degree
                            bool isRectangle = true;
                            Point[] pts = currentContour.ToArray();
                            LineSegment2D[] edges = PointCollection.PolyLine(pts, true);

                            for (int i = 0; i < edges.Length; i++)
                            {
                                double angle = Math.Abs(
                                   edges[(i + 1) % edges.Length].GetExteriorAngleDegree(edges[i]));
                                if (angle < 80 || angle > 100)
                                {
                                    isRectangle = false;
                                    break;
                                }
                            }
                            #endregion

                            if (isRectangle) boxList.Add(currentContour.GetMinAreaRect());
                        }
                    }
                }
            #endregion

            //originalImageBox.Image = img;

            #region draw triangles and rectangles
            Image<Bgr, Byte> triangleRectangleImage = img.CopyBlank();
            foreach (Triangle2DF triangle in triangleList)
                triangleRectangleImage.Draw(triangle, new Bgr(Color.DarkBlue), 2);
            foreach (MCvBox2D box in boxList)
                triangleRectangleImage.Draw(box, new Bgr(Color.DarkOrange), 2);
            //triangleRectangleImageBox.Image = triangleRectangleImage;
            #endregion

            #region draw circles
            Image<Bgr, Byte> circleImage = img.CopyBlank();
            foreach (CircleF circle in circles)
                circleImage.Draw(circle, new Bgr(Color.Brown), 2);
            //circleImageBox.Image = circleImage;
            #endregion

            #region draw lines
            Image<Bgr, Byte> lineImage = img.CopyBlank();
            foreach (LineSegment2D line in lines)
                lineImage.Draw(line, new Bgr(Color.Green), 2);
            //lineImageBox.Image = lineImage;
            #endregion

            return lineImage;
        }

    }
}
