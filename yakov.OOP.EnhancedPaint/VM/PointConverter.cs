using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.VM
{
    public static class PointConverter
    {
        public static System.Windows.Point ConvertToWindows(System.Drawing.Point drawingPoint)
        {
            return new System.Windows.Point(drawingPoint.X, drawingPoint.Y);
        }

        public static System.Drawing.Point ConvertToDrawing(System.Windows.Point windowsPoint)
        {
            return new System.Drawing.Point((int)windowsPoint.X, (int)windowsPoint.Y);
        }
    }
}
