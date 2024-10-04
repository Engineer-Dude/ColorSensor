using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ColorSensor
{
    public class ColorSensorControl : Control
    {
        public bool ShowValue
        {
            get { return (bool)GetValue(ShowValueProperty); }
            set { SetValue(ShowValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowValueProperty =
            DependencyProperty.Register("ShowValue", typeof(bool), typeof(ColorSensorControl), new PropertyMetadata(true));

        public delegate void ColorSensorValuesChangedEventHandler(object sender, ColorSensorValuesChangedEventArgs e);

        public static RoutedEvent ColorSensorValuesChangedEvent = EventManager.RegisterRoutedEvent(
            name: "ColorSensorValuesChanged",
            routingStrategy: RoutingStrategy.Bubble,
            handlerType: typeof(ColorSensorValuesChangedEventHandler),
            ownerType: typeof(ColorSensorControl));

        public event ColorSensorValuesChangedEventHandler ColorSensorValuesChanged
        {
            add { AddHandler(ColorSensorValuesChangedEvent, value); }
            remove { RemoveHandler(ColorSensorValuesChangedEvent, value); }
        }

        static ColorSensorControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSensorControl), new FrameworkPropertyMetadata(typeof(ColorSensorControl)));
        }

        TextBlock redValueTextBlock = new();
        TextBlock greenValueTextBlock = new();
        TextBlock blueValueTextBlock = new();
        TextBlock whiteValueTextBlock = new();

        public override void OnApplyTemplate()
        {
            redValueTextBlock = Template.FindName("PART_RedValue", this) as TextBlock ?? new TextBlock();
            greenValueTextBlock = Template.FindName("PART_GreenValue", this) as TextBlock ?? new TextBlock();
            blueValueTextBlock = Template.FindName("PART_BlueValue", this) as TextBlock ?? new TextBlock();
            whiteValueTextBlock = Template.FindName("PART_WhiteValue", this) as TextBlock ?? new TextBlock();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(hours: 0, minutes: 0, seconds: 1);
            timer.Tick += (s, e) =>
            {
                DateTime now = DateTime.Now;
                OnColorSensorValuesChanged(
                redValue: now.Second, greenValue: now.Second, blueValue: now.Second, whiteValue: now.Second);
            };
            timer.Start();

            // Alternate way to implement Binding (compared to using TemplateBinding)

            //Binding showValueBinding = new Binding
            //{
            //    Path = new PropertyPath(nameof(ShowValue)),
            //    Source = this,
            //    Converter = new BooleanToVisibilityConverter()
            //};

            //redValue.SetBinding(VisibilityProperty, showValueBinding);
            //greenValue.SetBinding(VisibilityProperty, showValueBinding);
            //blueValue.SetBinding(VisibilityProperty, showValueBinding);
            //whiteValue.SetBinding(VisibilityProperty, showValueBinding);

            base.OnApplyTemplate();
        }

        protected void OnColorSensorValuesChanged(int redValue, int greenValue, int blueValue, int whiteValue)
        {
            UpdateColorSensorValues(redValue, greenValue, blueValue, whiteValue);

            UpdateColorSensorIndicators(redValue, greenValue, blueValue, whiteValue);

            RaiseEvent(new ColorSensorValuesChangedEventArgs(routedEvent: ColorSensorValuesChangedEvent, source: this)
            { RedValue = redValue, GreenValue = greenValue, BlueValue = blueValue, WhiteValue = whiteValue });
        }

        private void UpdateColorSensorIndicators(int redValue, int greenValue, int blueValue, int whiteValue)
        {
            if (redValue > 30)
            {
                VisualStateManager.GoToState(control: this, stateName: "RedIndicatorOn", useTransitions: true);
            }
            else
            {
                VisualStateManager.GoToState(control: this, stateName: "RedIndicatorOff", useTransitions: true);
            }
        }

        private void UpdateColorSensorValues(int redValue, int greenValue, int blueValue, int whiteValue)
        {
            redValueTextBlock.Text = redValue.ToString();
            greenValueTextBlock.Text = greenValue.ToString();
            blueValueTextBlock.Text = blueValue.ToString();
            whiteValueTextBlock.Text = whiteValue.ToString();
        }
    }
}
