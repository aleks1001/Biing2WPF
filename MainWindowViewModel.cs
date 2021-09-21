using MyBiing2.Repository;
using MyBiing2.Employees;
using MyBiing2.Tourists;
using MyBiing2.Hotels;
using System;
using System.Windows.Input;
using MyBiing2.Items;

namespace MyBiing2
{
    public class MainWindowViewModel : BindableBase
    {
        private Biing2 repo;
        private string _textIndex;
        private string _discoveredText;

        private readonly EmployeesListViewModel employeesListViewModel;
        private readonly TouristsListViewModel touristsListViewModel;
        private readonly ItemsListViewModel itemsListViewModel;

        private BindableBase _currentViewModel;
        public MainWindowViewModel(Biing2 b)
        {
            repo = b;
            employeesListViewModel = new EmployeesListViewModel(b);
            touristsListViewModel = new TouristsListViewModel(b);
            itemsListViewModel = new ItemsListViewModel(b);
            HotelListViewModel = new HotelListViewModel(b);

            NavCommand = new RelayCommand<string>(OnNav);
            GetTextCommand = new RelayCommand<string>(onTextSearch);
            HotelListViewModel.UpdateHotelClicked += OnHotelChanged;
        }


        private void OnHotelChanged(int hotelId)
        {
            employeesListViewModel.HotelId = hotelId;
            touristsListViewModel.HotelId = hotelId;
        }

        public HotelListViewModel HotelListViewModel { get; set; }

        public BindableBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public string TextIndex
        {
            get => _textIndex;
            set => SetProperty(ref _textIndex, value);

        }
        public string DiscoveredText
        {
            get => _discoveredText;
            set => SetProperty(ref _discoveredText, value);
        }

        public RelayCommand<string> NavCommand { get; private set; }
        public RelayCommand<string> GetTextCommand { get; set; }

        private void OnNav(string d)
        {
            CurrentViewModel = d switch
            {
                "employees" => employeesListViewModel,
                "tourists" => touristsListViewModel,
                "items" => itemsListViewModel,
                _ => employeesListViewModel,
            };
        }

        private void onTextSearch(string textIdx)
        {
            if (textIdx == null)
            {
                return;
            }

            DiscoveredText = repo.GetTextByIndex(int.Parse(textIdx));
            TextIndex = string.Empty;
        }

    }
}
