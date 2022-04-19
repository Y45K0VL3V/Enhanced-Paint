using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using yakov.OOP.EnhancedPaint.Figures;
using yakov.OOP.EnhancedPaint.Tools;

namespace yakov.OOP.EnhancedPaint.Workspace
{
    public class PaintModel
    {
        public PaintModel(Canvas drawspace)
        {
            Drawspace = drawspace;
        }

        public Canvas Drawspace { get; private set; }

        private Pointer _pointer = new Pointer();
        private Pen _pen = new Pen();
        private Eraser _eraser = new Eraser();
    }
}
