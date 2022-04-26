using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using yakov.OOP.EnhancedPaint.Figures;

namespace yakov.OOP.EnhancedPaint.Tools
{
    public class Pointer : Tool, ISelect
    {
        public override ToolType ToolType { get; } = ToolType.Pointer;

        public UIElement SelectItemOnCanvas(Canvas canvas, System.Drawing.Point clickedPos)
        {
            for(int i = canvas.Children.Count - 1; i >= 0; i--)
            {
                if (canvas.Children[i].IsMouseOver)
                    return canvas.Children[i];
            }

            return null;
        }

        public void ChangePosition(FigureBase activeFigure, int diffHeight, int diffWidth)
        {
            activeFigure.PosLeftUp = new System.Drawing.Point(activeFigure.PosLeftUp.X - diffWidth, activeFigure.PosLeftUp.Y - diffHeight);
            activeFigure.PosLeftDown = new System.Drawing.Point(activeFigure.PosLeftDown.X - diffWidth, activeFigure.PosLeftDown.Y - diffHeight);
            activeFigure.PosLeftTop = new System.Drawing.Point(activeFigure.PosLeftTop.X - diffWidth, activeFigure.PosLeftTop.Y - diffHeight);

            if (activeFigure.FigureType != FigureType.Line)
            {
                Canvas.SetLeft(activeFigure.WindowsUIElement, activeFigure.PosLeftTop.X);
                Canvas.SetTop(activeFigure.WindowsUIElement, activeFigure.PosLeftTop.Y);
            }
            else
            {
                (activeFigure.WindowsUIElement as System.Windows.Shapes.Line).X1 = activeFigure.PosLeftDown.X - diffWidth;
                (activeFigure.WindowsUIElement as System.Windows.Shapes.Line).X2 = activeFigure.PosLeftUp.X - diffWidth;
                (activeFigure.WindowsUIElement as System.Windows.Shapes.Line).Y1 = activeFigure.PosLeftDown.Y - diffHeight;
                (activeFigure.WindowsUIElement as System.Windows.Shapes.Line).Y2 = activeFigure.PosLeftUp.Y - diffHeight;
            }
        }
    }
}
