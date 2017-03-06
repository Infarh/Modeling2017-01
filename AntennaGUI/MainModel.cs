using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;
using System.Windows.Data;
using System.Windows.Input;

namespace Antennas.GUI
{
    internal class MainModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        /// <summary>Событие, возникающие при изменении значения свойства</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Генерация события изменения значения свойства</summary>
        /// <param name="PropertyName">Имя свойства</param>
        //[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string PropertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

        #endregion

        private readonly ObservableCollection<Complex> f_Values = new ObservableCollection<Complex>();
        public ICollectionView Values { get; }

        private const double toRad = Math.PI / 180;

        private double f_dx = 1 * toRad;
        public double dx
        {
            get { return f_dx; }
            set
            {
                if(f_dx.Equals(value)) return;
                f_dx = value;
                OnPropertyChanged();
            }
        }

        private int f_N = 360;
        public int N
        {
            get { return f_N; }
            set
            {
                if(f_N.Equals(value)) return;
                f_N = value;
                OnPropertyChanged();
            }
        }

        public ICommand Update { get; }

        public MainModel()
        {
            Values = CollectionViewSource.GetDefaultView(f_Values);

            Update = new LambdaCommand(OnUpdate, CanUpdate);
            OnUpdate();
        }

        private static double f(double x) => Math.Sin(x);

        private double f_x0 = 0;
        private void OnUpdate(object Obj = null)
        {
            f_Values.Clear();
            var dx = f_dx;
            for (int i = 0, n = f_N; i < n; i++)
            {
                var x = i * dx + f_x0;
                f_Values.Add(new Complex(x, f(x)));
            }
            f_x0 += 1 * toRad;
        }

        private bool CanUpdate(object Arg) => true;
    }
}
