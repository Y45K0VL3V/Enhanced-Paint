using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static FigureBase CreateFigure(FigureType figureType, Point canvasPoint)
        {
            FigureBase newFigure = _createMethods[figureType].Invoke();
            newFigure.SetPosition(canvasPoint, canvasPoint);
            
            return newFigure;
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

    }
}
