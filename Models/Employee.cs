using BMF.Main;
using BMF.Readers;
using BMF.Structs;
using MyBiing2.Repository;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyBiing2.Models
{
    public class Employee : MemoryStruct, INotifyPropertyChanged
    {
        #region private properties
        private Gender gender;
        private int iq;
        private int height;
        private int weight;
        private int age;
        private int hotelId;
        private int jobPostingId;
        private int buildingId;
        private int happiness;
        private Profession prof1;
        private int exp1;
        private Profession prof2;
        private int exp2;
        private Profession prof3;
        private int exp3;
        private bool isNaked;
        private bool isIndependent;
        private int picId1;
        private int picId2;
        private bool isActive;
        private string name;
        #endregion
        #region constructor
        public Employee(int index, uint pHandle, uint baseAddress)
            :base(index, pHandle, baseAddress)
        {
        }
        #endregion
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
        public int JobPostingId
        {
            get => jobPostingId;
            set
            {
                if (value == jobPostingId)
                {
                    return;
                }
                jobPostingId = value;
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
        public int Happiness
        {
            get => happiness;
            set
            {
                if (value == happiness)
                {
                    return;
                }
                happiness = value;
                OnPropertyChanged();
            }
        }
        public bool IsIndepenent
        {
            get => isIndependent;
            set
            {
                if (value == isIndependent)
                {
                    return;
                }
                isIndependent = value;
                Memory.Write(pHandle, baseAddress + 0x2c, (byte)(value ? 0xFF : 0x0));
                OnPropertyChanged();
            }
        }
        public bool IsNaked
        {
            get => isNaked;
            set
            {
                if (value == isNaked)
                {
                    return;
                }
                isNaked = value;
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
        public Profession Profession1 { 
            get => prof1; 
            set
            {
                if (value == prof1)
                {
                    return;
                }
                prof1 = value;
                Memory.Write(pHandle, baseAddress + 0x1, (byte)value);
                OnPropertyChanged();
            }
        }
        public int Exp1
        {
            get => exp1; 
            set
            {
                if (value == exp1)
                {
                    return;
                }
                exp1 = value;
                Memory.Write(pHandle, baseAddress + 0x56, (uint)value);
                OnPropertyChanged();
            }
        }
        public Profession Profession2 { 
            get => prof2;
            set
            {
                if (value == prof2)
                {
                    return;
                }
                prof2 = value;
                Memory.Write(pHandle, baseAddress + 0x2, (byte)value);
                OnPropertyChanged();
            }
        }
        public int Exp2
        {
            get => exp2;
            set
            {
                if (value == exp2)
                {
                    return;
                }
                exp2 = value;
                Memory.Write(pHandle, baseAddress + 0x5A, (uint)value);
                OnPropertyChanged();
            }
        }
        public Profession Profession3 { 
            get => prof3;
            set
            {
                if (value == prof3)
                {
                    return;
                }
                prof3 = value;
                Memory.Write(pHandle, baseAddress + 0x3, (byte)value);
                OnPropertyChanged();
            }
        }
        public int Exp3
        {
            get => exp3;
            set
            {
                if (value == exp3)
                {
                    return;
                }
                exp3 = value;
                Memory.Write(pHandle, baseAddress + 0x5E, (uint)value);
                OnPropertyChanged();
            }
        }
        public int Pic1
        {
            get => picId1;
            set
            {
                if (value == picId1)
                {
                    return;
                }
                picId1 = value;
                OnPropertyChanged();
            }
        }
        public int Pic2
        {
            get => picId2;
            set
            {
                if (value == picId2)
                {
                    return;
                }
                picId2 = value;
                OnPropertyChanged();
            }
        }
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
            MemoryEmployee e = EmployeeReader.GetMemoryEmployee(pHandle, baseAddress, Index);
            Profession1 = (Profession)e.profession1;
            Profession2 = (Profession)e.profession2;
            Profession3 = (Profession)e.profession3;
            Exp1 = (int)e.exp1;
            Exp2 = (int)e.exp2;
            Exp3 = (int)e.exp3;
            Gender = e.isFemale == 0x1 ? Gender.Female : Gender.Male;
            Height = e.height;
            Weight = e.weight;
            IQ = e.IQ;
            Age = e.age;
            HotelId = e.hotelId;
            JobPostingId = e.jobPostingId;
            BuildingId = e.buildingId;
            Happiness = e.happiness;
            IsNaked = e.isNaked == 0xFF;
            Pic1 = e.pictureId;
            Pic2 = e.pictureNakedId;
            IsIndepenent = e.isIndependent == 0xFF;
            IsActive = e.hotelId != 0xFF;
            Name = StringReader.GetStringTextByIndex(pHandle, baseAddress, e.name);
        }
    }
}
