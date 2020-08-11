using Biing2WPF.Biing2.MemoryObjects;
using Biing2WPF.Biing2.MemoryReaders;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Biing2WPF.Biing2
{
    public class Tourist : MemoryObject, INotifyPropertyChanged
    {
        #region private members
        private Gender gender;
        private int iq;
        private int height;
        private int weight;
        private int age;
        private int hotelId;
        private bool isActive;
        #endregion
        public Tourist(uint index, uint pHandle, uint baseAddress, uint tSize) 
            : base(index, pHandle, baseAddress, tSize)
        {
        }
        #region public properties
        public int Id
        {
            get => (int)index;
        }
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
        public override void OnRefresh(uint pHandle, uint baseAddress, uint tSize)
        {
            var t = Serializer.Deserialize<MemoryTourist>(Memory.Read((int)pHandle, (int)baseAddress, tSize));
            Gender = t.isFemale == 1 ? Gender.Female : Gender.Male;
            IQ = t.IQ;
            Height = t.height;
            Weight = t.weight;
            Age = t.age;
            HotelId = t.hotelIndex;
            IsActive = t.hotelIndex != 0xFF;
        }
    }
}
