﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

        public double Width { get; set; }

        public double Height { get; set; }

        public byte BorderWidth { get; set; }

        public Color BorderColor { get; set; } = Color.Black;

        public Color FillColor { get; set; } = Color.White;


        // Position on drawing place (optional).
        public Point? PosLeftTop { get; set; } = new Point(0, 0);

        public void SetPosition(Point lbmDown, Point lbmUp)
        {
            PosLeftTop = new Point(Math.Min(lbmDown.X, lbmUp.X), Math.Min(lbmDown.Y, lbmUp.Y));
        }

        public void Dispose()
        {
            WindowsUIElement = null;
        }

        [JsonIgnore]
        public UIElement WindowsUIElement { get; set; } 
    }
}
