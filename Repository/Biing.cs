using System.Collections.Generic;
using BMF.Readers;
using MyBiing2.Models;

namespace MyBiing2.Repository
{
    public class Biing2
    {
        public readonly uint baseAddress;
        public readonly uint pHandle;

        public Biing2(uint pHandle, uint baseAddress)
        {
            this.pHandle = pHandle;
            this.baseAddress = baseAddress;
        }

        public List<Tourist> GetTourists()
        {
            List<Tourist> list = new();
            int tArraySize = TouristReader.tArraySize;
            for( int i = 1; i <= tArraySize; i++)
            {
                list.Add(new Tourist(i, pHandle, baseAddress));
            }
            return list;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> list = new();
            int eArraySize = EmployeeReader.eArraySize;
            for (int i = 1; i <= eArraySize; i++)
            {
                list.Add(new Employee(i, pHandle, baseAddress));
            }
            return list;
        }
        public List<Item> GetItems()
        {
            List<Item> list = new();
            uint iArraySize = ItemReader.iArraySize;
            for (int i = 1; i <= iArraySize; i++)
            {
                list.Add(new Item(i, pHandle, baseAddress));
            }
            return list;
        }
        public List<Hotel> GetHotels()
        {
            List<Hotel> list = new();
            uint hArraySize = HotelReader.hArraySize;
            for (int i = 0; i < hArraySize; i++)
            {
                list.Add(new Hotel(i, pHandle, baseAddress));
            }
            return list;
        }
        public string GetTextByIndex(int n)
        {
            return StringReader.GetStringTextByIndex(pHandle, baseAddress, n);
        }

        public Property GetProperyByIndex(int index)
        {
            uint pArraySize = PropertyReader.pArraySize;
            return new Property(index, pHandle, baseAddress);
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
