using System.Runtime.InteropServices;
using System.Text;

namespace Biing2WPF.Biing2
{
    public class Person : IB2Serializer, IB2TextReader, IB2GraphicReader
    {
        private readonly byte[] structure;

        public uint baseAddress { get; set; }
        public uint pHandle { get; set; }


        public Person(uint pHandle, uint baseAddress, byte[] rawBytes)
        {
            this.pHandle = pHandle;
            this.baseAddress = baseAddress;
            structure = rawBytes;
        }
        public string ReadText(uint index)
        {
            return RemoveSpecialCharacters(EntityMemoryReader.GetTextByIndex(pHandle, baseAddress, index));
        }

        public uint ReadImage(uint index)
        {
            return ImageMemoryReader.GetFlagImageByIndex(pHandle, baseAddress, index);
        }

        public T Deserialize<T>(byte[] array) where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.Copy(array, 0, ptr, size);
            var s = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);
            return s;
        }

        public byte[] Serialize<T>(T structure) where T : struct
        {
            var size = Marshal.SizeOf(typeof(T));
            var array = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structure, ptr, true);
            Marshal.Copy(ptr, array, 0, size);
            Marshal.FreeHGlobal(ptr);
            return array;
        }

        public byte[] GetStructure()
        {
            return structure;
        }
        public string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
