using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace yakov.OOP.EnhancedPaint.Tools
{
    public class Eraser : Tool, ISelect
    {
        public override ToolType ToolType { get; } = ToolType.Eraser;

        public UIElement SelectItemOnCanvas(Canvas canvas, System.Drawing.Point clickedPos)
        {
            for (int i = canvas.Children.Count - 1; i >= 0; i--)
            {
                if (canvas.Children[i].IsMouseOver)
                {
                    UIElement element = canvas.Children[i];
                    canvas.Children.Remove(element);
                    return element;
                }
            }
            return null;
        }
    }
}
