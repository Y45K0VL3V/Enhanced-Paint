using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using yakov.OOP.EnhancedPaint.Figures;

namespace yakov.OOP.EnhancedPaint.Tools
{
    public static class FigureBaseExtension
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
    }
}
