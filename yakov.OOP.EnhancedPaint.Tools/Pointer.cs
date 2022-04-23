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
    }
}
