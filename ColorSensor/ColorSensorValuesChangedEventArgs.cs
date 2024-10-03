using System.Windows;

namespace ColorSensor
{
    public class ColorSensorValuesChangedEventArgs : RoutedEventArgs
    {
        public int RedValue { get; set; }
        public int GreenValue { get; set; }
        public int BlueValue { get; set; }
        public int WhiteValue { get; set; }

        public ColorSensorValuesChangedEventArgs()
        {
        }

        public ColorSensorValuesChangedEventArgs(RoutedEvent routedEvent) : base(routedEvent)
        {
        }

        public ColorSensorValuesChangedEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source)
        {
        }
    }
}
