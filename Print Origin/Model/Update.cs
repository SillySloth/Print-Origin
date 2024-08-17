using System.Windows.Controls;
using static Print_Origin.Model.Utilities;


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
            public TextBox MarginTop { get; set; }
            public TextBox MarginLeft { get; set; }
            public TextBox MarginRight { get; set; }
            public TextBox MarginBottom { get; set; }

            public TextBoxGroup(TextBox stockWidth, TextBox stockHeight, TextBox printWidth, TextBox printHeight, TextBox horizontalOrigin, TextBox verticalOrigin, TextBox gapUpper, TextBox gapLeft, TextBox gapRight, TextBox gapLower)
            {
                StockWidth = stockWidth;
                StockHeight = stockHeight;
                PrintWidth = printWidth;
                PrintHeight = printHeight;
                HorizontalOrigin = horizontalOrigin;
                VerticalOrigin = verticalOrigin;
                MarginTop = gapUpper;
                MarginLeft = gapLeft;
                MarginRight = gapRight;
                MarginBottom = gapLower;
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
            Alignment.AlignmentLabel.Text = SetAlignmentLabel(Alignment.Placement);
            TextBoxes.HorizontalOrigin.Text = parameters.Origin.Horizontal.ToString();
            TextBoxes.VerticalOrigin.Text = parameters.Origin.Vertical.ToString();
            TextBoxes.MarginTop.Text = (parameters.Stock.Height - parameters.Print.Height - parameters.Origin.Vertical).ToString();
            TextBoxes.MarginLeft.Text = (parameters.Stock.Width - parameters.Print.Width - parameters.Origin.Horizontal).ToString();
            TextBoxes.MarginRight.Text = parameters.Origin.Horizontal.ToString();
            TextBoxes.MarginBottom.Text = parameters.Origin.Vertical.ToString();
        }        


    }
}

