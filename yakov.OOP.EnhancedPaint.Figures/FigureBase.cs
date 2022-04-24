using Newtonsoft.Json;
using System;
using System.Windows;
using System.Windows.Media;

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

    public abstract class FigureBase : IDisposable
    {
        public abstract FigureType FigureType { get; }

        public double Width { get; set; } = 0;

        public double Height { get; set; } = 0;

        public byte BorderWidth { get; set; } = 0;

        public Color BorderColor { get; set; } = Color.FromRgb(0, 0, 0);

        public Color FillColor { get; set; } = Color.FromRgb(255, 255, 255);


        // Position on drawing place (optional).
        public System.Drawing.Point PosLeftTop { get; set; } = new System.Drawing.Point(0, 0);

        public System.Drawing.Point PosLeftDown { get; set; } = new System.Drawing.Point(0, 0);

        public System.Drawing.Point PosLeftUp { get; set; } = new System.Drawing.Point(0, 0);

        [JsonIgnore]
        public UIElement WindowsUIElement { get; set; }

        public void Dispose()
        {
            WindowsUIElement = null;
        }
    }
}
