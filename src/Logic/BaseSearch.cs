using Draw.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Logic
{
    public abstract class BaseSearch
    {
        public BaseSearch(Hotel g)
        {
            Hotel = g.hotel;
        }

        public Dictionary<string, Room> Hotel { get; set; }

        public abstract bool CheckForPathExceptType(string from, string to, ConnectionType type); // Задача #1

        public abstract bool CheckForPathOptimal(string from, string to); // Задача #2
            
        public abstract bool CheckForPathLiftOrClimbSpecial(string from, string to); // Задача #3
            
        public virtual void PrintPath(Room current)
        {
            StringBuilder sb = new StringBuilder();

            while(current.Depth != 0)
            {
                sb.Append(current.Name);
                sb.Append(',');

                foreach(Connection link in current.Links)
                {
                    if(link.To.Depth == current.Depth - 1)
                    {
                        current = link.To;
                        break;
                    }
                }
            }
            sb.Append(current.Name);

            Console.WriteLine("Path is:" + sb);
        }

        public virtual void ResetFlags()
        {
            foreach(Node node in Hotel.Values)
            {
                node.IsTested = false;
            }
        }
    }
}
