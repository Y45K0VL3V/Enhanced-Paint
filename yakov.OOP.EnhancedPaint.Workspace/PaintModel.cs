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
using yakov.OOP.EnhancedPaint.Plugins.Interfaces;
using System.IO;
using Microsoft.Win32;
using yakov.OOP.EnhancedPaint.Plugins;
using System.Numerics;

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


        #region Tools interface.

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

        #region Figures backup processing.

        private BigInteger _privateKeyQ = 619;
        private BigInteger _privateKeyP = 3;
        private BigInteger _publicKeyB = 100;
        public void SaveFigures(IFigureSerializer<FigureBase> serializer, IArchiver archiver, IRabinCrypter crypter)
        {
            if (serializer == null)
                return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                var serializedFigures = Encoding.UTF8.GetBytes(serializer.Serialize(Figures));

                try
                {
                    if (crypter != null)
                    {
                        serializedFigures = crypter.Encrypt(_privateKeyP*_privateKeyQ, _publicKeyB, (byte[])serializedFigures.Clone());
                    }

                    if (archiver != null)
                    {
                        archiver.Archive(ref serializedFigures);
                    }

                    File.WriteAllBytes(saveFileDialog.FileName, serializedFigures);
                }
                catch { }
            }
        }

        public void LoadFigures(IFigureSerializer<FigureBase> serializer, IArchiver archiver, IRabinCrypter crypter)
        {
            if (serializer == null)
                return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var serializedFigures = File.ReadAllBytes(openFileDialog.FileName);

                try
                {
                    if (archiver != null)
                    {
                        archiver.Dearchive(ref serializedFigures);
                    }

                    if (crypter != null)
                    {
                        serializedFigures = crypter.Decrypt(_privateKeyQ, _privateKeyP, _publicKeyB, (byte[])serializedFigures.Clone());
                    }

                    var tmpFigures = serializer.Deserialize(Encoding.UTF8.GetString(serializedFigures));
                    _figureDesigner.DrawFigures(ref tmpFigures, Drawspace);

                    Figures = tmpFigures;

                    for (int i = 0; i < Figures?.Count; i++)
                        _uiToFigureElements.Add(Figures[i].WindowsUIElement, Figures[i]);
                }
                catch { }
            }
        }
        #endregion

    }
}
