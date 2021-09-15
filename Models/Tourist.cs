using BMF.Main;
using BMF.Readers;
using BMF.Structs;
using MyBiing2.Repository;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyBiing2.Models
{
    public class Tourist : MemoryStruct, INotifyPropertyChanged
    {
        #region private members
        private Gender gender;
        private int hotelId;
        private int buildingId;
        private int iq;
        private int height;
        private int weight;
        private int age;
        private string fullName;
        private bool isActive;
        #endregion
        public Tourist(int index, uint pHandle, uint baseAddress)
            : base(index, pHandle, baseAddress)
        {
        }
        #region public properties
        public Gender Gender
        {
            get => gender;
            set
            {
                if (value == gender)
                {
                    return;
                }
                gender = value;
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
        public int BuildingId
        {
            get => buildingId;
            set
            {
                if (value == buildingId)
                {
                    return;
                }
                buildingId = value;
                OnPropertyChanged();
            }
        }
        public int IQ
        {
            get => iq;
            set
            {
                if (value == iq)
                {
                    return;
                }
                iq = value;
                OnPropertyChanged();
            }
        }
        public int Height
        {
            get => height;
            set
            {
                if (value == height)
                {
                    return;
                }
                height = value;
                OnPropertyChanged();
            }
        }
        public int Weight
        {
            get => weight;
            set
            {
                if (value == weight)
                {
                    return;
                }
                weight = value;
                OnPropertyChanged();
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (value == age)
                {
                    return;
                }
                age = value;
                OnPropertyChanged();
            }
        }
        public string FullName
        {
            get => fullName;
            set
            {
                if (value == fullName)
                {
                    return;
                }
                fullName = value;
                OnPropertyChanged();
            }
        }
        public bool IsActive
        {
            get => isActive;
            set
            {
                if (value == isActive)
                {
                    return;
                }
                isActive = value;
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
            MemoryTourist t = TouristReader.GetMemoryTourist(pHandle, baseAddress, Index);
            Gender = t.isFemale ? Gender.Female : Gender.Male;
            HotelId = t.hotelIndex;
            BuildingId = t.buildingId;
            IQ = t.IQ;
            Height = t.height;
            Weight = t.weight;
            Age = t.age;
            FullName = StringReader.GetStringTextByIndex(pHandle, baseAddress, t.name);
            IsActive = t.hotelIndex != 0xFF;
        }
    }
}
