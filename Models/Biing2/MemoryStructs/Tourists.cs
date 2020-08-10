using System.Runtime.InteropServices;

namespace Biing2WPF.Biing2.MemoryObjects
{
    [StructLayout(LayoutKind.Explicit, Pack=2)]
    public struct MemoryTourist
    {
        [FieldOffset(0x0)] public readonly byte isFemale;
        [FieldOffset(0x1)] public readonly byte hotelIndex;
        [FieldOffset(0x2)] public readonly byte buildingId;
        [FieldOffset(0x3)] public readonly byte roomIndex;
        [FieldOffset(0x7)] public readonly byte age;
        [FieldOffset(0x8)] public readonly ushort height;
        [FieldOffset(0xA)] public readonly ushort weight;
        [FieldOffset(0xC)] public readonly ushort IQ;
        [FieldOffset(0xE)] public readonly ushort charm;
        [FieldOffset(0x10)] public readonly ushort bust;
        [FieldOffset(0x12)] public readonly ushort waist;
        [FieldOffset(0x14)] public readonly ushort hip;
        [FieldOffset(0x16)] public readonly ushort name;
        [FieldOffset(0x18)] public readonly ushort profession;
        [FieldOffset(0x1A)] public readonly byte satisfaction;
        [FieldOffset(0x2E)] public readonly byte hapiness;
        [FieldOffset(0x3C)] public readonly ushort picId1;
        [FieldOffset(0x3E)] public readonly ushort picId2;
        [FieldOffset(0x40)] public readonly ushort mottoId;
        [FieldOffset(0x42)] public readonly byte flagId;
        [FieldOffset(0x43)] public readonly bool isNaked;
        [FieldOffset(0x47)] public readonly byte drinkingIndex;
        [FieldOffset(0x4B)] public readonly byte miserly;
        [FieldOffset(0x56)] public readonly byte aggressiveness;
        [FieldOffset(0x59)] public readonly byte swimmingCoefficient;
        [FieldOffset(0x5A)] public readonly byte noseCoefficient;
        [FieldOffset(0x80)] public readonly byte hoursInside;
        [FieldOffset(0x81)] public readonly byte minutesInsude;
        [FieldOffset(0x82)] public readonly ushort touristIndex;
        [FieldOffset(0x84)] public readonly ushort employeeIndex;
        [FieldOffset(0x86)] public readonly ushort touristInLoveWithIndex;
        [FieldOffset(0x9C)] public readonly byte hunger;
        [FieldOffset(0x9D)] public readonly byte thirst;
        [FieldOffset(0xA9)] public readonly bool isStraight;
        [FieldOffset(0xAA)] public readonly bool isBi;
        [FieldOffset(0xB8)] public readonly byte itemIndexDesired;
    }
}
