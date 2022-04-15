using System;
using System.Text;

public class FlattenedRoom
{
    public int RoomNumber { get; set; }

    [FlattenedFlag(Facility.HasTV)]
    public bool HasTV { get; set; }

    [FlattenedFlag(Facility.HasMicrowave)]
    public bool HasMicrowave { get; set; }

    [FlattenedFlag(Facility.HasOven)]
    public bool HasOven { get; set; }

    public FlattenedRoom(int roomNumber, Facility facility)
    {
        RoomNumber = roomNumber;

        var props = typeof(FlattenedRoom).GetProperties();

        foreach (var prop in props)
        {
            var attr = prop.GetCustomAttributes(typeof(FlattenedFlag), false);

            if (attr.GetLength(0) > 0)
            {
                prop.SetValue(this, facility.HasFlag(((FlattenedFlag)attr[0]).FacilityEnum));
            }

        }

        Console.WriteLine("End");
    }

    public FlattenedRoom(Room room)
    {
        RoomNumber = room.RoomNumber;
        HasMicrowave = room.Facilities.HasFlag(Facility.HasMicrowave);
        HasTV = room.Facilities.HasFlag(Facility.HasTV);
        HasOven = room.Facilities.HasFlag(Facility.HasOven);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Room " + RoomNumber);
        sb.AppendLine();

        sb.Append("Has TV: " + HasTV);
        sb.AppendLine();

        sb.Append("Has Microwave: " + HasMicrowave);
        sb.AppendLine();

        sb.Append("Has Oven: " + HasOven);
        sb.AppendLine();

        return sb.ToString();
    }

}