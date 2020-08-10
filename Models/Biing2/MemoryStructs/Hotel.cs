using System.Runtime.InteropServices;

namespace Biing2WPF.Biing2.MemoryObjects
{
	[StructLayout(LayoutKind.Explicit, Pack = 2)]
	public struct MemoryHotel
	{
		[FieldOffset(0x0)] public readonly bool isOwned;
		[FieldOffset(0x1)] public readonly bool isOpen;
		[FieldOffset(0x6)] public readonly byte index;
		[FieldOffset(0xC)] public readonly ushort itemIdWorkingWith;
		[FieldOffset(0xE)] public readonly ushort roomId;
		[FieldOffset(0x10)] public readonly ushort roomNumber;
		[FieldOffset(0x12)] public readonly ushort lotsWorkingWith;
		[FieldOffset(0x16)] public readonly uint money;
		[FieldOffset(0x1A)] public readonly ushort lotsPurchased;
		[FieldOffset(0x1C)] public readonly ushort lotsRented;
		[FieldOffset(0x1E)] public readonly ushort lotsUsed;
		[FieldOffset(0x20)] public readonly ushort lotsTotal;
		[FieldOffset(0x22)] public readonly ushort expenses;
		[FieldOffset(0x26)] public readonly ushort N00000593;
		[FieldOffset(0x2A)] public readonly ushort N00000594;
		[FieldOffset(0x2E)] public readonly ushort N00000595;
		[FieldOffset(0x32)] public readonly ushort N00000596;
		[FieldOffset(0x36)] public readonly uint N00000597;
		[FieldOffset(0x3A)] public readonly uint N00000598;
		[FieldOffset(0x3E)] public readonly ushort N00001328;
		[FieldOffset(0x42)] public readonly ushort N00001338;
		[FieldOffset(0x46)] public readonly uint N0000059B;
		[FieldOffset(0x4A)] public readonly uint N0000059C;
		[FieldOffset(0x50)] public readonly ushort N00000B4E;
		[FieldOffset(0x52)] public readonly ushort N0000059E;
		[FieldOffset(0x58)] public readonly uint salaryExpense;
		[FieldOffset(0x5C)] public readonly uint salaryExpense_1;
		[FieldOffset(0x63)] public readonly byte roomIdWorkingWith;
		[FieldOffset(0x65)] public readonly byte roomSize;
		[FieldOffset(0x66)] public readonly uint rentExpense;
		[FieldOffset(0x6A)] public readonly uint rentExpense1;
		[FieldOffset(0x9A)] public readonly byte poolPrice;
		[FieldOffset(0x9B)] public readonly byte beachPrice;
		[FieldOffset(0x9C)] public readonly byte forestPrice;
		[FieldOffset(0x9D)] public readonly byte smStudioPrice;
		[FieldOffset(0x9E)] public readonly byte playgroundPrice;
		[FieldOffset(0x9F)] public readonly byte tennisPrice;
		[FieldOffset(0xA0)] public readonly byte golfPrice;
		[FieldOffset(0xA1)] public readonly byte nightClubPrice;
		[FieldOffset(0xA2)] public readonly byte basketballPrice;
		[FieldOffset(0xA4)] public readonly byte medicalPrice;
		[FieldOffset(0xA5)] public readonly byte buffetFoodPrice;
		[FieldOffset(0xA6)] public readonly byte clubFoodPrice;
		[FieldOffset(0xA7)] public readonly byte hotelFoodPrice;
		[FieldOffset(0xA8)] public readonly byte hotelRoomPrice;
		[FieldOffset(0x38E)] public readonly uint N0000066D;
		[FieldOffset(0x392)] public readonly uint rankPoints;
		[FieldOffset(0x3C6)] public readonly ushort buildingSum;
	}

}
