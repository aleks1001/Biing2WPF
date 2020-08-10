namespace Biing2WPF.Biing2.MemoryReaders
{
    public class BaseReader
    {
        protected uint BaseAddress { get; set; }
        protected uint pProcessHandle { get; set; }

        protected uint ResolveInt32PtrAddress(uint pAddress)
        {
            return Memory.ReadInt32Ptr((int)pProcessHandle, (int)pAddress);
        }

        protected byte[] ResolveCustomAddress(uint pAddress, uint tSize)
        {
            return Memory.Read((int)pProcessHandle, (int)pAddress, tSize);
        }
    }
}
