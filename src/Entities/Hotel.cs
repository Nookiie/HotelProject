using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Entities
{
    public class Hotel : Graph
    {
        public Dictionary<string, Room> hotel = new Dictionary<string, Room>();

        public void AddRoomToHotel(Room room)
        {
            if (hotel.ContainsKey(room.Name))
            {
                Console.WriteLine("Error, Duplicate Rooms!");
                return;
            }
            hotel.Add(room.Name, room);
        }

        public override void CreateLink(string from, string to, string type, string depth, string isBidirectionalToString)
        {
            if (!hotel.ContainsKey(from) || !hotel.ContainsKey(to))
            {
                Console.WriteLine("Invalid Rooms!");
                return;
            }
            Room start = hotel[from];
            Room end = hotel[to];
            bool isBidirectional = true;

            if (isBidirectionalToString.Contains("no"))
                isBidirectional = false;

            ConnectionType selectedType = ConnectionType.Walk;

            if (type.Contains("climb"))
                selectedType = ConnectionType.Climb;
            else if (type.Contains("elevator"))
                selectedType = ConnectionType.Elevator;

            if (start != null && end != null)
            {
                start.AddLink(new Connection(end, selectedType));
            }
            if (isBidirectional)
            {
                end.AddLink(new Connection(start, selectedType));
            }
        }
    }
}
