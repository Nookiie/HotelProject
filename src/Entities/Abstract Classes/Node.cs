using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Entities
{
    public abstract class Node
    {
        public string Name { get; set; }
        public int X { get; set; } // X Coordinates
        public int Y { get; set; } // Y Coordinates
        public int Z { get; set; } // Floor
        public int Depth { get; set; } = -1;
        public double DistanceToGoal { get; set; } = 0;
        public bool IsTested { get; set; }
        public bool IsExpanded { get; set; }

        public List<Connection> Links { get; set; } = new List<Connection>();
        
        public Node(string name)
        {
            this.Name = name;
            this.Depth = -1;
        }

        public Node(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;

            this.Depth = -1;
        }

        public Node(string name, string x,string y, string z)
        {
            this.Name = name;
            this.X = int.Parse(x);
            this.Y = int.Parse(y);
            this.Z = int.Parse(z);

            this.Depth = -1;
        }
        
        public virtual void AddLink(Connection link)
        {
            Links.Add(link);
        }
    }
}
