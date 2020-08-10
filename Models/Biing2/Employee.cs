using Biing2WPF.Biing2.MemoryObjects;
using System;
using System.Runtime.InteropServices;

namespace Biing2WPF.Biing2
{
    public class Employee
    {
        private int index;
        private MemoryEmployee eStruct;

        public Employee(int index, MemoryEmployee entity)
        {
            this.index = index;
            this.eStruct = entity;
        }

        public int Id { get => (int)index; set { } }
        public Gender Gender { get => eStruct.isFemale == 1 ? Gender.Female : Gender.Male; set { } }
        public int IQ { get => eStruct.IQ; set { } }
        public int Height { get => eStruct.height; set { } }
        public int Weight { get => eStruct.weight; set { } }
        public int Age { get => eStruct.age; set { } }
        public int HotelId { get => eStruct.hotelId; set { } }
        public int Happiness { get => eStruct.happiness; set { } }
        public Profession Profession1 { get => (Profession)eStruct.profession1; set { } }
        public int Exp1 { get => (int)eStruct.exp1; set { } }
        public Profession Profession2 { get => (Profession)eStruct.profession2; set { } }
        public int Exp2 { get => (int)eStruct.exp2; set { } }
        public Profession Profession3 { get => (Profession)eStruct.profession3; set { } }
        public int Exp3 { get => (int)eStruct.exp3; set { } }
        public bool IsIndepenent { get => eStruct.isIndependent; set { } }
        //public string FullName { get => Enity.ReadText(eStruct.nameIndex); set { } }
       // public string Motto { get => Enity.ReadText(eStruct.mottoIndex); set { } }
        //public string Saying { get => Enity.ReadText(eStruct.sayingIndex); set { } }
        public bool IsNaked { get => eStruct.isNaked; set { } }
    }
}
