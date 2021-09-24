using BMF.Readers;
using MyBiing2.Repository;
using System.Threading.Tasks;
using BMF.Structs;

namespace MyBiing2.Models
{
    public class GameBuilding : BindableBase
    {
        private string name;
        private string desc;
        private int index;
        private int roomSizeIndex;
        private int roomSizeMultiplier;
        private string rentSuccessMsg;
        private string buySuccessMsg;

        public GameBuilding(int index, MemoryGameBuilding build, Biing2 b)
        {
            Index = index;
            Name = b.GetTextByIndex(build.name);
            Desc = b.GetTextByIndex(build.description);
            RoomSizeIndex = build.roomSizeIndex;
            RoomSizeMultiplier = build.roomSizeMultiplier;
            RentMsg = b.GetTextByIndex(build.rentSuccessMsg);
            BuyMsg = b.GetTextByIndex(build.buySuccessMsg);
        }

        public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Desc
        {
            get => desc;
            set => SetProperty(ref desc, value);
        }

        public int RoomSizeIndex
        {
            get => roomSizeIndex;
            set => SetProperty(ref roomSizeIndex, value);
        }

        public int RoomSizeMultiplier
        {
            get => roomSizeMultiplier;
            set => SetProperty(ref roomSizeMultiplier, value);
        }

        public string RentMsg
        {
            get => rentSuccessMsg;
            set => SetProperty(ref rentSuccessMsg, value);
        }

        public string BuyMsg
        {
            get => buySuccessMsg;
            set => SetProperty(ref buySuccessMsg, value);
        }
    }
}
