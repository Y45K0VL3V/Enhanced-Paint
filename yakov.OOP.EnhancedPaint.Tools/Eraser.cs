using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yakov.OOP.EnhancedPaint.Tools
{
    public class Eraser : Tool 
    {
        public override ToolType ToolType { get; } = ToolType.Eraser;
    }
}
