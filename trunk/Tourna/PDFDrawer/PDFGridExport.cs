using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;

namespace PDFDrawer
{
    public class PDFGridExport 
    {
        private PdfDocument s_document;
        public PDFGridExport()
        {
            string filename = String.Format("{0}_tempfile.pdf", Guid.NewGuid().ToString("D").ToUpper());
            s_document = new PdfDocument();
            s_document.Info.Title = "Tournament Test";
            s_document.Info.Author = "Stanley";
            s_document.Info.Subject = "Poop";
            s_document.Info.Keywords = "PDFsharp, XGraphics";

            // Create demonstration pages
            PdfPage page = s_document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);
            Base dra = new Base();
            dra.DrawTourney(page, gfx);

            // Save the s_document...
            s_document.Save(filename);
            // ...and start a viewer
            Process.Start(filename);
        }

        public class Base
        {
            protected XColor backColor;
            protected XColor backColor2;
            protected XColor shadowColor;
            protected double borderWidth;
            protected XPen borderPen;

            public Base()
            {
                this.backColor = XColors.Ivory;
                this.backColor2 = XColors.WhiteSmoke;

                this.backColor = XColor.FromArgb(212, 224, 240);
                this.backColor2 = XColor.FromArgb(253, 254, 254);

                this.shadowColor = XColors.Gainsboro;
                this.borderWidth = 4.5;
                this.borderPen = new XPen(XColor.FromArgb(94, 118, 151), this.borderWidth);//new XPen(XColors.SteelBlue, this.borderWidth);
            }

          
            public void DrawTourney(PdfPage page, XGraphics gfx)
            {
                BeginBox(gfx, 1, "Tournament");
       
                DrawBackets(gfx, 4, 15, 10, 10);
                DrawBackets(gfx, 2, 30, 40, 15);
                DrawBackets(gfx, 1, 60, 70, 25);
            }

            private void DrawBackets(XGraphics gfx, int bracketNum, int pheight, int startX, int startY)
            {
                int width = 30;
                int height = pheight;
                //int form = distanceBetween 
                int X = startX;
                int Y = startY;
                for (int i = 0; i < bracketNum; i++)
                {
                    gfx.DrawLines(XPens.Black, new[] { 
                new XPoint(X, Y), 
                new XPoint(X+width, Y), 
                new XPoint(X+width, Y + height), 
                new XPoint(X, Y + height) });

                    //add y to skip one
                    Y = (Y + height) + height;
                }
            }

            /// <summary>
            /// Draws a sample box.
            /// </summary>
            public void BeginBox(XGraphics gfx, int number, string title)
            {
                const int dEllipse = 15;
                XRect rect = new XRect(0, 20, 300, 200);
                if (number % 2 == 0)
                    rect.X = 300 - 5;
                rect.Y = 40 + ((number - 1) / 2) * (200 - 5);
                rect.Inflate(-10, -10);
                XRect rect2 = rect;
                rect2.Offset(this.borderWidth, this.borderWidth);
                gfx.DrawRoundedRectangle(new XSolidBrush(this.shadowColor), rect2, new XSize(dEllipse + 8, dEllipse + 8));
                XLinearGradientBrush brush = new XLinearGradientBrush(rect, this.backColor, this.backColor2, XLinearGradientMode.Vertical);
                gfx.DrawRoundedRectangle(this.borderPen, brush, rect, new XSize(dEllipse, dEllipse));
                rect.Inflate(-5, -5);

                XFont font = new XFont("Verdana", 12, XFontStyle.Regular);
                gfx.DrawString(title, font, XBrushes.Navy, rect, XStringFormats.TopCenter);

                rect.Inflate(-10, -5);
                rect.Y += 20;
                rect.Height -= 20;
                //gfx.DrawRectangle(XPens.Red, rect);

                this.state = gfx.Save();
                gfx.TranslateTransform(rect.X, rect.Y);
            }

            public void EndBox(XGraphics gfx)
            {
                gfx.Restore(this.state);
            }

            /// <summary>
            /// Gets a five-pointed star with the specified size and center.
            /// </summary>
            protected static XPoint[] GetPentagram(double size, XPoint center)
            {
                XPoint[] points = Pentagram.Clone() as XPoint[];
                for (int idx = 0; idx < 5; idx++)
                {
                    points[idx].X = points[idx].X * size + center.X;
                    points[idx].Y = points[idx].Y * size + center.Y;
                }
                return points;
            }

            /// <summary>
            /// Gets a normalized five-pointed star.
            /// </summary>
            static XPoint[] Pentagram
            {
                get
                {
                    if (pentagram == null)
                    {
                        int[] order = new int[] { 0, 3, 1, 4, 2 };
                        pentagram = new XPoint[5];
                        for (int idx = 0; idx < 5; idx++)
                        {
                            double rad = order[idx] * 2 * Math.PI / 5 - Math.PI / 10;
                            pentagram[idx].X = Math.Cos(rad);
                            pentagram[idx].Y = Math.Sin(rad);
                        }
                    }
                    return pentagram;
                }
            }
            static XPoint[] pentagram;

            XGraphicsState state;
        }

    }
}
