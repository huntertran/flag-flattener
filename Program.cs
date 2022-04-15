
namespace FlagFlattener
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            var room1 = new Room(1);

            // set room facility
            room1.Facilities = Facility.HasTV | Facility.HasMicrowave;

            Console.WriteLine("Room 1 facilities: " + room1.Facilities.ToString());
            Console.WriteLine("Room 1 facilities as int: " + (int)room1.Facilities);

            var room2 = new Room(2);

            // set room facility
            room2.Facilities = Facility.HasOven;

            Console.WriteLine("Room 2 facilities: " + room2.Facilities.ToString());
            Console.WriteLine("Room 2 facilities as int: " + (int)room2.Facilities);

            var flattenedRoom1 = new FlattenedRoom(room1);
            Console.WriteLine(flattenedRoom1.ToString());

            var flattenedRoom2 = new FlattenedRoom(2, room2.Facilities);
            Console.WriteLine(flattenedRoom2.ToString());
        }
    }
}