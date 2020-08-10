using Biing2WPF.Biing2;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace Biing2WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        bool isActiveOnlyTourists;
        bool isActiveOnlyEmployees;
        public event PropertyChangedEventHandler PropertyChanged;
        public Biing2.Biing2 Biing2 { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Tourist> Tourists { get; set; }
        public bool IsActiveOnlyTourists
        {
            get
            {
                return isActiveOnlyTourists;
            }
            set
            {
                isActiveOnlyTourists = value;
                OnPropertyChanged();
                GetTourists();
            }
        }
        public bool IsActiveOnlyEmployees
        {
            get
            {
                return isActiveOnlyEmployees;
            }
            set
            {
                isActiveOnlyEmployees = value;
                OnPropertyChanged();
                GetEmployees();
            }
        }
        public MainViewModel(Biing2.Biing2 biing2)
        {
            Biing2 = biing2;
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            timer.Tick += OnTimerTick;
            timer.Start();
            GetEmployees();
            GetTourists();
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            GetEmployees();
            GetTourists();
        }
        public void GetTourists()
        {
            var list = IsActiveOnlyTourists ? Biing2.GetTourists().FindAll(t => t.HotelId != 0xFF) : Biing2.GetTourists();
            Tourists = new ObservableCollection<Tourist>(list);
            OnPropertyChanged("Tourists");
        }
        public void GetEmployees()
        {
            var list = IsActiveOnlyEmployees ? Biing2.GetEmployees().FindAll(e => e.HotelId != 0xFF) : Biing2.GetEmployees();
            Employees = new ObservableCollection<Employee>(list);
            OnPropertyChanged("Employees");
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
