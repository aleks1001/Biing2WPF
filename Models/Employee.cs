using BMF.Readers;
using MyBiing2.Repository;
using System.Threading.Tasks;

namespace MyBiing2.Models
{
    public class Employee : BindableBase
    {
        private int employeeId;
        private int buildingId;
        private int hotelId;
        private string fullName;

        public int HotelId
        {
            get => hotelId;
            set => SetProperty(ref hotelId, value);
        }

        public string FullName
        {
            get => fullName;
            set => SetProperty(ref fullName, value);
        }

        public int EmployeeId
        {
            get => employeeId;
            set => SetProperty(ref employeeId, value);
        }

        public int BuildingId
        {
            get => buildingId;
            set => SetProperty(ref buildingId, value);
        }

        public Employee(int index, Biing2 b)
        {
            EmployeeId = index;
            _ = Start(index, b);
        }

        private Task<Task> Start(int index, Biing2 b)
        {
            var repo = b.GetEmployeeRepo();

            return Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    var e = await repo.GetEmployeeAsync(index);
                    BuildingId = e.buildingId;
                    HotelId = e.hotelId;
                    FullName = StringReader.GetStringTextByIndex(b.pHandle, b.baseAddress, e.name);
                    await Task.Delay(500);
                }
            });
        }
    }
}
