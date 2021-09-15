using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using MyBiing2.Models;
using MyBiing2.Repository;

namespace MyBiing2.Employees
{
    public class EmployeesListViewModel : BindableBase
    {
        private int _HotelId;

        public Biing2 Biing2 { get; set; }
        public EmployeesListViewModel(Biing2 b)
        {
            Biing2 = b;
            Employees = new ObservableCollection<Employee>(b.GetEmployees());
        }

        public ICollectionView MyEmployees
        {
            get
            {
                ICollectionView source = CollectionViewSource.GetDefaultView(Employees);
                source.Filter = p => Filter((Employee)p);
                return source;
            }
        }

        public bool Filter(Employee e)
        {
            return e.HotelId == HotelId;
        }

        public ObservableCollection<Employee> Employees { get; set; }
        public int HotelId
        {
            get => _HotelId;
            set
            {
                SetProperty(ref _HotelId, value);
                MyEmployees.Refresh();
            }
        }
    }
}