using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            Figures.ListChanged += Figures_ListChanged;
        }

        public BindingList<FigureBase> Figures { get; set; } = new BindingList<FigureBase>();
        public Canvas Drawspace { get; private set; }

        private Pointer _pointer = new Pointer();
        private Pen _pen = new Pen();
        private Eraser _eraser = new Eraser();
        private FigureDesigner _figureDesigner = new FigureDesigner();

        public void ClearDrawspace() => Drawspace.Children.Clear();


        #region Tools proxy.

        #region FigureDesigner

        public FigureBase CreateFigure(FigureType figureType)
        {
            FigureBase figure = null;

            return figure;
        }

        public void EditFigure(FigureBase activeFigure)
        {

        }

        #endregion

        #region Eraser

        public void DeleteFigure(Point figurePoint)
        {

        }

        #endregion

        #region Pointer

        public FigureBase SelectFigure(Point figurePoint)
        {
            FigureBase figure = null;

            return figure;
        }

        #endregion

        #endregion


        #region Event handlers

        private void Figures_ListChanged(object sender, ListChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
