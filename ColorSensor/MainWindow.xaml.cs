using System.ComponentModel;
using System.Windows;

namespace ColorSensor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool lightMode = false;
        public bool LightMode
        {
            get
            {
                return lightMode;
            }
            set
            {
                lightMode = value;
                OnPropertyChanged(nameof(LightMode));
            }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged = delegate { };

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ColorSensorControl_ColorSensorValuesChanged(object sender, ColorSensorValuesChangedEventArgs e)
        {
            RedValue.Text = e.RedValue.ToString();
        }

        private void LightModeButton_Click(object sender, RoutedEventArgs e)
        {
            LightMode = !LightMode;
        }
    }
}