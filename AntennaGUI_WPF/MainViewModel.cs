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

        private Vibrator f_Antenna;
        public Vibrator Antenna
        {
            get { return f_Antenna; }
            set
            {
                f_Antenna = value;
                OnPropertyChanged("Antenna");
            }
        }

        private string f_Data;

        public string Data
        {
            get { return f_Data; }
            set
            {
                f_Data = value;
                OnPropertyChanged("Data");
            }
        }

    }
}
