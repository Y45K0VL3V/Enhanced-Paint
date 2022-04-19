using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Figures
{
    public class Circle : Ellipse
    {
        public override FigureType FigureType { get; } = FigureType.Circle;
    }
}
