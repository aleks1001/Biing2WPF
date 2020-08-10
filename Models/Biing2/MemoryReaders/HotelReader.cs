using System.Collections.Generic;

namespace Biing2WPF.Biing2.MemoryReaders
{
    public class HotelReader: BaseReader, IBaseReader
    {
        private static readonly uint tArraySize = 18;
        private static readonly uint tSize = 0x5DC;
        private static readonly uint baseOffset = 0x7A81E;
        
        public HotelReader(uint pHandle, uint baseAddress)
        {
            pProcessHandle = pHandle;
            BaseAddress = ResolveInt32PtrAddress(baseAddress + baseOffset);
        }

        public List<T> ResolveAll<T>() where T : struct
        {
            List<T> list = new List<T>();
            for (uint i = 0; i < tArraySize; i++)
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
