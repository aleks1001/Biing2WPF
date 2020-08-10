using Biing2WPF.Biing2.MemoryObjects;

namespace Biing2WPF.Biing2
{
    public class Tourist
    {
        private readonly int index;
        private MemoryTourist tStruct;

        public Tourist(int index, MemoryTourist entity)
        {
            this.index = index;
            this.tStruct = entity;
        }
        public int Id { get => index; set { } }
        public Gender Gender => tStruct.isFemale == 1 ? Gender.Female : Gender.Male;
        public int IQ { get => tStruct.IQ; set { } }
        public int Height { get => tStruct.height; set { } }
        public int Weight { get => tStruct.weight; set { } }
        public int Age { get => tStruct.age; set { } }
        // public string FullName { get => enity.ReadText(tStruct.name); set { } }
        // public string Country { get => enity.ReadText((uint)tStruct.flagId + 696); set { } }
        public int FlagId { get => tStruct.flagId; set { } }
        //public int FlagOffset { get => (int)enity.ReadImage(tStruct.flagId); set { } }
        public int HotelId { get => tStruct.hotelIndex; set { } }
    }
}
