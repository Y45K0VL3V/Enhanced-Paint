using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Figures
{
    public class RoundedRect : Rect
    {

        public override FigureType FigureType { get; } = FigureType.RoundedRect;
        public byte CornerRadius { get; set; } = 5;
    }
}
