using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using yakov.OOP.EnhancedPaint.Figures;
using yakov.OOP.EnhancedPaint.Tools;

namespace yakov.OOP.EnhancedPaint.Workspace
{
    public class PaintModel
    {
        public PaintModel(Canvas drawspace)
        {
            Drawspace = drawspace;
            Figures.ListChanged += Figures_ListChanged;
        }
        
        private Dictionary<UIElement, FigureBase> uiToFigureElements = new Dictionary<UIElement, FigureBase>();  
        public BindingList<FigureBase> Figures { get; set; } = new BindingList<FigureBase>();

        public Canvas Drawspace { get; private set; }

        private readonly Pointer _pointer = new Pointer();
        private readonly Eraser _eraser = new Eraser();
        private readonly FigureDesigner _figureDesigner = new FigureDesigner();

        public void ClearDrawspace() => Drawspace.Children.Clear();


        #region Tools proxy.

        public FigureBase CreateFigure(FigureType figureType, System.Drawing.Point canvasPoint)
        {
            FigureBase figure = _figureDesigner.CreateFigure(figureType, Drawspace, canvasPoint);

            Figures.Add(figure);
            uiToFigureElements.Add(figure.WindowsUIElement, figure);

            return figure;
        }

        public void EditFigure(FigureBase activeFigure, System.Drawing.Point pointDown, System.Drawing.Point pointCurr)
        {
            _figureDesigner.SetSize(activeFigure, pointCurr);
        }

        public void DeleteFigure(System.Drawing.Point figurePoint)
        {
            var itemToDelete = _eraser.SelectItemOnCanvas(Drawspace, figurePoint);

            if (itemToDelete != null)
            {
                Figures.Remove(uiToFigureElements[itemToDelete]);
                uiToFigureElements.Remove(itemToDelete);
            }
        }

        public FigureBase SelectFigure(System.Drawing.Point figurePoint)
        {
            ////TODO: Check on selecting null.
            return uiToFigureElements[_pointer.SelectItemOnCanvas(Drawspace, figurePoint)];
        }

        #endregion

        #region Event handlers

        private void Figures_ListChanged(object sender, ListChangedEventArgs e)
        {
            
        }

        #endregion

    }
}
