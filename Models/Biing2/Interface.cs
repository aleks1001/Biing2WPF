namespace Biing2WPF.Biing2
{
    interface IB2Serializer
    {
        byte[] Serialize<T>(T structure) where T : struct;
        T Deserialize<T>(byte[] array) where T : struct;
    }

    interface IB2TextReader
    {
        uint baseAddress { get; set; }
        uint pHandle { get; set; }
        string ReadText(uint index);
    }

    interface IB2GraphicReader
    {
        uint ReadImage(uint index);
    }
}
