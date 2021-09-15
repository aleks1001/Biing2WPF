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

        public ObservableCollection<Tourist> Tourists { get; set; }

        public TouristsListViewModel(Biing2 b)
        {
            Tourists = new ObservableCollection<Tourist>(b.GetTourists());
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
    }
}
