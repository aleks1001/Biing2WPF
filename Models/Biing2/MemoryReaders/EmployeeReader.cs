using Biing2WPF.Biing2.MemoryObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Biing2WPF.Biing2.MemoryReaders
{
    public class EmployeeReader : BaseReader, IBaseReader
    {
        private static readonly uint tArraySize = 1000;
        private static readonly uint baseOffset = 0x7AE05;
        private static readonly uint tSize = 0x92;
        public List<MemoryEmployee> Items = new List<MemoryEmployee>();

        public EmployeeReader (uint pHandle, uint baseAddress)
        {
            pProcessHandle = pHandle;
            BaseAddress = ResolveInt32PtrAddress(baseAddress + baseOffset);

            Task.Factory.StartNew(async () =>
            {
                while(true)
                {
                    await Task.Delay(200);
                    Items = ResolveAll<MemoryEmployee>();
                }
            });
        }

        public List<T> ResolveAll<T>() where T : struct
        {
            List<T> list = new List<T>();
            for (uint i = 1; i <= tArraySize; i++)
            {
                list.Add(ResolveOne<T>(i));
            }
            return list;
        }

        public T ResolveOne<T>(uint index) where T : struct
        {
            uint offset = index * tSize + BaseAddress;
            return Serializer.Deserialize<T>(ResolveCustomAddress(offset, tSize));
        }
    }
}
