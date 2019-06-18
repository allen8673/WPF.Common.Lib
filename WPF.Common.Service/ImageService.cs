using Svg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using WPF.Common.Service.Extends;
using System.ComponentModel;

namespace WPF.Common.Service
{
    public class ImageService
    {
        public static ImageSource GetSVGBitmap(string filePath, int width, int height)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            SvgDocument svgDoc = SvgDocument.Open(doc);
            svgDoc.Height = height;
            svgDoc.Width = width;
            Bitmap bmp = svgDoc.Draw();
            return BitmapToImageSource(bmp);
        }

        public static ImageSource GetSVGBitmap(string filePath)
        {
            if (!File.Exists(filePath))
                return null;
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            SvgDocument svgDoc = SvgDocument.Open(doc);
            using (Bitmap bmp = svgDoc.Draw())
            {
                return BitmapToImageSource(bmp);
            }
        }
        public static void DisposeImage(System.Drawing.Image image)
        {
            try
            {
                if (image != null)
                {
                    image.Dispose();
                    image = null;
                }
            }
            catch (Exception ex)
            {
                //Log.WriteLine(ex);
            }

        }

        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png); // Was .Bmp, but this did not show a transparent background.

                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                // According to MSDN, "The default OnDemand cache option retains access to the stream until the image is needed."
                // Force the bitmap to load right now so we can dispose the stream.
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }
    }
}
