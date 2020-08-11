using Biing2WPF.Biing2;
using Biing2WPF.Biing2.MemoryReaders;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Biing2WPF.Biing2
{
    public abstract class MemoryObject : IMemoryRefresh
    {
        public uint index;
        protected uint pHandle;
        protected uint baseAddress;
        public MemoryObject(uint i, uint pHandle, uint baseAddress, uint tSize)
        {
            index = i;
            this.pHandle = pHandle;
            this.baseAddress = baseAddress;
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    OnRefresh(pHandle, baseAddress, tSize);
                    await Task.Delay(500);
                }
            });
        }
        public abstract void OnRefresh(uint pHandle, uint baseAddress, uint tSize);
    }
}
