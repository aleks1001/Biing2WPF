using Biing2WPF.Biing2;
using System.ComponentModel;

namespace Biing2WPF.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public EmployeeViewModel(Employee e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
