using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Entities
{
    public abstract class Link
    {
        public double Distance { get; set; }
        public Room From { get; set; }   
        public Room To { get; set; }

        public Link(Room to)
        {
            this.To = to;
        }

        public Link(Room to,double distance)
        {
            this.To = to;
            this.Distance = distance;
        }

        public Link(Room to, Room from)
        {
            this.From = from;
            this.To = to; 
        }

        public Link(Room from, Room to, string distance)
        {
            this.From = from;
            this.To = to;
            this.Distance = double.Parse(distance);
        }
    }
}
