using System.Windows.Media;

namespace yakov.OOP.EnhancedPaint.Tools
{
    public static class DrawingToolsControl
    {
        public static Color BorderColor { get; set; } = Color.FromRgb(0, 0, 0);

        public static Color FillColor { get; set; } = Color.FromRgb(255, 255, 255);

        public static byte BorderWidth { get; set; } = 1;

        //public static byte CornerRadius { get; set; } = 5;
    }
}
