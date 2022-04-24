using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using yakov.OOP.EnhancedPaint.Figures;

namespace yakov.OOP.EnhancedPaint.Tools
{
    internal static class FigureBaseExtension
    {
        public static void SetPosition(this FigureBase figure, System.Drawing.Point lbmDown, System.Drawing.Point lbmUp)
        {
            figure.PosLeftTop = new System.Drawing.Point(Math.Min(lbmDown.X, lbmUp.X), Math.Min(lbmDown.Y, lbmUp.Y));
            if (figure.WindowsUIElement != null)
            {
                Canvas.SetLeft(figure.WindowsUIElement, figure.PosLeftTop.Value.X);
                Canvas.SetTop(figure.WindowsUIElement, figure.PosLeftTop.Value.Y);
            }
        }

        public static void SetSize(this FigureBase figure, System.Drawing.Point lbmDown, System.Drawing.Point lbmCurr)
        {
            figure.Height = Math.Abs(lbmCurr.Y - lbmDown.Y);
            figure.Width = Math.Abs(lbmCurr.X - lbmDown.X);
            (figure.WindowsUIElement as Shape).Width = figure.Width;
            (figure.WindowsUIElement as Shape).Height = figure.Height;
        }
    }
}
