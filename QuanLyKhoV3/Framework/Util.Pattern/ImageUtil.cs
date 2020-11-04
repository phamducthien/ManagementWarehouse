using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;

namespace Util.Pattern
{
    public class ImageUtil
    {
        private static Dictionary<string, ImageCodecInfo> _encoders;

        public static Dictionary<string, ImageCodecInfo> Encoders
        {
            get
            {
                if (_encoders == null) _encoders = new Dictionary<string, ImageCodecInfo>();
                if (_encoders.Count == 0)
                {
                    var imageEncoders = ImageCodecInfo.GetImageEncoders();
                    foreach (var imageCodecInfo in imageEncoders)
                        _encoders.Add(imageCodecInfo.MimeType.ToLower(), imageCodecInfo);
                }

                return _encoders;
            }
        }
        //public static byte[] GetBytesFromImage(System.Drawing.Image img)
        //{
        //    if (img == null)
        //        return null;
        //    try
        //    {
        //        MemoryStream ms = new MemoryStream();
        //        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        return ms.ToArray();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public static System.Drawing.Image GetImageFromBytes(byte[] b)
        //{
        //    if (b == null)
        //        return null;
        //    try
        //    {
        //        MemoryStream ms = new MemoryStream(b);
        //        System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
        //        return returnImage;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        ///     Load hình dựa vào ImagePath = "D:\image.jpg"
        ///     Load không được return null
        /// </summary>
        public static Image LoadImage(string imagePath)
        {
            try
            {
                return Image.FromFile(imagePath);
            }
            catch
            {
                return null;
            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var stream = new MemoryStream(byteArrayIn);
            return Image.FromStream(stream);
        }

        public static byte[] ImageToByte(Image img)
        {
            var memoryStream = new MemoryStream();
            img.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        public static byte[] ImageToByte(Bitmap img)
        {
            var memoryStream = new MemoryStream();
            img.Save(memoryStream, ImageFormat.Jpeg);
            return memoryStream.ToArray();
        }

        public static bool ReadFile(string fileName, out byte[] picture)
        {
            bool result;
            if (!File.Exists(fileName))
            {
                picture = null;
                result = false;
            }
            else
            {
                try
                {
                    var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    var array = new byte[fileStream.Length];
                    fileStream.Read(array, 0, int.Parse(fileStream.Length.ToString(CultureInfo.InvariantCulture)));
                    fileStream.Close();
                    picture = array;
                    result = true;
                }
                catch (Exception)
                {
                    picture = null;
                    result = false;
                }
            }

            return result;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var bitmap = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
            }

            return bitmap;
        }

        public static void SaveJpeg(string path, Image image, int quality)
        {
            if (quality < 0 || quality > 100)
            {
                var paramName =
                    string.Format(
                        "Jpeg image quality must be between 0 and 100, with 100 being the highest quality.  A value of {0} was specified.",
                        quality);
                throw new ArgumentOutOfRangeException(paramName);
            }

            var encoderParameter = new EncoderParameter(Encoder.Quality, quality);
            var encoderInfo = GetEncoderInfo("image/jpeg");
            var encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = encoderParameter;
            image.Save(path, encoderInfo, encoderParameters);
        }

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            var key = mimeType.ToLower();
            ImageCodecInfo result = null;
            if (Encoders.ContainsKey(key)) result = Encoders[key];
            return result;
        }
    }
}