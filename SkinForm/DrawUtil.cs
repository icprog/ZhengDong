using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SkinForm
{
    public class DrawUtil
    {
        public static GraphicsPath CreateCloseFlagPath(Rectangle rect)
        {
            PointF centerPoint = new PointF(
                rect.X + rect.Width / 2.0f,
                rect.Y + rect.Height / 2.0f);

            GraphicsPath path = new GraphicsPath();

            path.AddLine(
                centerPoint.X,
                centerPoint.Y - 2,
                centerPoint.X - 2,
                centerPoint.Y - 4);
            path.AddLine(
                centerPoint.X - 2,
                centerPoint.Y - 4,
                centerPoint.X - 6,
                centerPoint.Y - 4);
            path.AddLine(
                centerPoint.X - 6,
                centerPoint.Y - 4,
                centerPoint.X - 2,
                centerPoint.Y);
            path.AddLine(
                centerPoint.X - 2,
                centerPoint.Y,
                centerPoint.X - 6,
                centerPoint.Y + 4);
            path.AddLine(
                centerPoint.X - 6,
                centerPoint.Y + 4,
                centerPoint.X - 2,
                centerPoint.Y + 4);
            path.AddLine(
                centerPoint.X - 2,
                centerPoint.Y + 4,
                centerPoint.X,
                centerPoint.Y + 2);
            path.AddLine(
                centerPoint.X,
                centerPoint.Y + 2,
                centerPoint.X + 2,
                centerPoint.Y + 4);
            path.AddLine(
               centerPoint.X + 2,
               centerPoint.Y + 4,
               centerPoint.X + 6,
               centerPoint.Y + 4);
            path.AddLine(
              centerPoint.X + 6,
              centerPoint.Y + 4,
              centerPoint.X + 2,
              centerPoint.Y);
            path.AddLine(
             centerPoint.X + 2,
             centerPoint.Y,
             centerPoint.X + 6,
             centerPoint.Y - 4);
            path.AddLine(
             centerPoint.X + 6,
             centerPoint.Y - 4,
             centerPoint.X + 2,
             centerPoint.Y - 4);

            path.CloseFigure();
            return path;
        }

        public static GraphicsPath CreateMinimizeFlagPath(Rectangle rect)
        {
            PointF centerPoint = new PointF(
                rect.X + rect.Width / 2.0f,
                rect.Y + rect.Height / 2.0f);

            GraphicsPath path = new GraphicsPath();

            path.AddRectangle(new RectangleF(
                centerPoint.X - 6,
                centerPoint.Y + 1,
                12,
                3));
            return path;
        }

        public static GraphicsPath CreateMaximizeFlafPath(
            Rectangle rect, bool maximize)
        {
            PointF centerPoint = new PointF(
               rect.X + rect.Width / 2.0f,
               rect.Y + rect.Height / 2.0f);

            GraphicsPath path = new GraphicsPath();

            if (maximize)
            {
                path.AddLine(
                    centerPoint.X - 3,
                    centerPoint.Y - 3,
                    centerPoint.X - 6,
                    centerPoint.Y - 3);
                path.AddLine(
                    centerPoint.X - 6,
                    centerPoint.Y - 3,
                    centerPoint.X - 6,
                    centerPoint.Y + 5);
                path.AddLine(
                    centerPoint.X - 6,
                    centerPoint.Y + 5,
                    centerPoint.X + 3,
                    centerPoint.Y + 5);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y + 5,
                    centerPoint.X + 3,
                    centerPoint.Y + 1);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y + 1,
                    centerPoint.X + 6,
                    centerPoint.Y + 1);
                path.AddLine(
                    centerPoint.X + 6,
                    centerPoint.Y + 1,
                    centerPoint.X + 6,
                    centerPoint.Y - 6);
                path.AddLine(
                    centerPoint.X + 6,
                    centerPoint.Y - 6,
                    centerPoint.X - 3,
                    centerPoint.Y - 6);
                path.CloseFigure();

                path.AddRectangle(new RectangleF(
                    centerPoint.X - 4,
                    centerPoint.Y,
                    5,
                    3));

                path.AddLine(
                    centerPoint.X - 1,
                    centerPoint.Y - 4,
                    centerPoint.X + 4,
                    centerPoint.Y - 4);
                path.AddLine(
                    centerPoint.X + 4,
                    centerPoint.Y - 4,
                    centerPoint.X + 4,
                    centerPoint.Y - 1);
                path.AddLine(
                    centerPoint.X + 4,
                    centerPoint.Y - 1,
                    centerPoint.X + 3,
                    centerPoint.Y - 1);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y - 1,
                    centerPoint.X + 3,
                    centerPoint.Y - 3);
                path.AddLine(
                    centerPoint.X + 3,
                    centerPoint.Y - 3,
                    centerPoint.X - 1,
                    centerPoint.Y - 3);
                path.CloseFigure();
            }
            else
            {
                path.AddRectangle(new RectangleF(
                    centerPoint.X - 6,
                    centerPoint.Y - 4,
                    12,
                    8));
                path.AddRectangle(new RectangleF(
                    centerPoint.X - 3,
                    centerPoint.Y - 1,
                    6,
                    3));
            }

            return path;
        }
    }
}
