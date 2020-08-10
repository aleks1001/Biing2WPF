using Biing2WPF.Biing2;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Biing2WPF.ViewModels
{
    public class TouristViewModel : INotifyPropertyChanged
    {
        int iq;
        public event PropertyChangedEventHandler PropertyChanged;
        public TouristViewModel(Tourist t)
        {
            Id = t.Id;
            Gender = t.Gender;
            iq = t.IQ;
            HotelId = t.HotelId;
        }

        public int Id { get; set; }
        public Gender Gender { get; set; }
        public int IQ
        {
            get => iq;
            set
            {
                iq = value;
                OnPropertyChanged();
            }
        }
        public int HotelId { get; set; }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
