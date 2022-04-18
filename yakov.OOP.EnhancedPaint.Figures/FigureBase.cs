using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Figures
{
    public enum FigureType
    {
        Line,
        Rect,
        RoundedRect,
        Square,
        Ellipse,
        Circle
    }

    public abstract class FigureBase
    {
        public FigureType FigureType { get; set; }


    }
}
