namespace Biing2WPF.Biing2.MemoryReaders
{
    public interface IMemoryRefresh
    {
        void OnRefresh(uint pHandle, uint baseAddress, uint tSize);
    }
}
