using Draw.src.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Logic
{
    public class CoordinateSearch : BaseSearch
    {
        public CoordinateSearch(Hotel g) : base(g)
        {
            
        }

        /// <summary>
        /// Задача #1
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool CheckForPathExceptType(string from, string to, ConnectionType type)
        {
            if (!Hotel.ContainsKey(from) || !Hotel.ContainsKey(to))
            {
                return false;
            }
            Room start = Hotel[from];

            List<Room> list = new List<Room>();

            list.Add(start);

            while (list.Count != 0)
            {
                Room current = list[0];
                list.RemoveAt(0);

                Console.WriteLine(current.Name);

                if (current.Name == to)
                {
                    PrintPath(current);
                    return true;
                }
                current.IsTested = true;

                foreach (Connection link in current.Links)
                {
                    if (link.To.Depth == -1)
                    {
                        link.To.Depth = current.Depth + 1;
                    }
                    if (!link.To.IsTested && !list.Contains(link.To))
                    {
                        if (link.Type != type) 
                        {
                            if ((link.From.Type == RoomType.Transit && link.To.Type == RoomType.Transit) && (link.Type == ConnectionType.Climb || link.Type == ConnectionType.Elevator) && (link.From.Z != link.To.Z))
                            {
                                CalculateDistance(link.To, Hotel[to]);
                                AddElement(link.To, list);
                            }
                            else if (link.Type == ConnectionType.Walk && (link.From.Z == link.To.Z))
                            {
                                CalculateDistance(link.To, Hotel[to]);
                                AddElement(link.To, list);
                            }
                            #region RuleSet
                            else if (link.From.Z == link.To.Z && link.Type != ConnectionType.Walk) // Debug sections / Rules
                                Console.WriteLine("Error, incorrect link, walk connections must be of the same floor");
                            else if ((link.Type == ConnectionType.Elevator || link.Type == ConnectionType.Climb) && (link.From.Z == link.To.Z))
                                Console.WriteLine("Error, incorrect link, climb or elevator connections must be between transit rooms on a different floor");
                            else if ((link.From.Type == RoomType.Transit && link.To.Type == RoomType.Transit) && (link.Type == ConnectionType.Walk))
                                Console.WriteLine("Error, can not walk from one transit room to another, connection must be of type elevator or climb");
                            else
                                Console.WriteLine("Error, incorrect graph parameters");
                            #endregion
                        }
                    }
                }
            }
            ResetFlags();
            return false;
        } 

        /// <summary>
        /// Задача #2
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public override bool CheckForPathOptimal(string from, string to)
        {
            if(!Hotel.ContainsKey(from) || !Hotel.ContainsKey(to))
            {
                Console.WriteLine("Invalid Rooms");
                return false;
            }
            Room start = Hotel[from];

            List<Room> list = new List<Room>();

            list.Add(start);

            while(list.Count != 0)
            {
                Room current = list[0];
                list.RemoveAt(0);

                Console.WriteLine(current.Name);

                if(current.Name == to)
                {
                    PrintPath(current);
                    return true;
                }
                current.IsTested = true;

                foreach(Connection link in current.Links)
                {
                    if(link.To.Depth == -1) 
                    {
                        link.To.Depth = current.Depth + 1;
                    }

                    if(!link.To.IsTested && !list.Contains(link.To))
                    {
                        if((link.From.Type == RoomType.Transit && link.To.Type == RoomType.Transit) && (link.Type == ConnectionType.Climb || link.Type == ConnectionType.Elevator) && (link.From.Z != link.To.Z))
                        {
                            CalculateDistance(link.To, Hotel[to]);
                            AddElement(link.To, list);
                        }
                        else if(link.Type == ConnectionType.Walk && (link.From.Z == link.To.Z))
                        {
                            CalculateDistance(link.To, Hotel[to]);
                            AddElement(link.To, list);
                        }
                        #region RuleSet
                        else if(link.From.Z == link.To.Z && link.Type != ConnectionType.Walk) // Debug sections
                            Console.WriteLine("Error, incorrect link, walk connections must be of the same floor");
                        else if((link.Type == ConnectionType.Elevator || link.Type == ConnectionType.Climb) && (link.From.Z == link.To.Z))
                            Console.WriteLine("Error, incorrect link, climb or elevator connections must be between transit rooms on a different floor");
                        else if ((link.From.Type == RoomType.Transit && link.To.Type == RoomType.Transit) && (link.Type == ConnectionType.Walk))
                            Console.WriteLine("Error, can not walk from one transit room to another, connection must be of type elevator or climb");
                        else
                            Console.WriteLine("Error, incorrect graph parameters");
                        #endregion
                    }
                }
            }
            ResetFlags();
            return false;
        } 

        /// <summary>
        /// Задача #3
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public override bool CheckForPathLiftOrClimbSpecial(string from, string to)
        {
            if (!Hotel.ContainsKey(from) || !Hotel.ContainsKey(to))
            {
                return false;
            }
            Room start = Hotel[from];

            List<Room> list = new List<Room>();

            list.Add(start);

            while (list.Count != 0)
            {
                Room current = list[0];
                list.RemoveAt(0);

                Console.WriteLine(current.Name);

                if (current.Name == to)
                {
                    PrintPath(current);
                    return true;
                }
                current.IsTested = true;

                foreach (Connection link in current.Links)
                {
                    if (link.To.Depth == -1)
                    {
                        link.To.Depth = current.Depth + 1;
                    }

                    if (!link.To.IsTested && !list.Contains(link.To))
                    {
                        if ((link.From.Type == RoomType.Transit && link.To.Type == RoomType.Transit) && (link.Type == ConnectionType.Climb || link.Type == ConnectionType.Elevator) && (link.From.Z != link.To.Z))
                        {
                            if (link.Type == ConnectionType.Elevator)
                            {
                                CalculateDistance(link.To, Hotel[to]);
                                AddElement(link.To, list);
                            }

                            if (link.Type == ConnectionType.Climb)
                            {
                                CalculateClimbDistance(link.To, Hotel[to]);
                                AddElement(link.To, list);
                            }
                        }
                        else if (link.Type == ConnectionType.Walk && (link.From.Z == link.To.Z))
                        {
                            CalculateDistance(link.To, Hotel[to]);
                            AddElement(link.To, list);
                        }
                        #region RuleSet
                        else if (link.From.Z == link.To.Z && link.Type != ConnectionType.Walk) // Debug sections
                            Console.WriteLine("Error, incorrect link, walk connections must be of the same floor");
                        else if ((link.Type == ConnectionType.Elevator || link.Type == ConnectionType.Climb) && (link.From.Z == link.To.Z))
                            Console.WriteLine("Error, incorrect link, climb or elevator connections must be between transit rooms on a different floor");
                        else
                            Console.WriteLine("Error, incorrect graph parameters");
                        #endregion
                    }
                }
            }
            ResetFlags();
            return false;
        } 

        private void AddElement(Room to, List<Room> list)
        {
            for(int i = 0;i<list.Count;i++)
            {
                if (to.Distance < list[i].Distance)
                {
                    list.Insert(i, to);
                    return;
                }
            }
            list.Add(to);
        }

        private void CalculateDistance(Room current, Room end)
        {
            double a = current.X - end.X;
            double b = current.Y - end.Y;

            current.Distance = Math.Sqrt(a * a + b * b);
        }

        private void CalculateClimbDistance(Room current, Room end)
        {
            double a = current.X - end.X;
            double b = current.Y - end.Y;

            current.Distance = (Math.Sqrt(a * a + b * b) * 2);
        }
    }
}
