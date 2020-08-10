namespace Biing2WPF.Biing2
{
    public static class ImageMemoryReader
    {
        readonly static uint imageOffsetsArrayBufferOffset = 0x149614;

        public static uint GetFlagImageByIndex(uint pHandle, uint baseAddress, uint index)
        {
            // 2900 in dec
            uint flagConstant = 0xB54 + index;
            uint imageOffsetsArrayBufferAddress = baseAddress + imageOffsetsArrayBufferOffset;
            uint imageOffsetArray = Memory.ReadInt32Ptr((int)pHandle, (int)imageOffsetsArrayBufferAddress);

            uint imageOffset = Memory.ReadInt32Ptr((int)pHandle, (int)(imageOffsetArray + flagConstant * 8));
            return imageOffset;
        }
    }
}
