using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Tools
{
    public enum ToolType
    {
        Pointer,
        Pen,
        Line,
        Rect,
        RoundedRect,
        Square,
        Ellipse,
        Circle
    }
    public abstract class Tool
    {
        public ToolType ToolType { get; set; }
    }
}
