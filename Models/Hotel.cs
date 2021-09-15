using BMF.Readers;
using BMF.Structs;
using BMF.Main;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyBiing2.Models
{
    public class Hotel : MemoryStruct, INotifyPropertyChanged
    {
        #region private members
        private string name;
        private int hotelId;
        private string money;
        #endregion
        #region constructor
        public Hotel(int index, uint pHandle, uint baseAddress)
            : base(index, pHandle, baseAddress)
        {

        }
        #endregion
        #region public memnber
        public string Name
        {
            get => name;
            set
            {
                if (value == name)
                {
                    return;
                }
                name = value;
                OnPropertyChanged();
            }
        }
        public int HotelId
        {
            get => hotelId;
            set
            {
                if (value == hotelId)
                {
                    return;
                }
                hotelId = value;
                OnPropertyChanged();
            }
        }
        public string Money
        {
            get => money;
            set
            {
                if (value == money)
                {
                    return;
                }
                money = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public override void OnRefresh(uint pHandle, uint baseAddress)
        {
            MemoryHotel hotel = HotelReader.GetMemoryHotel(pHandle, baseAddress, Index);
            Name = StringReader.GetStringTextByIndex(pHandle, baseAddress, Index + 900);
            HotelId = hotel.index;
            Money = "$"+hotel.money.ToString();
        }
    }
}
