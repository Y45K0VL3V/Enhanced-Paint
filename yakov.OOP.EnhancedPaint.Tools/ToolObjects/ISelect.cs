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
    public interface ISelect
    {
        UIElement SelectItemOnCanvas(Canvas canvas, System.Drawing.Point clickedPos);
    }
}
