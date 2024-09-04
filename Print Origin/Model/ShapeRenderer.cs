using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Print_Origin.Model
{
    public class ShapeRenderer
    {
        public StockRectangle Stock { get; set; }
        public PrintRectangle Print { get; set; }
        
        public ShapeRenderer(StockRectangle stockRectangle, PrintRectangle printRectangle) 
        {
            Stock = stockRectangle;
            Print = printRectangle;        
        }
        public class StockRectangle 
        {       
            public Rectangle Stock { get; set; }

            public StockRectangle(Parameters parameters)
            {
                Stock = CreateStockRectangle(parameters);
            }
        }
        public class PrintRectangle 
        { 
            public Rectangle Print { get; set; }

            public PrintRectangle(Parameters parameters) 
            {
                Print = CreatePrintRectangle(parameters);
            }
        
        }
        
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

        public static Rectangle CreateStockRectangle(Parameters parameters) 
        {
            return CreateRectangle(parameters.Stock.Width, parameters.Stock.Height, Brushes.DimGray, Brushes.LightGray, 10);
        }

        public static Rectangle CreatePrintRectangle(Parameters parameters)
        {          

            if (parameters.Origin.Horizontal + parameters.Print.Width > parameters.Stock.Width || parameters.Origin.Vertical + parameters.Print.Height > parameters.Stock.Height || parameters.Origin.Horizontal < 0 || parameters.Origin.Vertical < 0)
                return CreateRectangle(parameters.Print.Width, parameters.Print.Height, Brushes.DarkRed, new SolidColorBrush(Color.FromArgb(128, 255, 0, 0)), 10);

            return CreateRectangle(parameters.Print.Width, parameters.Print.Height, Brushes.DarkGreen, Brushes.LightGreen, 10);
        }        

        public static void DrawShapes(Canvas canvas, ShapeRenderer shapes, Parameters parameters)
        {
            var stock = shapes.Stock.Stock; 
            var print = shapes.Print.Print;


            canvas.Children.Clear();
            canvas.Children.Add(stock);
            canvas.Children.Add(print);

            Canvas.SetRight(stock, 0);
            Canvas.SetBottom(stock, 0);
            Canvas.SetRight(print, parameters.Origin.Horizontal);
            Canvas.SetBottom(print, parameters.Origin.Vertical);
        }

        
    }
}
