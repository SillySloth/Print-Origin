using Print_Origin.Model;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
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

                var textBoxGroup = new Update.TextBoxGroup(StockWidthTextBox, StockHeightTextBox, PrintWidthTextBox, PrintHeightTextBox, HorizontalTextBox, VerticalTextBox, DefaultOffsetTextBox, MarginTop, MarginLeft, MarginRight, MarginBottom);
                var alignmentDetails = new Update.AlignmentDetails(AlignmentLabel, placement);
                var update = new Update(textBoxGroup, alignmentDetails);

                update.UpdateUI(parameters, drawingCanvas);
            }
            else
            {
                MessageBox.Show("Unable to set alignment");
            }
        }
        private void PushOriginPoints_Click(object sender, RoutedEventArgs e)
        {
            string pushScript = PushScriptTextBox.Text;

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pushScript,
                    UseShellExecute = true
                };

                Process.Start(startInfo);
            }
            catch (Exception ex){
                MessageBox.Show(
                    $"Failure to start script. \n\n" +
                    $"{ex.Message}", "Error - Unable to Push Print Parameters", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PullParameters_Click(object sender, RoutedEventArgs e)
        {
            string pullScript = PullScriptTextBox.Text;

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pullScript,
                    UseShellExecute = true
                };

                Process.Start(startInfo);
            }
            catch (Exception ex) {
                MessageBox.Show(
                    $"Failure to start script. \n\n" +
                    $"{ex.Message}", "Error - Unable to Pull Print Parameters", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        
        
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender is RadioButton radioButton)
                {                  
                    radioButton.IsChecked = true;                  
                    radioButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else if (sender is Button button) 
                {
                    button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
            }
        }

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {                        
            ComboBoxItem selectedItem = (ComboBoxItem)SheetSelect.SelectedItem;
                       
            string[] dimensions = selectedItem.Content.ToString().Split('x');

            // Trim any extra spaces and convert to integers
            int stockWidth = int.Parse(dimensions[0].Trim());
            int stockHeight = int.Parse(dimensions[1].Trim());    
            
            StockWidthTextBox.Text = stockWidth.ToString();
            StockHeightTextBox.Text = stockHeight.ToString();
            
        }



    }

}
