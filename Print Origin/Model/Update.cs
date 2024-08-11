using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static Print_Origin.Model.Utilities;
using System.Windows.Shapes;

namespace Print_Origin.Model
{
    public class Update
    {      
        
        public void UpdateCanvas(TextBox stockWidthTextBox, TextBox stockHeightTextBox, TextBox printWidthTextBox, TextBox printHeightTextBox, TextBox horizontalOriginTextBox, TextBox verticalOriginTextBox, TextBox gapUpperTextBox, TextBox gapLeftTextBox, TextBox gapRightTextBox, TextBox gapLowerTextBox,
            Position.Placement placement, Canvas canvas)
        {            
            double[] dimensions = CollectDimensions(stockWidthTextBox, stockHeightTextBox, printWidthTextBox, printHeightTextBox, horizontalOriginTextBox, verticalOriginTextBox);
            Parameters parameters = Parameters.createParameters(dimensions, Position.SetPosition(dimensions, placement));
            Rectangle stockRectangle = ShapeRenderer.StockRectangle(parameters.Stock), printRectangle = ShapeRenderer.PrintRectangle(parameters.Print, parameters.Stock, parameters.Origin);
            ShapeRenderer.DrawShapes(canvas, stockRectangle, printRectangle, parameters.Origin);

            UpdateTextboxes(parameters, horizontalOriginTextBox, verticalOriginTextBox, gapUpperTextBox, gapLeftTextBox, gapRightTextBox, gapLowerTextBox); 
        }        
        
        public void UpdateTextboxes(Parameters parameters, TextBox horizontalOrigin, TextBox verticalOrigin, TextBox gapUpper, TextBox gapLeft, TextBox gapRight, TextBox gapLower)
        {
            horizontalOrigin.Text = parameters.Origin.Horizontal.ToString();
            verticalOrigin.Text = parameters.Origin.Vertical.ToString();
            gapUpper.Text = (parameters.Stock.Height - parameters.Print.Height - parameters.Origin.Vertical).ToString();
            gapLeft.Text = (parameters.Stock.Width - parameters.Print.Width - parameters.Origin.Horizontal).ToString();
            gapRight.Text = parameters.Origin.Horizontal.ToString();
            gapLower.Text = parameters.Origin.Vertical.ToString();


        }
    }
}
