using System.Drawing;

#pragma warning disable CA1416

namespace Mathematics;

public class Graph
{
    public float MaxX { get; set; }
    public float MaxY { get; set; }

    private readonly List<List<double>> _points;
    private readonly List<Color> _color;
    private readonly int _numberOfLines;
    private const float _xOffset = 20;
    private const float _yOffset = 10;

    public Graph(float maxX, float maxY, int numberOfLines, List<Color> color)
    {
        MaxX = maxX;
        MaxY = maxY;
        _numberOfLines = numberOfLines;
        _points = [];
        _color = color;
        for (var i = 0; i < _numberOfLines; i++)
        {
            _points.Add([]);
        }
    }

    public void AddPoint(int line, double value)
    {
        if (line >= _numberOfLines || line < 0)
            throw new Exception("line needs to be between 0 and " + _numberOfLines);

        _points[line].Add(value);
    }

    public void Draw(Graphics graphics, Bitmap bitmap)
    {
        var brush = new SolidBrush(Color.White);
        var pen = new Pen(Color.Black);
        graphics.DrawLine(pen, new PointF(_xOffset, bitmap.Height - _yOffset), new PointF(_xOffset, _yOffset));
        graphics.DrawLine(pen, new PointF(_xOffset, bitmap.Height - _yOffset), new PointF(bitmap.Width - _xOffset, bitmap.Height - _yOffset));

        for (var i = 0; i < _points.Count; i++)
        {
            if (_points[i].Count <= 1)
                continue;

            pen.Color = _color[i];
            graphics.DrawLines(pen, GetLines(_points[i], bitmap));
        }

        brush.Color = Color.Black;
        const int ySegments = 5;
        var yUnit = (int) (MaxY / ySegments - MaxY / ySegments % 5);
        for (var i = 0; i <= ySegments; i++)
        {
            var text = (i * yUnit).ToString();
            graphics.DrawString(text, new Font("Consolas", 8), brush, 0, (int) (bitmap.Height - _yOffset - (i * ((bitmap.Height - 2 * _yOffset) / ySegments))));
        }

        const int xSegments = 10;
        var xUnit = (int) (MaxX / xSegments - MaxX / xSegments % 5);
        for (var i = 0; i <= xSegments; i++)
        {
            var text = (i * xUnit).ToString();
            graphics.DrawString(text, new Font("Consolas", 8), brush, (int) (_xOffset + (i * ((bitmap.Width - 2 * _xOffset) / xSegments))), bitmap.Height - 10);
        }
    }

    private PointF[] GetLines(List<double> lines, Bitmap bitmap)
    {
        Resize(bitmap);
        var points = new PointF[lines.Count];
        for (var i = 0; i < lines.Count; i++)
        {
            points[i] = new PointF(_xOffset + i * (bitmap.Width - _xOffset * 2) / MaxX,
                                   bitmap.Height - _yOffset - (float) (lines[i] * (bitmap.Height - _yOffset * 2) / MaxY));
        }

        return points;
    }

    private void Resize(Bitmap bitmap)
    {
        var numberOfLines = _points.Max(a => a.Count);
        var maxValue = _points.Max(a => a.Max(b => b));
        MaxX = (numberOfLines - 1) - (numberOfLines - 1) % 50 + 50;
        MaxY = (int) (maxValue - maxValue % 50 + 50);
    }
}