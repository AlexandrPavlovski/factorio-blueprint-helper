using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FactorioBlueprintHelper.Model
{
    public class PreviewDrawer
    {
        public const int CellSizePx = 10;
        public const int GridLineThiknessPx = 1;

        private Canvas _canvas;
        private Map _map;

        private List<Line> _grid;
        private bool _gridVisible = false;

        public PreviewDrawer()
        {
        }

        public void Init(Canvas canvas, Map map)
        {
            _canvas = canvas;
            _map = map;

            _canvas.Width = _map.Width * CellSizePx + _map.Width * GridLineThiknessPx - GridLineThiknessPx;
            _canvas.Height = _map.Height * CellSizePx + _map.Height * GridLineThiknessPx - GridLineThiknessPx;

            InitGrid();
        }

        public void ToggleGrid()
        {
            foreach (var line in _grid)
            {
                if (_gridVisible)
                    _canvas.Children.Remove(line);
                else
                    _canvas.Children.Add(line);
            }

            _gridVisible = !_gridVisible;
        }

        private void InitGrid()
        {
            _grid = new List<Line>();

            for (int i = 1; i < _map.Width; i++)
            {
                var line = new Line();
                line.Stroke = Brushes.Black;
                line.StrokeThickness = GridLineThiknessPx;

                int x = (CellSizePx + GridLineThiknessPx) * i;

                line.X1 = x;
                line.Y1 = 0;
                line.X2 = x;
                line.Y2 = _canvas.Height;

                _grid.Add(line);
            }

            for (int i = 1; i < _map.Height; i++)
            {
                var line = new Line();
                line.Stroke = Brushes.Black;
                line.StrokeThickness = GridLineThiknessPx;

                int y = (CellSizePx + GridLineThiknessPx) * i;

                line.X1 = 0;
                line.Y1 = y;
                line.X2 = _canvas.Width;
                line.Y2 = y;

                _grid.Add(line);
            }
        }

        //private void DrawGridLines(int )
    }
}
