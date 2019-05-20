using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Entities
{
    public enum RoomType
    {
        Normal,
        Transit
    }

    public class Room : Node
    {
        public RoomType Type { get; set; }

        public Room(string name, RoomType type) : base(name)
        {
            this.Type = type;
        }

        public Room(string name, string x, string y, string z, string type) : base(name, x, y, z)
        {
            this.Type = RoomType.Normal;

            if (type.Contains("transit"))
                this.Type = RoomType.Transit;
            else if (type.Contains("room"))
                return;
            else
                Console.WriteLine("No room type identified, choosing default value: Normal");
        }
    }
}
