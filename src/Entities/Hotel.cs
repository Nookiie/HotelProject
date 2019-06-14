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

        public override void CreateLink(string from, string to, string type, string distance, string isBidirectionalToString)
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
            else if (type.Contains("lift"))
                selectedType = ConnectionType.Elevator;

            if (start != null && end != null)
            {
                start.AddLink(new Connection(start, end, distance, selectedType));
                end.AddLink(new Connection(end, start, distance, selectedType));
            }
            if (isBidirectional)
            {
                //end.AddLink(new Connection(end, start, distance, selectedType));
            }
        }

        /// <summary>
        /// Unused
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Room> GetLinkedNodes(string name)
        {
            List<Room> linkedRooms = new List<Room>();
            Room room = hotel[name];

            foreach (var link in room.Links)
            {
                linkedRooms.Add(hotel[link.To.Name]);
            }
            return linkedRooms;
        }
        /// <summary>
        /// Unused
        /// </summary>
        /// <param name="list"></param>
        public void SortByDistance(List<Room> list)
        {
            list = list.OrderBy(x => x.DistanceToGoal).ToList();
        }
        /// <summary>
        /// Unused
        /// </summary>
        /// <param name="name"></param>
        public void SetDepths(string name)
        {
            Room room = hotel[name];
            foreach (var r in GetLinkedNodes(name))
            {
                if (r.Depth == -1)
                    r.Depth = r.Depth + 1;
            }
        }
    }
}
