using System.Threading.Tasks;
using BMF.Readers;
using BMF.Services;
using BMF.Structs;

namespace MyBiing2.Repository
{
    public class Biing2
    {
        private readonly IHotelRepository _hRepo;
        private readonly IEmployeeRepository _eRepo;
        private readonly ITouristRepository _tRepo;
        private readonly IItemRepository _iRepo;
        private readonly IObject50Repository _o50Repo;

        public readonly int baseAddress;
        public readonly int pHandle;

        public Biing2(int pHandle, int baseAddress)
        {
            this.pHandle = pHandle;
            this.baseAddress = baseAddress;
            _hRepo = new HotelRepository(pHandle, baseAddress);
            _eRepo = new EmployeeRepository(pHandle, baseAddress);
            _tRepo = new TouristRepository(pHandle, baseAddress);
            _iRepo = new ItemRepository(pHandle, baseAddress);
            _o50Repo = new Object50Repository(pHandle, baseAddress);
        }

        public IHotelRepository GetHotelRepo()
        {
            return _hRepo;
        }

        public IEmployeeRepository GetEmployeeRepo()
        {
            return _eRepo;
        }

        public ITouristRepository GetTouristRepo()
        {
            return _tRepo;
        }

        public IItemRepository GetItemsRepo()
        {
            return _iRepo;
        }

        public IObject50Repository GetObject50Repo()
        {
            return _o50Repo;
        }

        public Task<MemoryHotel[]> GetHotelsAsync()
        {
            return _hRepo.GetHotelsAsync();
        }

        public Task<MemoryEmployee[]> GetEmployeesAsync()
        {
            return _eRepo.GetEmployeesAsync();
        }

        public Task<MemoryTourist[]> GetTouristsAsync()
        {
            return _tRepo.GetTouristsAsync();
        }

        public Task<MemoryItem[]> GetItemsAsync()
        {
            return _iRepo.GetItemsAsync();
        }

        public Task<MemoryObject50[]> GetObjects50Async()
        {
            return _o50Repo.GetObjects50Async();
        }

        public string GetTextByIndex(int n)
        {
            return StringReader.GetStringTextByIndex(pHandle, baseAddress, n);
        }
    }

    public enum Gender
    {
        Male = 0xFF,
        Female = 0x00
    }

    public enum Profession
    {
        None = 0,
        Hostess = 1,
        Maid = 2,
        Animator = 3,
        StorageMan = 4,
        BunnyGirl = 5,
        Dominatrix = 6,
        Gigalo = 7,
        TrainerMale = 8,
        TrainerFemale = 9,
        BikiniGirl = 10,
        Porter = 11,
        SMGirl = 12,
        Nurse = 13,
        Cook = 14,
        Mechanic = 15,
    }
}
