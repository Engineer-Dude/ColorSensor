using System.Windows;
using System.Windows.Controls;

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

        static ColorSensorControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorSensorControl), new FrameworkPropertyMetadata(typeof(ColorSensorControl)));
        }

        public override void OnApplyTemplate()
        {
            TextBlock redValue = Template.FindName("PART_RedValue", this) as TextBlock ?? new TextBlock();
            TextBlock greenValue = Template.FindName("PART_GreenValue", this) as TextBlock ?? new TextBlock();
            TextBlock blueValue = Template.FindName("PART_BlueValue", this) as TextBlock ?? new TextBlock();
            TextBlock whiteValue = Template.FindName("PART_WhiteValue", this) as TextBlock ?? new TextBlock();

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
    }
}
