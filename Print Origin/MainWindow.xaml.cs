using Print_Origin.Model;
using System.Windows;
using System.Windows.Input;
using static Print_Origin.Model.Utilities;
namespace Print_Origin
{    
    public partial class MainWindow : Window
    {       

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

        public void SetPosition_Click(object sender, RoutedEventArgs e)
        {                               
            if (Enum.TryParse(ReturnButtonName(sender), out Position.Placement placement))
            {
                Parameters parameters = Parameters.UpdateParameters(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, DefaultOffsetTextBox, placement);

                var textBoxGroup = new Update.TextBoxGroup(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, MarginTopTextBox, MarginLeftTextBox, MarginRightTextBox, MarginBottomTextBox);
                var alignmentDetails = new Update.AlignmentDetails(AlignmentLabel, placement);
                var update = new Update(textBoxGroup, alignmentDetails);

                update.UpdateUI(parameters, drawingCanvas);
            }
            else
            {
                MessageBox.Show("Unable to set alignment");
            }
        }

    }

}
