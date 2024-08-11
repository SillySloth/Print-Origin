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
            if (window != null)
                window.Close();
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

        public static double[] CollectDimensions(TextBox stockWidthTextBox, TextBox stockHeightTextBox, TextBox printWidthTextBox, TextBox printHeightTextBox, TextBox horizontalTextBox, TextBox verticalTextBox)
        {
            double stockWidth = ParseTextBox(stockWidthTextBox);
            double stockHeight = ParseTextBox(stockHeightTextBox);
            double printWidth = ParseTextBox(printWidthTextBox);
            double printHeight = ParseTextBox(printHeightTextBox);
            double horizontalOrigin = ParseTextBox(horizontalTextBox);
            double verticalOrigin = ParseTextBox(verticalTextBox);

            double[] inputs = new double[6];
            inputs[0] = stockWidth;
            inputs[1] = stockHeight;
            inputs[2] = printWidth;
            inputs[3] = printHeight;
            inputs[4] = horizontalOrigin;
            inputs[5] = verticalOrigin;

            return inputs;
        }
    }
}
