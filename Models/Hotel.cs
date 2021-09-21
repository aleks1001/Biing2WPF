using BMF.Readers;
using BMF.Services;
using System.Threading.Tasks;
using MyBiing2.Repository;

namespace MyBiing2.Models
{
    public class Hotel : BindableBase
    {
        private string _name;
        private int _hotelId;
        private string money;

        public Hotel(int index, Biing2 b)
        {
            HotelId = index;
            _ = Start(index, b);
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int HotelId
        {
            get => _hotelId;
            set => SetProperty(ref _hotelId, value);
        }

        public string Money
        {
            get => money;
            set => SetProperty(ref money, value);
        }

        private Task<Task> Start(int index, Biing2 b)
        {
            IHotelRepository repo = b.GetHotelRepo();
            
            return Task.Factory.StartNew(async () =>
            {
                while (true)
                {

                    var h = await repo.GetHotelAsync(index);
                    Money = "$" + h.money;
                    Name = StringReader.GetStringTextByIndex(b.pHandle, b.baseAddress, index + 900);
                    await Task.Delay(500);
                }
            });
        }
    }
}
