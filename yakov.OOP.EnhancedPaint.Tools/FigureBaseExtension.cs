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
    // Here figure.PosLeftUp mean just current mouse position.
    internal static class FigureBaseExtension
    {
        public static void SetPosition(this FigureBase figure)
        {
            if (figure.FigureType != FigureType.Square && figure.FigureType != FigureType.Circle)
            {
                figure.PosLeftTop = new System.Drawing.Point(Math.Min(figure.PosLeftDown.X, figure.PosLeftUp.X), Math.Min(figure.PosLeftDown.Y, figure.PosLeftUp.Y));
            }
            else
            {
                double minSize = Math.Min(Math.Abs(figure.PosLeftUp.X - figure.PosLeftDown.X), Math.Abs(figure.PosLeftUp.Y - figure.PosLeftDown.Y));
                int left = (int)(figure.PosLeftDown.X <= figure.PosLeftUp.X ? figure.PosLeftDown.X : figure.PosLeftDown.X - minSize);
                int top = (int)(figure.PosLeftDown.Y <= figure.PosLeftUp.Y ? figure.PosLeftDown.Y : figure.PosLeftDown.Y - minSize);
                figure.PosLeftTop = new System.Drawing.Point(left, top);
            }

            if (figure.WindowsUIElement != null && figure.FigureType != FigureType.Line)
            {
                Canvas.SetLeft(figure.WindowsUIElement, figure.PosLeftTop.X);
                Canvas.SetTop(figure.WindowsUIElement, figure.PosLeftTop.Y);
            }
        }

        public static void SetSize(this FigureBase figure)
        {
            figure.Height = Math.Abs(figure.PosLeftUp.Y - figure.PosLeftDown.Y);
            figure.Width = Math.Abs(figure.PosLeftUp.X - figure.PosLeftDown.X);

            if (figure.FigureType == FigureType.Square || figure.FigureType == FigureType.Circle)
            {
                double minSize = Math.Min(figure.Width, figure.Height);
                (figure.Height, figure.Width) = (minSize, minSize);
            }

            if (figure.FigureType != FigureType.Line)
            {
                (figure.WindowsUIElement as Shape).Width = figure.Width;
                (figure.WindowsUIElement as Shape).Height = figure.Height;
            }
            else
            {
                (figure.WindowsUIElement as System.Windows.Shapes.Line).X1 = figure.PosLeftDown.X;
                (figure.WindowsUIElement as System.Windows.Shapes.Line).X2 = figure.PosLeftUp.X;
                (figure.WindowsUIElement as System.Windows.Shapes.Line).Y1 = figure.PosLeftDown.Y;
                (figure.WindowsUIElement as System.Windows.Shapes.Line).Y2 = figure.PosLeftUp.Y;
            }
        }
    }
}
