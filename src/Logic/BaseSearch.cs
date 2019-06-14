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

        public List<Connection> CorrectPathLinks { get; set; } = new List<Connection>();

        public List<Connection> PathLinks { get; set; } = new List<Connection>();

        public abstract bool CheckForPathExceptType(string from, string to, ConnectionType type); // Задача #1

        public abstract bool CheckForPathOptimal(string from, string to); // Задача #2

        public abstract bool CheckForPathLiftOrClimbSpecial(string from, string to); // Задача #3

        public virtual void PrintPathOptimal(Room current)
        {
            
            while (current.Depth != 0)
            {
                foreach (var link in current.Links)
                {
                    if (link.To.Depth == current.Depth - 1)
                    {
                        CorrectPathLinks.Add(link);
                        current = link.To;
                        break;
                    }
                }
            }
            

            /*
            foreach(var link in PathLinks)
            {
                Console.WriteLine("Cost:" + link.Distance);
            }
            */

            CorrectPathLinks.Reverse();

            Console.WriteLine("\nPath:");
            foreach (var link in PathLinks)
            {
                Console.WriteLine(link.To.Name + " - " + link.From.Name);
            }
            Console.WriteLine("Cost of Path:" + CorrectPathLinks.Select(x => x.Distance).Sum());
            Console.WriteLine("Number of Total Links:" + CorrectPathLinks.Count());
            Console.WriteLine("Number of Lift Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Elevator).Count());
            Console.WriteLine("Number of Climb Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Climb).Count());
            Console.WriteLine("Number of Walk Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Walk).Count());
        }

        public virtual void PrintPathExcept(Room current, ConnectionType type)
        {
            while (current.Depth != 0)
            {
                foreach (Connection link in current.Links)
                {
                    if (link.Type == type)
                        continue;

                    if (link.To.Depth == current.Depth - 1)
                    {
                        current = link.To;
                        CorrectPathLinks.Add(link);
                        break;
                    }
                }
            }

            // Console.WriteLine("Cost: " + PathLinks.Select(x => x.Distance).Sum());
            CorrectPathLinks.Reverse();

            Console.WriteLine("\nPath is:");

            foreach (var link in CorrectPathLinks)
            {
                Console.WriteLine(link.To.Name + " - " + link.From.Name);
            }
            Console.WriteLine("Path Cost:" + CorrectPathLinks.Select(x => x.Distance).Sum());

            Console.WriteLine("Cost of Path is:" + CorrectPathLinks.Select(x => x.Distance).Sum());
            Console.WriteLine("Number of Total Links:" + CorrectPathLinks.Count());
            Console.WriteLine("Number of Lift Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Elevator).Count());
            Console.WriteLine("Number of Climb Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Climb).Count());
            Console.WriteLine("Number of Walk Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Walk).Count());
        }
        
        public virtual void PrintPathSpecial(Room current)
        {
            while (current.Depth != 0)
            {
                foreach (Connection link in current.Links)
                {
                    if (link.To.Depth == current.Depth - 1)
                    {
                        if (link.Type == ConnectionType.Climb)
                            link.Distance *= 2;

                        current = link.To;
                        CorrectPathLinks.Add(link);
                        break;
                    }
                }
            }

            // Console.WriteLine("Cost:" + PathLinks.Select(x => x.Distance).Sum());
            CorrectPathLinks.Reverse();

            Console.WriteLine("\nPath is:");
            foreach (var link in CorrectPathLinks)
            {
                Console.WriteLine(link.To.Name + " - " + link.From.Name);
            }
            Console.WriteLine("Cost of Path is:" + CorrectPathLinks.Select(x => x.Distance).Sum());
            Console.WriteLine("Number of Total Links:" + CorrectPathLinks.Count());
            Console.WriteLine("Number of Lift Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Elevator).Count());
            Console.WriteLine("Number of Climb Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Climb).Count());
            Console.WriteLine("Number of Walk Links:" + CorrectPathLinks.Where(x => x.Type == ConnectionType.Walk).Count());
        }

        public virtual void ResetFlags()
        {
            foreach (Room room in Hotel.Values)
            {
                room.IsTested = false;
            }
        }
    }
}
