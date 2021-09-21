using BMF.Readers;
using BMF.Services;
using System.Threading.Tasks;
using MyBiing2.Repository;
using BMF.Structs;

namespace MyBiing2.Models
{
    public class Item: BindableBase
    {
        private string name;
        private int itemId;

        public Item(int index, MemoryItem item, Biing2 b)
        {
            ItemId = index;
            Name = b.GetTextByIndex(item.name);
            NameId = item.name;
            PicId = item.picId;
            Prop10 = item.prop10;
            Prop11 = item.prop11;
            Prop12 = item.prop12;
            Prop13 = item.prop13;

            UseRateHealth1 = item.useRateHealth1;
            UseRateHealth2 = item.useRateHealth2;
        }

        public int ItemId
        {
            get => itemId;
            set => SetProperty(ref itemId, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public int NameId { get; set; }

        public int PicId { get; set; }

        public int Prop10 { get; set; }
        public int Prop11 { get; set; }
        public int Prop12 { get; set; }
        public int Prop13 { get; set; }

        public int UseRateHealth1 { get; set; }
        public int UseRateHealth2 { get; set; }
    }
}
