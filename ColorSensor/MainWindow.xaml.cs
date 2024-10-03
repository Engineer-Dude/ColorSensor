using System.Windows;

namespace ColorSensor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ColorSensorControl_ColorSensorValuesChanged(object sender, ColorSensorValuesChangedEventArgs e)
        {
            RedValue.Text = e.RedValue.ToString();
        }
    }
}