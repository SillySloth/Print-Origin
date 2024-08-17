using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace Print_Origin.Model
{
    public class Utilities
    {
        public static void MinimizeWindow(Window window)
        {
            if (window != null)
                window.WindowState = WindowState.Minimized;
        }

        public static void CloseWindow(Window window)
        {
            window?.Close();
        }

        public static void ClickDrag(Window window, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (window != null && e.ButtonState == System.Windows.Input.MouseButtonState.Pressed)
                window.DragMove();

        }

        public static double ParseTextBox(TextBox textbox)
        {
            var cleanedText = textbox.Text.Replace(" ", "");
            if (double.TryParse(cleanedText, out double result))
            {
                return result;
            }
            return 0;
        }

        public static double[] ConvertInputs(
            TextBox stockWidthTextBox, 
            TextBox stockHeightTextBox, 
            TextBox printWidthTextBox, 
            TextBox printHeightTextBox, 
            TextBox horizontalTextBox, 
            TextBox verticalTextBox,
            TextBox defaultOffsetTextBox)
        {
            double stockWidth = ParseTextBox(stockWidthTextBox);
            double stockHeight = ParseTextBox(stockHeightTextBox);
            double printWidth = ParseTextBox(printWidthTextBox);
            double printHeight = ParseTextBox(printHeightTextBox);
            double horizontalOrigin = ParseTextBox(horizontalTextBox);
            double verticalOrigin = ParseTextBox(verticalTextBox);
            double defaultOffset = ParseTextBox(defaultOffsetTextBox);

            double[] inputs = new double[7];
            inputs[0] = stockWidth;
            inputs[1] = stockHeight;
            inputs[2] = printWidth;
            inputs[3] = printHeight;
            inputs[4] = horizontalOrigin;
            inputs[5] = verticalOrigin;
            inputs[6] = defaultOffset;

            return inputs;
        }

        public static string ReturnButtonName(object sender) 
        {
            string buttonName = "";

            if (sender != null)
            {                
                if (sender is Button clickedButton)
                {
                    buttonName = clickedButton.Name;
                }                
                else if (sender is RadioButton toggledButton)
                {
                    buttonName = toggledButton.Name;
                }

                return buttonName;
            }

            return "";
            
        }

        public static string SetAlignmentLabel(Position.Placement placement)
        {
            switch (placement)
            {
                case Position.Placement.AlignUpperLeft:
                    return "Align Top Left";

                case Position.Placement.AlignUpper:
                    return "Align Top";

                case Position.Placement.AlignUpperRight:
                    return "Align Top Right";

                case Position.Placement.AlignLeft:
                    return "Align Left";

                case Position.Placement.AlignCenter:
                    return "Align Center";

                case Position.Placement.AlignRight:
                    return "Align Right";

                case Position.Placement.AlignLowerLeft:
                    return "Align Bottom Left";

                case Position.Placement.AlignLower:
                    return "Align Bottom";

                case Position.Placement.AlignLowerRight:
                    return "Align Bottom Right";

                case Position.Placement.CustomAlignment:
                    return "Custom Alignment";
                default:
                    return "Align";
            }                       
        }  
        
        public static double[] StockCheck(double[] dimensions)
        {
            double maxWidth = 3200;
            double maxHeight = 2030;           

            if (dimensions[0] > maxWidth)             
                dimensions[0] = maxWidth;             

            if (dimensions[1] > maxHeight)            
                dimensions[1] = maxHeight;           
                     
            return dimensions;

        }        
    }
}
