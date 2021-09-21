using System.Collections;
using System.Linq;
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

        public Biing2 b { get; set; }

        public EmployeesListViewModel(Biing2 b)
        {
            this.b = b;
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

        public ObservableCollection<Employee> Employees { get; } = new();

        public int HotelId
        {
            get => _HotelId;
            set
            {
                SetProperty(ref _HotelId, value);
                MyEmployees.Refresh();
            }
        }

        public async void GetEmployeesAsync()
        {
            var employees = await b.GetEmployeesAsync();
            for (var i = 1; i <= employees.Length; i++)
            {
                Employees.Add(new Employee(i, b));
            }
        }
    }
}