using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using yakov.OOP.EnhancedPaint.Figures;

namespace yakov.OOP.EnhancedPaint.Tools
{
    public class FigureDesigner : Tool
    {
        public override ToolType ToolType { get; } = ToolType.FigureDesigner;

        private static Dictionary<FigureType, CreateFigureDelegate> _createMethods = new Dictionary<FigureType, CreateFigureDelegate>()
        {
            [FigureType.Line] = CreateLine,
            [FigureType.Rect] = CreateRect,
            [FigureType.RoundedRect] = CreateRoundRect,
            [FigureType.Square] = CreateSquare,
            [FigureType.Ellipse] = CreateEllipse,
            [FigureType.Circle] = CreateCircle
        };

        public FigureBase CreateFigure(FigureType figureType, Canvas canvas, Point canvasPoint)
        {
            FigureBase newFigure = _createMethods[figureType].Invoke();
            newFigure.PosLeftDown = canvasPoint;
            newFigure.PosLeftUp = canvasPoint;
            newFigure.SetPosition();

            SetFillColor(newFigure);
            SetStrokeColor(newFigure);
            SetStrokeThickness(newFigure);
            if(figureType == FigureType.RoundedRect)
                SetRoundedBorder(newFigure as RoundedRect);
            
            canvas.Children.Add(newFigure.WindowsUIElement);

            return newFigure;
        }

        public void DrawFigures(ref List<FigureBase> figures)
        {
            for (int i = 0; i < figures.Count; i++)
            {

            }
        }

        #region Create figure methods.

        private delegate FigureBase CreateFigureDelegate();

        private static FigureBase CreateLine() => new Figures.Line() { WindowsUIElement = new System.Windows.Shapes.Line() };

        private static FigureBase CreateRect() => new Figures.Rect() { WindowsUIElement = new System.Windows.Shapes.Rectangle() };

        private static FigureBase CreateRoundRect() => new Figures.RoundedRect() { WindowsUIElement = new System.Windows.Shapes.Rectangle() };

        private static FigureBase CreateSquare() => new Figures.Square() { WindowsUIElement = new System.Windows.Shapes.Rectangle() };

        private static FigureBase CreateCircle() => new Figures.Circle() { WindowsUIElement = new System.Windows.Shapes.Ellipse() };

        private static FigureBase CreateEllipse() => new Figures.Ellipse() { WindowsUIElement = new System.Windows.Shapes.Ellipse() };

        #endregion

        #region Change figure view.

        public static void SetFillColor(FigureBase figure)
        {
            SetFillColor(figure, DrawingToolsControl.FillColor);
        }
        public static void SetFillColor(FigureBase figure, System.Windows.Media.Color color)
        {
            (figure.WindowsUIElement as Shape).Fill = new SolidColorBrush(color);
            figure.FillColor = color;
        }

        public static void SetStrokeColor(FigureBase figure)
        {
            SetStrokeColor(figure, DrawingToolsControl.BorderColor);
        }
        public static void SetStrokeColor(FigureBase figure, System.Windows.Media.Color color)
        {
            (figure.WindowsUIElement as Shape).Stroke = new SolidColorBrush(color);
            figure.BorderColor = color;
        }

        public static void SetStrokeThickness(FigureBase figure)
        {
            SetStrokeThickness(figure, DrawingToolsControl.BorderWidth);
        }
        public static void SetStrokeThickness(FigureBase figure, byte width)
        {
            (figure.WindowsUIElement as Shape).StrokeThickness = width;
            figure.BorderWidth = width;
        }

        public static void SetRoundedBorder(RoundedRect roundedRect)
        {
            (roundedRect.WindowsUIElement as System.Windows.Shapes.Rectangle).RadiusX = DrawingToolsControl.CornerRadius;
            (roundedRect.WindowsUIElement as System.Windows.Shapes.Rectangle).RadiusY = DrawingToolsControl.CornerRadius;
        }

        #endregion

        public void SetSize(FigureBase figure, Point pointCurr)
        {
            figure.PosLeftUp = pointCurr;
            figure.SetPosition();
            figure.SetSize();
        }

    }
}
