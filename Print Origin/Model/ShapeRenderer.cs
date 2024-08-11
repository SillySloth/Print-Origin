using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Print_Origin.Model
{
    public class ShapeRenderer
    {
        public static Rectangle CreateRectangle(double width, double height, Brush stroke, Brush fill, double thickness)
        {
            return new Rectangle
            {
                Width = width,
                Height = height,
                Stroke = stroke,
                Fill = fill,
                StrokeThickness = thickness
            };
        }

        public static Rectangle StockRectangle(Parameters.StockSize stockSize)
        {
            return CreateRectangle(stockSize.Width, stockSize.Height, Brushes.DimGray, Brushes.LightGray, 10);
        }

        public static Rectangle PrintRectangle(Parameters.PrintSize printSize, Parameters.StockSize stockSize, Parameters.OriginPoints originPoints)
        {
            if (originPoints.Horizontal + printSize.Width > stockSize.Width || originPoints.Vertical + printSize.Height > stockSize.Height || originPoints.Horizontal < 0 || originPoints.Vertical < 0)
                return CreateRectangle(printSize.Width, printSize.Height, Brushes.DarkRed, new SolidColorBrush(Color.FromArgb(128, 255, 0, 0)), 10);

            return CreateRectangle(printSize.Width, printSize.Height, Brushes.DarkGreen, Brushes.LightGreen, 10);
        }        

        public static void DrawShapes(Canvas canvas, Rectangle stockRectangle, Rectangle printRectangle, Parameters.OriginPoints originPoints)
        {
            canvas.Children.Clear();
            canvas.Children.Add(stockRectangle);
            canvas.Children.Add(printRectangle);

            Canvas.SetRight(stockRectangle, 0);
            Canvas.SetBottom(stockRectangle, 0);
            Canvas.SetRight(printRectangle, originPoints.Horizontal);
            Canvas.SetBottom(printRectangle, originPoints.Vertical);
        }
    }
}
