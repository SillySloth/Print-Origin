using System.Windows.Controls;
using System.Windows.Media;
using static Print_Origin.Model.Utilities;
using System;


namespace Print_Origin.Model
{
    public class Update
    {
        private TextBoxGroup TextBoxes { get; set; }
        private AlignmentDetails Alignment { get; set; }        

        public Update(TextBoxGroup textBoxGroup, AlignmentDetails alignmentDetails)
        {
            TextBoxes = textBoxGroup;
            Alignment = alignmentDetails;            
        }                        

        public class TextBoxGroup
        {
            public TextBox StockWidth { get; set; }
            public TextBox StockHeight { get; set; }
            public TextBox PrintWidth { get; set; }
            public TextBox PrintHeight { get; set; }
            public TextBox HorizontalOrigin { get; set; }
            public TextBox VerticalOrigin { get; set; }
            public TextBlock MarginTop { get; set; }
            public TextBlock MarginLeft { get; set; }
            public TextBlock MarginRight { get; set; }
            public TextBlock MarginBottom { get; set; }
            public TextBox Offset {  get; set; }

            public TextBoxGroup(TextBox stockWidth, TextBox stockHeight, TextBox printWidth, TextBox printHeight, TextBox horizontalOrigin, TextBox verticalOrigin, TextBox offset, TextBlock marginTop, TextBlock marginLeft, TextBlock marginRight, TextBlock marginBottom)
            {
                StockWidth = stockWidth;
                StockHeight = stockHeight;
                PrintWidth = printWidth;
                PrintHeight = printHeight;
                HorizontalOrigin = horizontalOrigin;
                VerticalOrigin = verticalOrigin;
                MarginTop = marginTop;
                MarginLeft = marginLeft;
                MarginRight = marginRight;
                MarginBottom = marginBottom;
                Offset = offset;
            }
        }

        public class AlignmentDetails
        {
            public TextBlock AlignmentLabel { get; set; }
            public Position.Placement Placement { get; set; }

            public AlignmentDetails(TextBlock alignmentLabel, Position.Placement placement) 
            { 
                AlignmentLabel = alignmentLabel;
                Placement = placement;                
            }
        }
        public void UpdateUI(Parameters parameters, Canvas canvas)
        {
            UpdateCanvas(parameters, canvas);
            UpdateText(parameters);
        }

        public static void UpdateCanvas(Parameters parameters, Canvas canvas)
        {
            var shapes = new ShapeRenderer(new ShapeRenderer.StockRectangle(parameters), new ShapeRenderer.PrintRectangle(parameters));                  
            ShapeRenderer.DrawShapes(canvas, shapes, parameters);             
        }

        private void UpdateText(Parameters parameters)
        {
            TextBoxes.MarginTop.Text = Math.Round((parameters.Stock.Height - parameters.Print.Height - parameters.Origin.Vertical),2).ToString();
            TextBoxes.MarginLeft.Text = Math.Round((parameters.Stock.Width - parameters.Print.Width - parameters.Origin.Horizontal), 2).ToString();
            TextBoxes.MarginRight.Text = Math.Round(parameters.Origin.Horizontal, 2).ToString();
            TextBoxes.MarginBottom.Text = Math.Round(parameters.Origin.Vertical, 2).ToString();


            TextBoxes.HorizontalOrigin.Foreground = UpdateForegroundColor(parameters.Origin.Horizontal);
            TextBoxes.VerticalOrigin.Foreground = UpdateForegroundColor(parameters.Origin.Vertical);
            TextBoxes.MarginTop.Foreground = UpdateForegroundColor((parameters.Stock.Height - parameters.Print.Height - parameters.Origin.Vertical));
            TextBoxes.MarginLeft.Foreground = UpdateForegroundColor((parameters.Stock.Width - parameters.Print.Width - parameters.Origin.Horizontal));
            TextBoxes.MarginRight.Foreground = UpdateForegroundColor(parameters.Origin.Horizontal);
            TextBoxes.MarginBottom.Foreground = UpdateForegroundColor(parameters.Origin.Vertical);

            Alignment.AlignmentLabel.Text = SetAlignmentLabel(Alignment.Placement);
            TextBoxes.StockWidth.Text = parameters.Stock.Width.ToString();
            TextBoxes.StockHeight.Text = parameters.Stock.Height.ToString();
            TextBoxes.HorizontalOrigin.Text = Math.Round(parameters.Origin.Horizontal, 2).ToString();
            TextBoxes.VerticalOrigin.Text = Math.Round(parameters.Origin.Vertical, 2).ToString();

        }
        public static Brush UpdateForegroundColor(double parameter)
        {
            if (parameter < 0)            
                return Brushes.Red;            

            else
                return Brushes.Black;

        }

    }
}

