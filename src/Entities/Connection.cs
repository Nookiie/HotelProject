using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Entities
{
    public enum ConnectionType
    {
        Walk,
        Climb,
        Elevator
    }

    public class Connection : Link
    {
        public ConnectionType Type { get; set; }
        public bool IsBidirectional { get; set; }

        public Connection(Room to, ConnectionType type) : base(to)
        {
            this.Type = type;
        }

        public Connection(Room from, Room to) : base(from, to)
        {
            this.Type = ConnectionType.Walk;
            this.IsBidirectional = true;
        }

        public Connection(Room from, Room to, string type, string distance, string isBidirectionalToString) : base(from, to, distance)
        {
            if (type == "walk")
                this.Type = ConnectionType.Walk;
            else if (type == "climb")
                this.Type = ConnectionType.Climb;
            else if (type == "elevator")
                this.Type = ConnectionType.Elevator;
            else
                Console.WriteLine("No type chosen, choosing default Type: Walk");

            this.IsBidirectional = true;

            if (isBidirectionalToString.Contains("no"))
                this.IsBidirectional = false;
            else
                Console.WriteLine("No bidirectional value chosen, choosing default Value: Yes");
        }
    }

}
