using Print_Origin.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using static Print_Origin.Model.Utilities;
namespace Print_Origin
{    
    public partial class MainWindow : Window
    {
        private readonly Update updateInstance = new Update();

        public MainWindow()
        {
            InitializeComponent();            
        }

        #region Window Controls
        public void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow(this);
        }
        public void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            MinimizeWindow(this);
        }
        public void DragWindow(object sender, MouseButtonEventArgs e)
        {
            ClickDrag(this, e);
        }
        #endregion

        public void SetCustom_Click(object sender, RoutedEventArgs e)
        {           
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.Custom, drawingCanvas);
        }

        public void SetUpperLeft_Click(object sender, RoutedEventArgs e)
        {           
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.UpperLeft, drawingCanvas);            
        }

        public void SetUpper_Click(object sender, RoutedEventArgs e)
        {
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.Upper, drawingCanvas);
        }

        public void SetUpperRight_Click(object sender, RoutedEventArgs e)
        {
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.UpperRight, drawingCanvas);
        }

        public void SetLeft_Click(object sender, RoutedEventArgs e)
        {
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.Left, drawingCanvas);
        }

        public void SetCenter_Click(object sender, RoutedEventArgs e)
        {
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.Center, drawingCanvas);
        }

        public void SetRight_Click(object sender, RoutedEventArgs e)
        {
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.Right, drawingCanvas);
        }

        public void SetLowerLeft_Click(object sender, RoutedEventArgs e)
        {
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.LowerLeft, drawingCanvas);
        }
        public void SetLower_Click(object sender, RoutedEventArgs e)
        {
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.Lower, drawingCanvas);
        }
        public void SetLowerRight_Click(object sender, RoutedEventArgs e)
        {
            updateInstance.UpdateCanvas(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, GapUpper, GapLeft, GapRight, GapLower, Position.Placement.LowerRight, drawingCanvas);
        }


    }
}
