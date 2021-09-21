using MyBiing2.Repository;
using System.Collections.ObjectModel;
using System;
using MyBiing2.Models;

namespace MyBiing2.Hotels
{
    public class HotelListViewModel : BindableBase
    {
        private Hotel _selectedHotel;
        private readonly Biing2 b;

        public ObservableCollection<Hotel> Hotels { get; } = new();
        public HotelListViewModel(Biing2 b)
        {
            this.b = b;
        }

        public event Action<int> UpdateHotelClicked = delegate { };

        public Hotel SelectedHotel
        {
            get { return _selectedHotel; }
            set
            {
                SetProperty(ref _selectedHotel, value);
                UpdateHotelClicked(value.HotelId);
            }
        }

        public async void GetHotelsAsync()
        {
            var hotels = await b.GetHotelsAsync();
            foreach (var h in hotels)
            {
                Hotels.Add(new Hotel(h.index, b));
            }
        }
    }
}
