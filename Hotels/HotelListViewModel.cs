using MyBiing2.Repository;
using System.Collections.ObjectModel;
using System;
using MyBiing2.Models;

namespace MyBiing2.Hotels
{
    public class HotelListViewModel : BindableBase
    {
        private Hotel _selectedHotel;

        public ObservableCollection<Hotel> Hotels { get; set; }
        public HotelListViewModel(Biing2 b)
        {
            Hotels = new ObservableCollection<Hotel>(b.GetHotels());
        }

        public event Action<int> UpdateHotelClicked = delegate { };

        public Hotel SelectedHotel
        {
            get { return _selectedHotel; }
            set {
                SetProperty(ref _selectedHotel, value);
                UpdateHotelClicked(value.HotelId);
            }
        }
    }
}
