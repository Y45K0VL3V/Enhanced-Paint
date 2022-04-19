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
        FigureDesigner,
        Eraser
    }
    public abstract class Tool
    {
        public abstract ToolType ToolType { get; }
    }
}
