using Biing2WPF.Biing2;
using Biing2WPF.Biing2.MemoryReaders;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Biing2WPF.Biing2
{
    public abstract class MemoryObject : IMemoryRefresh
    {
        protected uint index;
        public MemoryObject(uint index, uint pHandle, uint baseAddress, uint tSize)
        {
            this.index = index;
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
