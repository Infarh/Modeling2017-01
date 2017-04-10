using System;
using System.ComponentModel;
using Antennas;

namespace AntennaGUI_WPF
{
    class MainViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private Vibrator f_Antenna = new Vibrator(0.5);
        public Vibrator Antenna
        {
            get { return f_Antenna; }
            set
            {
                f_Antenna = value;
                OnPropertyChanged("Antenna");
            }
        }

        private double f_Length = 0.5;

        public double Length
        {
            get { return f_Length; }
            set
            {
                if(value <= 0 || value > 1) return;
                f_Length = value;
                OnPropertyChanged("Length");
                Antenna = new Vibrator(value);
            }
        }
    }
}
