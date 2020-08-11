using Biing2WPF.Biing2;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Biing2WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Biing2.Biing2 biing2;
        bool isActiveOnlyTourists;
        bool isActiveOnlyEmployees;

        public event PropertyChangedEventHandler PropertyChanged;
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
            }
        }
        public MainViewModel(Biing2.Biing2 biing2)
        {
            this.biing2 = biing2;
            Employees = new ObservableCollection<Employee>(biing2.EmployeeReader.GetEmployees());
            Tourists = new ObservableCollection<Tourist>(biing2.TouristReader.GetTourists());
            //var employeeView = new CollectionViewSource { Source = employees }.View;
        }
        public void GetTourists()
        {
            //Employees = new ObservableCollection<Employee>(r.GetEmployees());
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
