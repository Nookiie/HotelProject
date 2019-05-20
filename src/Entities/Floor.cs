using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Entities
{
    /// <summary>
    /// Използван само и единствено за визуализация на проекта, ако има такава
    /// </summary>
    public class Floor
    {
        public int Number { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();

        public Floor(int number, List<Room> rooms)
        {
            this.Number = number;
            this.Rooms = rooms;
        }
    }
}
