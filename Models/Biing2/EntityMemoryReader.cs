
using System.Text;

namespace Biing2WPF.Biing2
{
    public static class EntityMemoryReader
    {
        readonly static uint textsOffsetsArrayOffset = 0x7AE51;
        readonly static uint textsBlobOffset = 0x7AE4D;

        public static string GetTextByIndex(uint pHandle, uint baseAddress, uint index)
        {

            //uint textsArrayOffsetsSize = 100000;
            uint tSize = 0x4;
            uint textOffsetsArrayAddress = baseAddress + textsOffsetsArrayOffset;
            uint textOffsetsArray = Memory.ReadInt32Ptr((int)pHandle, (int)textOffsetsArrayAddress);

            uint start = Memory.ReadInt32Ptr((int)pHandle, (int)(textOffsetsArray + index * tSize));
            uint end = Memory.ReadInt32Ptr((int)pHandle, (int)(textOffsetsArray + (index + 1) * tSize));

            uint strSize = end - start;

            uint textBlobAddress = baseAddress + textsBlobOffset;
            uint textBlob = Memory.ReadInt32Ptr((int)pHandle, (int)textBlobAddress);

            byte[] byteStr = Memory.Read((int)pHandle, (int)(textBlob + start), strSize - 1);
            return Encoding.UTF8.GetString(byteStr, 0, byteStr.Length);
        }

        public static byte[] GetTouristByIndex(uint pHandle, uint baseAddress, uint index)
        {
            uint touristsArrayOffset = 0x7AE01;
            uint tSize = 0xE4;
            uint touristsAddress = baseAddress + touristsArrayOffset;
            uint tArray = Memory.ReadInt32Ptr((int)pHandle, (int)touristsAddress) + tSize * index;
            byte[] tBuffer = Memory.Read((int)pHandle, (int)tArray, tSize);
            return tBuffer;
        }

        public static byte[] GetEmployeeByIndex(uint pHandle, uint baseAddress, uint index)
        {
            uint employeesArrayOffset = 0x7AE05;
            uint eSize = 0x92;
            uint employeeAddress = baseAddress + employeesArrayOffset;
            uint eArray = Memory.ReadInt32Ptr((int)pHandle, (int)employeeAddress) + eSize * index;
            byte[] eBuffer = Memory.Read((int)pHandle, (int)eArray, eSize);
            return eBuffer;
        }
    }
}
