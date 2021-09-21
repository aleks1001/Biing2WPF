using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using MyBiing2.Models;
using MyBiing2.Repository;

namespace MyBiing2.Tourists
{
    public class TouristsListViewModel : BindableBase
    {
        private int _HotelId;
        
        public Biing2 b { get; set; }

        public ObservableCollection<Tourist> Tourists { get; } = new();

        public TouristsListViewModel(Biing2 b)
        {
            this.b = b;
        }

        public ICollectionView MyTourists
        {
            get
            {
                ICollectionView source = CollectionViewSource.GetDefaultView(Tourists);
                source.Filter = p => Filter((Tourist)p);
                return source;
            }
        }

        public bool Filter(Tourist t)
        {
            return t.HotelId == HotelId;
        }

        public int HotelId
        {
            get => _HotelId;
            set
            {
                SetProperty(ref _HotelId, value);
                MyTourists.Refresh();
            }
        }

        public async void GetTouristsAsync()
        {
            var tourists = await b.GetTouristsAsync();
            for (var i = 1; i <= tourists.Length; i++)
            {
                Tourists.Add(new Tourist(i, b));
            }
        }
    }
}
