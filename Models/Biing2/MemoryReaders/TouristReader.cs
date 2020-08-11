using System.Collections.Generic;

namespace Biing2WPF.Biing2.MemoryReaders
{
    public class TouristReader
    {
        private static readonly uint baseOffset = 0x7AE01;
        private static readonly uint tSize = 0xE4;
        private static readonly uint tArraySize = 1026;
        private uint pHandle;
        private uint baseAddress;
        public TouristReader(uint pHandle, uint baseAddress)
        {
            this.pHandle = pHandle;
            this.baseAddress = Memory.ReadInt32Ptr((int)pHandle, (int)(baseAddress + baseOffset)
                );
        }

        public List<Tourist> GetTourists()
        {
            List<Tourist> list = new List<Tourist>();
            for (uint i = 1; i <= tArraySize; i++)
            {
                uint offset = i * tSize + baseAddress;
                list.Add(new Tourist(i, pHandle, offset, tSize));
            }
            return list;
        }
    }
}
