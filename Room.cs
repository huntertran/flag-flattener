public class Room
{
    public int RoomNumber { get; set; }
    public Facility Facilities { get; set; }

    public Room(int roomNumber)
    {
        RoomNumber = roomNumber;
    }
}