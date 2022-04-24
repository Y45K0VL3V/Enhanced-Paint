using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using yakov.OOP.EnhancedPaint.Workspace;
using yakov.OOP.EnhancedPaint.Tools;
using yakov.OOP.EnhancedPaint.Figures;
using System.Windows.Input;
using System.Drawing;

namespace yakov.OOP.EnhancedPaint.VM
{
    public class MainVM : INotifyPropertyChanged
    {
        public MainVM(Canvas canvas)
        {
            DrawingControl = new PaintModel(canvas);
        }

        public PaintModel DrawingControl { get; set; }

        #region Tools choose.

        private Dictionary<int, (ToolType, FigureType?)> _indexedTools = new Dictionary<int, (ToolType, FigureType?)>
        {
            [0] = (ToolType.Pointer, null),
            [1] = (ToolType.FigureDesigner, FigureType.Line),
            [2] = (ToolType.FigureDesigner, FigureType.Rect),
            [3] = (ToolType.FigureDesigner, FigureType.RoundedRect),
            [4] = (ToolType.FigureDesigner, FigureType.Square),
            [5] = (ToolType.FigureDesigner, FigureType.Ellipse),
            [6] = (ToolType.FigureDesigner, FigureType.Circle),
            [7] = (ToolType.FigureDesigner, null)
        };

        public ToolType Tool { get; set; } = ToolType.Pointer;
        public FigureType? FigureToCreate { get; set; } = null;

        private int _toolIndex = 0;
        public int ToolIndex 
        {
            get
            {
                return _toolIndex;
            }
            set
            {
                (Tool, FigureToCreate) = _indexedTools[value];
                _toolIndex = value;
                OnPropertyChanged("ToolIndex");
            }
        }

        #endregion

        public byte BorderWidth 
        { 
            get => DrawingToolsControl.BorderWidth; 
            set => DrawingToolsControl.BorderWidth = value; 
        }
        public SolidColorBrush BorderColor 
        { 
            get => new SolidColorBrush(DrawingToolsControl.BorderColor); 
            set => DrawingToolsControl.BorderColor = value.Color; 
        }
        public SolidColorBrush FillColor
        {
            get => new SolidColorBrush(DrawingToolsControl.FillColor);
            set => DrawingToolsControl.FillColor = value.Color;
        }


        private bool _isLeftButtonPressed = false;

        private RelayCommand _leftButtonDown;
        public RelayCommand LeftButtonDown
        {
            get
            {
                return _leftButtonDown ?? (_leftButtonDown = new RelayCommand(obj =>
                {
                    _isLeftButtonPressed = true;
                    Point createPoint = PointConverter.ConvertToDrawing(Mouse.GetPosition(DrawingControl.Drawspace));
                }));
            }
        }

        private RelayCommand _leftButtonUp;
        public RelayCommand LeftButtonUp
        {
            get
            {
                return _leftButtonUp ?? (_leftButtonUp = new RelayCommand(obj =>
                {
                    _isLeftButtonPressed = false;
                    Point _leftTopPos = PointConverter.ConvertToDrawing(Mouse.GetPosition(DrawingControl.Drawspace));
                }));
            }
        }

        private RelayCommand _leftButtonDrag;
        public RelayCommand LeftButtonDrag
        {
            get
            {
                return _leftButtonDrag ?? (_leftButtonDrag = new RelayCommand(obj =>
                {
                    Point _leftTopPos = PointConverter.ConvertToDrawing(Mouse.GetPosition(DrawingControl.Drawspace));
                }));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
