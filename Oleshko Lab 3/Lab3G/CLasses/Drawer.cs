using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3G.CLasses
{
    public static class Drawer
    {
        public static double xMin = 1;
        public static double xMax = 4;
        private static double yMin = -5;
        private static double yMax = 5;
        private static int i1, i2, j1, j2;
        private static Graphics gr;
        private static int xtoi(double x)
        {
            int ii;
            ii = i1 + (int)Math.Truncate((x - xMin) * ((i2 - i1) / (xMax - xMin)));
            return ii;
        }
        private static int ytoj(double y)
        {
            int jj;
            jj = j2 + (int)Math.Truncate((y - yMin) * (j1 - j2) / (yMax - yMin));
            return jj;
        }
        public static void DrawCoordinateSystem()
        {
            Pen pen_net = new Pen(Brushes.Gray, 2);
            pen_net.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            for (int p = (int)xMin; p <= (int)xMax; p++)
            {
                gr.DrawLine(pen_net, xtoi(p), ytoj(yMax), xtoi(p), ytoj(yMin));
            }
            for (int p = (int)yMin; p < (int)yMax; p++)
            {
                gr.DrawLine(pen_net, xtoi(xMin), ytoj(p), xtoi(xMax), ytoj(p));
            }
            Pen pen_os = new Pen(Brushes.Black, 2);
            pen_os.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen_os.StartCap = System.Drawing.Drawing2D.LineCap.Triangle;

            gr.DrawLine(pen_os, xtoi(xMin), ytoj(0), xtoi(xMax), ytoj(0));
            gr.DrawLine(pen_os, xtoi(0), ytoj(yMin), xtoi(0), ytoj(yMax));

            Font MyFont = new Font("Arial", 8, FontStyle.Regular);
            for (int p = 1; p <= xMax; p++)
                gr.DrawString(Convert.ToString(p), MyFont, Brushes.Black, new Point(xtoi(p - 0.2), ytoj(-0.05)));
            for (int p = -1; p >= xMin; p--)
                gr.DrawString(Convert.ToString(p), MyFont, Brushes.Black, new Point(xtoi(p - 0.2), ytoj(-0.06)));
            for (int p = 1; p <= yMax; p++)
                gr.DrawString(Convert.ToString(p), MyFont, Brushes.Black, new Point(xtoi(-0.5), ytoj(p + 0.1)));
            for (int p = -1; p >= yMin; p--)
                gr.DrawString(Convert.ToString(p), MyFont, Brushes.Black, new Point(xtoi(-0.5), ytoj(p + 0.1)));
        }
        public static void DrawPoint(double x, double y, Brush? brush = null)
        {
            Brush blackBrush = new SolidBrush(Color.Black);
            if (brush != null)
            {
                blackBrush = brush;
            }
            if (y >= yMin && y <= yMax)
            {
                gr.FillRectangle(blackBrush, xtoi(x), ytoj(y), 2, 2);
            }
        }
        public static void DrawPointBig(double x, double y, Brush? brush = null)
        {
            Brush blackBrush = new SolidBrush(Color.Black);
            if (brush != null)
            {
                blackBrush = brush;
            }
            gr.FillRectangle(blackBrush, xtoi(x), ytoj(y), 5, 5);
        }
        public static void DrawPointMed(double x, double y, Brush? brush = null)
        {
            Brush blackBrush = new SolidBrush(Color.Black);
            if (brush != null)
            {
                blackBrush = brush;
            }
            gr.FillRectangle(blackBrush, xtoi(x), ytoj(y), 3, 3);
        }

        public static void DrawFunction()
        {
            Function.a = xMin;
            Function.b = xMax;
            for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var pointY = Function.Evaluate(pointX);
                DrawPointBig(pointX, pointY);
            }
            for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var newtonY = Function.NewtonEquidistant(pointX);
                Brush brush = new SolidBrush(Color.Red);
                DrawPoint(pointX, newtonY, brush);
            }
            for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var newtonY = Function.NewtonChebysh(pointX);
                Brush brush = new SolidBrush(Color.LightGreen);
                DrawPoint(pointX, newtonY, brush);
            }
            /*for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var newtonY = Function.Evaluate(pointX) - Function.NewtonEquidistant(pointX);
                Brush brush = new SolidBrush(Color.Blue);
                DrawPoint(pointX, newtonY, brush);
            }
            for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var newtonY = Function.Evaluate(pointX) - Function.NewtonChebysh(pointX);
                Brush brush = new SolidBrush(Color.Purple);
                DrawPoint(pointX, newtonY, brush);
            }*/
            /*for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var pointY = Function.Spline(pointX);
                Brush brush = new SolidBrush(Color.Yellow);
                DrawPoint(pointX, pointY, brush);
            }*/
            /*for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var pointY = Function.Evaluate(pointX) - Function.Spline(pointX);
                Brush brush = new SolidBrush(Color.Brown);
                DrawPoint(pointX, pointY, brush);
            }*/
            /*for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var pointY = Function.Spline2(pointX);
                Brush brush = new SolidBrush(Color.Yellow);
                DrawPoint(pointX, pointY, brush);
            }*/
            /*for (double pointX = xMin; pointX <= xMax; pointX += 0.001)
            {
                var pointY = Function.Evaluate(pointX) - Function.Spline2(pointX);
                Brush brush = new SolidBrush(Color.Brown);
                DrawPoint(pointX, pointY, brush);
            }*/
        }
        public static void CreateGraphics(PictureBox pictureBox)
        {
            gr = pictureBox.CreateGraphics();
            gr.Clear(Color.White);
            i1 = 0;
            j1 = 0;
            i2 = pictureBox.Width - 1;
            j2 = pictureBox.Height - 1;
        }
        public static void CLearAll()
        {
            gr.Clear(Color.White);
        }
    }
}
