using Biing2WPF.Biing2.MemoryObjects;
using Biing2WPF.Biing2.MemoryReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Biing2WPF.Biing2
{
    public class Biing2
    {
        readonly uint baseAddress;
        readonly uint pHandle;
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

        public void GetEmp()
        {
            var list = EmployeeReader.ResolveAll<MemoryEmployee>();
            var one = EmployeeReader.ResolveOne<MemoryEmployee>(13);
        }

        public List<Tourist> GetTourists()
        {
            return TouristReader.ResolveAll<MemoryTourist>().Select((t, i) => new Tourist(i + 1, t)).ToList();
        }

        public List<Employee> GetEmployees()
        {
            var list = EmployeeReader.Items;
            if (list.Count > 0)
            {
                return EmployeeReader.Items.Select((e, i) => new Employee(i + 1, e)).ToList();
            }
            return new List<Employee>();
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
