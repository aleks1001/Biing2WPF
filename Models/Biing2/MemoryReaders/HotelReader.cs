using System.Collections.Generic;

namespace Biing2WPF.Biing2.MemoryReaders
{
    public class HotelReader
    {
        private static readonly uint tArraySize = 18;
        private static readonly uint tSize = 0x5DC;
        private static readonly uint baseOffset = 0x7A81E;
        private uint pHandle;
        private uint baseAddress;

        public HotelReader(uint pHandle, uint baseAddress)
        {
            this.pHandle = pHandle;
            this.baseAddress = Memory.ReadInt32Ptr((int)pHandle, (int)(baseAddress + baseOffset)
                );
        }
    }
}
