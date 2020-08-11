using Biing2WPF.Biing2.MemoryReaders;
using System.Collections.Generic;

namespace Biing2WPF.Biing2
{
    public class Biing2
    {
        public readonly uint baseAddress;
        public readonly uint pHandle;
        public HotelReader HotelReader { get; set; }
        public EmployeeReader EmployeeReader { get; set; }
        public TouristReader TouristReader { get; set; }

        public Biing2(uint pHandle, uint baseAddress)
        {
            this.pHandle = pHandle;
            this.baseAddress = baseAddress;

            HotelReader = new HotelReader(pHandle, baseAddress);
            EmployeeReader = new EmployeeReader(pHandle, baseAddress);
            TouristReader = new TouristReader(pHandle, baseAddress);

        }

        public List<Tourist> GetTourists()
        {
            return TouristReader.GetTourists();
        }
        public List<Employee> GetEmployees()
        {
            return EmployeeReader.GetEmployees();
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
