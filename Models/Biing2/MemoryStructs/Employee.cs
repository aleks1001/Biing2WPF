using System.Runtime.InteropServices;

namespace Biing2WPF.Biing2.MemoryObjects
{
    [StructLayout(LayoutKind.Explicit, Pack = 2)]
    public struct MemoryEmployee
    {
        [FieldOffset(0x0)] public readonly byte isFemale;
        [FieldOffset(0x1)] public readonly byte profession1;
        [FieldOffset(0x2)] public readonly byte profession2;
        [FieldOffset(0x3)] public readonly byte profession3;
        [FieldOffset(0x4)] public readonly byte trainingPoints1;
        [FieldOffset(0x5)] public readonly byte trainingPoints2;
        [FieldOffset(0x6)] public readonly byte trainingPoints3;
        [FieldOffset(0x7)] public readonly byte age;
        [FieldOffset(0x8)] public readonly ushort height;
        [FieldOffset(0xA)] public readonly ushort weight;
        [FieldOffset(0xC)] public readonly ushort IQ;
        [FieldOffset(0xE)] public readonly ushort charm;
        [FieldOffset(0x10)] public readonly ushort bust;
        [FieldOffset(0x12)] public readonly ushort waist;
        [FieldOffset(0x14)] public readonly ushort hip;
        [FieldOffset(0x16)] public readonly byte courses;
        [FieldOffset(0x17)] public readonly byte passedCourses1;
        [FieldOffset(0x18)] public readonly byte passedCourses2;
        [FieldOffset(0x19)] public readonly byte passedCourses3;
        [FieldOffset(0x1A)] public readonly byte qualification;
        [FieldOffset(0x20)] public readonly byte desiredSalary;
        [FieldOffset(0x21)] public readonly byte salary;
        [FieldOffset(0x22)] public readonly ushort daysEmployed;
        [FieldOffset(0x24)] public readonly byte happiness;
        [FieldOffset(0x25)] public readonly byte hotelId;
        [FieldOffset(0x26)] public readonly short N00000E65;
        [FieldOffset(0x28)] public readonly byte buildingId;
        [FieldOffset(0x29)] public readonly byte roomIndex;
        [FieldOffset(0x2C)] public readonly bool isIndependent;
        [FieldOffset(0x2E)] public readonly byte hoursAtWork;
        [FieldOffset(0x30)] public readonly byte hoursAtHome;
        [FieldOffset(0x34)] public readonly ushort nameIndex;
        [FieldOffset(0x36)] public readonly ushort mottoIndex;
        [FieldOffset(0x38)] public readonly ushort sayingIndex;
        [FieldOffset(0x3A)] public readonly byte diligence;
        [FieldOffset(0x3C)] public readonly bool isNaked;
        [FieldOffset(0x3D)] public readonly byte currentProf;
        [FieldOffset(0x3E)] public readonly ushort pictureId;
        [FieldOffset(0x40)] public readonly ushort pictureNakedId;
        [FieldOffset(0x42)] public readonly ushort touristIndex;
        [FieldOffset(0x49)] public readonly byte exhaustion;
        [FieldOffset(0x4C)] public readonly byte N00000179;
        [FieldOffset(0x4D)] public readonly byte N000008E1;
        [FieldOffset(0x56)] public readonly uint exp1;
        [FieldOffset(0x5A)] public readonly uint exp2;
        [FieldOffset(0x5E)] public readonly uint exp3;
        [FieldOffset(0x65)] public readonly bool isInteracting;
        [FieldOffset(0x66)] public readonly bool isFlirting;
    }
}
