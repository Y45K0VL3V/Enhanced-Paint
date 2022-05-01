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
using yakov.OOP.EnhancedPaint.Serialization;
using yakov.OOP.EnhancedPaint.Plugins.Archiving;
using System.IO;
using Microsoft.Win32;

namespace yakov.OOP.EnhancedPaint.Workspace
{
    public class PaintModel
    {
        public PaintModel(Canvas drawspace)
        {
            Drawspace = drawspace;
        }
        
        private Dictionary<UIElement, FigureBase> _uiToFigureElements = new Dictionary<UIElement, FigureBase>();  
        public List<FigureBase> Figures { get; set; } = new List<FigureBase>();

        public Canvas Drawspace { get; private set; }

        private readonly Pointer _pointer = new Pointer();
        private readonly Eraser _eraser = new Eraser();
        private readonly FigureDesigner _figureDesigner = new FigureDesigner();

        public void ClearDrawspace() => Drawspace.Children.Clear();


        #region Tools proxy.

        public FigureBase CreateFigure(FigureType figureType, System.Drawing.Point canvasPoint)
        {
            FigureBase figure = _figureDesigner.CreateFigure(figureType, Drawspace, canvasPoint, true);

            Figures.Add(figure);
            _uiToFigureElements.Add(figure.WindowsUIElement, figure);

            return figure;
        }

        public void EditFigure(FigureBase activeFigure, System.Drawing.Point pointDown, System.Drawing.Point pointCurr)
        {
            _figureDesigner.Resize(activeFigure, pointCurr);
        }

        public void DeleteFigure(System.Drawing.Point figurePoint)
        {
            var itemToDelete = _eraser.SelectItemOnCanvas(Drawspace, figurePoint);

            if (itemToDelete != null)
            {
                Figures.Remove(_uiToFigureElements[itemToDelete]);
                _uiToFigureElements.Remove(itemToDelete);
            }
        }

        public FigureBase SelectFigure(System.Drawing.Point figurePoint)
        {
            var selectedItem = _pointer.SelectItemOnCanvas(Drawspace, figurePoint);

            if (selectedItem != null)
                return _uiToFigureElements[selectedItem];
            else
                return null;
        }

        public void ChangePosition(FigureBase activeFigure, int diffHeight, int diffWidth)
        {
            if (activeFigure.PosLeftTop.X - diffWidth >= 0 && activeFigure.PosLeftTop.Y - diffHeight >= 0)
                _pointer.ChangePosition(activeFigure, diffHeight, diffWidth);
        }

        #endregion

        public void SaveFigures(IFigureSerializer<FigureBase> serializer, IArchiver archiver)
        {
            if (serializer == null)
                return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    var serializedFigures = serializer.Serialize(Figures);

                    if (archiver != null)
                    {
                        ////TODO: Plugins.
                    }

                    writer.Write(serializedFigures);
                }
        }

        public void LoadFigures(IFigureSerializer<FigureBase> serializer, IArchiver archiver)
        {
            if (serializer == null)
                return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    var serializedFigures = reader.ReadToEnd();

                    if (archiver != null)
                    {
                        ////TODO: Plugins.
                    }

                    var tmpFigures = serializer.Deserialize(serializedFigures);
                    _figureDesigner.DrawFigures(ref tmpFigures, Drawspace);

                    Figures = tmpFigures;

                    for (int i = 0; i < Figures.Count; i++)
                        _uiToFigureElements.Add(Figures[i].WindowsUIElement, Figures[i]);
                }
        }

    }
}
