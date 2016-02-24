using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace commonFunc._gdi
{
    /// <summary>
    /// 制作图片水印操作
    /// </summary>
    class HoverWarter
    {
        public void TestTextToImage()
        {
            Image image = Image.FromFile("C:\\test.png");
            Image mg = AddTextToImage(image, "test message");
            mg.Save("C:\\001.jpg");
        }

        public static Image AddTextToImage(Image image, string text)
        {
            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
            Graphics g = Graphics.FromImage(bitmap);

            float fontSize = 12.0f;
            float textWidth = text.Length * fontSize;

            float rectX = 0;
            float rectY = 0;
            float rectWidth = text.Length * (fontSize) - fontSize;
            float rectHeight = fontSize + 8;

            RectangleF textArea = new RectangleF(new PointF(rectX, rectY),
                new SizeF(rectWidth, rectHeight));
            Font font = new Font("宋体", fontSize);

            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(Color.Black);
            g.FillRectangle(blackBrush, textArea);
            // g.DrawString(text, font, whiteBrush, textArea);
            g.DrawImage(image, textArea);
            g.DrawString(text, font, whiteBrush, textArea);

            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            // bitmap.Save("C:\01.jpeg");

            Image h_hoverImage = Image.FromStream(ms);
            g.Dispose();
            bitmap.Dispose();
            return h_hoverImage;
        }
    }
}
