using System;
using System.Collections.Generic;
using System.Text;

namespace Biing2WPF.Biing2.MemoryReaders
{
    public class TouristReader : BaseReader, IBaseReader
    {
        private static readonly uint baseOffset = 0x7AE01;
        private static readonly uint tSize = 0xE4;
        private static readonly uint tArraySize = 1026;

        public TouristReader(uint pHandle, uint baseAddress)
        {
            pProcessHandle = pHandle;
            BaseAddress = ResolveInt32PtrAddress(baseAddress + baseOffset);
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
