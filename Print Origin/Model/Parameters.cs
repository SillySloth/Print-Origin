using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Print_Origin.Model.Utilities;

namespace Print_Origin.Model
{
    public class Parameters
    {
        public StockSize Stock { get; set; }
        public PrintSize Print { get; set; }
        public OriginPoints Origin { get; set; }

        public Parameters(StockSize stockSize, PrintSize printSize, OriginPoints originPoints)
        {
            Stock = stockSize;
            Print = printSize;
            Origin = originPoints;
        }

        public class OriginPoints
        {
            public double Horizontal { get;  }
            public double Vertical { get; }

            public OriginPoints(double horizontal, double vertical)
            {
                Horizontal = horizontal;
                Vertical = vertical;
            }
        }

        public class PrintSize
        {
            public double Width { get; }
            public double Height { get; }

            public PrintSize(double width, double height)
            {
                Width = width;
                Height = height;
            }
        }

        public class StockSize
        {
            public double Width { get; }
            public double Height { get; }

            public StockSize(double width, double height)
            {
                Width = width;
                Height = height;
            }
        }
        public static Parameters UpdateParameters(
            TextBox stockWidthTextBox, 
            TextBox stockHeightTextBox, 
            TextBox printWidthTextBox, 
            TextBox printHeightTextBox,
            TextBox horizontalOriginTextBox, 
            TextBox verticalOriginTextBox, 
            TextBox defaultOffsetTextBox,
            Position.Placement placement)
        {
            double[] dimensions = ConvertInputs(stockWidthTextBox, stockHeightTextBox, printWidthTextBox, printHeightTextBox, horizontalOriginTextBox, verticalOriginTextBox, defaultOffsetTextBox);
            OriginPoints originPoints = Position.SetPosition(StockCheck(dimensions), placement);

            Parameters parameters = new(
                new StockSize(dimensions[0], dimensions[1]), 
                new PrintSize(dimensions[2], dimensions[3]), 
                new OriginPoints(originPoints.Horizontal, originPoints.Vertical));            

            return parameters;
        }

        
    }
}

