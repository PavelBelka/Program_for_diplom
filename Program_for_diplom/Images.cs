using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Drawing;

namespace Program_for_diplom
{
    class Images
    {
        /// <summary>
        /// Getting frame from web camera and save in new directony names Step
        /// </summary>
        /// <param name="VideoInputNumber">Number of camera in Direct Show</param>
        /// <param name="Step">Number of measure step</param>
        /// <returns>Mat image</returns>
        public static Mat GetFrame(int VideoInputNumber, int Step)
        {
            var cap = new VideoCapture(VideoInputNumber, VideoCapture.API.DShow);
            cap.SetCaptureProperty(CapProp.FrameWidth, 1920);
            cap.SetCaptureProperty(CapProp.FrameHeight, 1080);
            cap.Start();
            var frame = cap.QueryFrame();
            cap.Stop();
            if (!Directory.Exists(Step.ToString()))
            {
                Directory.CreateDirectory(Step.ToString());
            }
            CvInvoke.Imwrite($"{Step}\\source.jpg", frame);
            return frame.Clone();
        }

        /// <summary>
        /// Method for analysis image, calc width and height of flame tongue, their area and 
        /// </summary>
        /// <param name="Image">input Mat image</param>
        /// <param name="Step">step of measure</param>
        /// <param name="Scale">Scale of projection (mm in px)</param>
        /// <returns>ImageProcessingResult instance, includes width, height, area and image with contour</returns>
        public static ImageProcessingResult FrameAnalysis(Mat Image, int Step, double Scale)
        {
            var source = Image.Clone();
            var blur = new Mat(Image.Rows, Image.Cols, DepthType.Cv64F, 3);
            var gray = blur.Clone();
            var thresh = blur.Clone();
            var contours = new VectorOfVectorOfPoint();

            CvInvoke.MedianBlur(source, blur, 1);
            CvInvoke.CvtColor(blur, gray, ColorConversion.Bgr2Gray);
            CvInvoke.Threshold(gray, thresh, 150, 255, ThresholdType.BinaryInv);

            CvInvoke.FindContours(thresh, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            ImageProcessingResult result = CalcResult(contours, source);
            SaveImages(Step, blur, gray, thresh, result.Image);
            result.Area *= Scale * Scale;
            result.Width *= Scale;
            result.Height *= Scale;
            return result;
        }

        /// <summary>
        /// Method for save images
        /// </summary>
        /// <param name="step">step of measure (for path)</param>
        /// <param name="blur">blur img</param>
        /// <param name="gray">img in grayscale</param>
        /// <param name="thresh">thresholding image</param>
        private static void SaveImages(int step, Mat blur, Mat gray, Mat thresh, Mat result)
        {
            if (!Directory.Exists(step.ToString()))
            {
                Directory.CreateDirectory(step.ToString());
            }
            CvInvoke.Imwrite($"{step}\\blur.jpg", blur);
            CvInvoke.Imwrite($"{step}\\gray.jpg", gray);
            CvInvoke.Imwrite($"{step}\\thresh.jpg", thresh);
            CvInvoke.Imwrite($"{step}\\result.jpg", result);
        }

        /// <summary>
        /// Calc width, height, area and draw contour and border dots
        /// </summary>
        /// <param name="contours">Founded contrours from source image</param>
        /// <param name="source">Source image for drawing contour and dots</param>
        /// <returns></returns>
        private static ImageProcessingResult CalcResult(VectorOfVectorOfPoint contours, Mat source)
        {
            var result = new ImageProcessingResult();
            var maxContArea = 0.0;
            int maxContAreaID = 0;
            for (int i = 0; i < contours.Size; i++)
            {
                double contArea = CvInvoke.ContourArea(contours[i]);
                if (contArea >= maxContArea)
                {
                    maxContArea = contArea;
                    maxContAreaID = i;
                }
            }

            var biggestCont = contours[maxContAreaID];
            result.Contour = biggestCont;
            result.Area = maxContArea;

            List<double> xCoords = new List<double>();
            List<double> yCoords = new List<double>();

            for (int i = 0; i < biggestCont.Size; i++)
            {
                xCoords.Add(biggestCont[i].X);
                yCoords.Add(biggestCont[i].Y);
            }

            double minX = xCoords[0], maxX = xCoords[0];
            double minY = yCoords[0], maxY = yCoords[0];
            Point pLeft = new Point();
            Point pRight = new Point();
            Point pUp = new Point();
            Point pDown = new Point();

            for (int i = 0; i < xCoords.Count; i++)
            {
                if (xCoords[i] >= maxX)
                {
                    maxX = xCoords[i];
                    pLeft.X = (int)maxX;
                    pLeft.Y = (int)yCoords[i];
                }
                if (xCoords[i] <= minX)
                {
                    minX = xCoords[i];
                    pRight.X = (int)minX;
                    pRight.Y = (int)yCoords[i];
                }
                if (yCoords[i] >= maxY)
                {
                    maxY = yCoords[i];
                    pUp.Y = (int)maxY;
                    pUp.X = (int)xCoords[i];
                }
                if (yCoords[i] <= minY)
                {
                    minY = yCoords[i];
                    pDown.Y = (int)minY;
                    pDown.X = (int)xCoords[i];
                }
            }
            result.Width = pLeft.X - pRight.X;
            result.Height = pUp.Y - pDown.Y;
            CvInvoke.DrawContours(source, contours, maxContAreaID, new MCvScalar(255, 0, 0), 3, LineType.AntiAlias);
            var borderColor = new MCvScalar(255, 0, 255);
            CvInvoke.Circle(source, pLeft, 3, borderColor, 3, LineType.AntiAlias);
            CvInvoke.Circle(source, pRight, 3, borderColor, 3, LineType.AntiAlias);
            CvInvoke.Circle(source, pUp, 3, borderColor, 3, LineType.AntiAlias);
            CvInvoke.Circle(source, pDown, 3, borderColor, 3, LineType.AntiAlias);
            result.Image = source.Clone();
            return result;
        }

        /// <summary>
        /// Resize source image
        /// </summary>
        /// <param name="img">Source image</param>
        /// <param name="width">Widht dest image</param>
        /// <param name="height">Heihgt dest image</param>
        /// <returns></returns>
        public static Mat ResizeImage(Mat img, int width, int height)
        {
            CvInvoke.Resize(img.Clone(), img, new Size(width, height), 0, 0, Inter.Cubic);
            return img.Clone();
        }
    }

    public class ImageProcessingResult
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area { get; set; }
        public Mat Image { get; set; }
        public VectorOfPoint Contour { get; set; }
    }
}
