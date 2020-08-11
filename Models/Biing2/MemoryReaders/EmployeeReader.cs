using System.Collections.Generic;

namespace Biing2WPF.Biing2.MemoryReaders
{
    public class EmployeeReader
    {
        private static readonly uint tArraySize = 1000;
        private static readonly uint baseOffset = 0x7AE05;
        private static readonly uint tSize = 0x92;
        private uint pHandle;
        private uint baseAddress;

        public EmployeeReader(uint pHandle, uint baseAddress)
        {
            this.pHandle = pHandle;
            this.baseAddress = Memory.ReadInt32Ptr((int)pHandle, (int)(baseAddress + baseOffset)
                );
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> list = new List<Employee>();
            for (uint i = 1; i <= tArraySize; i++)
            {
                uint offset = i * tSize + baseAddress;
                list.Add(new Employee(i, pHandle, offset, tSize));
            }
            return list;
        }
    }
}
