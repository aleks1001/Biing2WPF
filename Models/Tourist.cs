using BMF.Readers;
using BMF.Services;
using System.Threading.Tasks;
using MyBiing2.Repository;

namespace MyBiing2.Models
{
    public class Tourist : BindableBase
    {
        private int touristId;
        private int hotelId;
        private string fullName;

        public Tourist(int index, Biing2 b)
        {
            TouristId = index;
            _ = Start(index, b);
        }

        public string FullName
        {
            get => fullName;
            set => SetProperty(ref fullName, value);
        }

        public int HotelId
        {
            get => hotelId;
            set => SetProperty(ref hotelId, value);
        }

        public int TouristId
        {
            get => touristId;
            set => SetProperty(ref touristId, value);
        }

        private Task<Task> Start(int index, Biing2 b)
        {
            ITouristRepository repo = b.GetTouristRepo();

            return Task.Factory.StartNew(async () =>
            {
                while (true)
                {

                    var t = await repo.GetTouristAsync(index);
                    FullName = StringReader.GetStringTextByIndex(b.pHandle, b.baseAddress, t.name);
                    HotelId = t.hotelIndex;
                    await Task.Delay(500);
                }
            });
        }
    }
}
