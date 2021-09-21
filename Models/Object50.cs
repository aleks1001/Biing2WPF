using BMF.Services;
using System.Threading.Tasks;
using MyBiing2.Repository;
using BMF.Readers;

namespace MyBiing2.Models
{
    public class Object50: BindableBase
    {
        private int on;
        private int field1;
        private int field2;
        private int field3;
        private int field8;
        private string hotelName;

        public Object50(int index, Biing2 b)
        {
            Index = index;
            _ = Start(index, b);
        }

        public int Index { get; set; }

        public int On
        {
            get => on;
            set => SetProperty(ref on, value);
        }

        public int Field1
        {
            get => field1;
            set => SetProperty(ref field1, value);
        }

        public int Field2
        {
            get => field2;
            set => SetProperty(ref field2, value);
        }

        public int Field3
        {
            get => field3;
            set => SetProperty(ref field3, value);
        }

        public string HotelName
        {
            get => hotelName;
            set => SetProperty(ref hotelName, value);
        }

        public int Field8
        {
            get => field8;
            set => SetProperty(ref field8, value);
        }

        private Task<Task> Start(int index, Biing2 b)
        {
            IObject50Repository repo = b.GetObject50Repo();

            return Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var o = await repo.GetObject50Async(index);
                    On = o.on_off;
                    Field1 = o.field1;
                    Field2 = o.field2;
                    Field3 = o.field3;
                    Field8 = o.field8;
                    HotelName = StringReader.GetStringTextByIndex(b.pHandle, b.baseAddress, o.index + 900);
                    await Task.Delay(500);
                }
            });
        }
    }
}
