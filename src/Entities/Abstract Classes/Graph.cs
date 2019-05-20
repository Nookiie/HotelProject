using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draw.src.Entities
{
    public abstract class Graph
    {
        public Dictionary<string, Room> graph = new Dictionary<string, Room>();

        public virtual void AddNodeToGraph(Room node)
        {
            if(graph.ContainsKey(node.Name))
            {
                Console.WriteLine("Error, node is duplicated");
                return;
            }

            graph.Add(node.Name, node);
        }
        
        public virtual void CreateLink(string from, string to,string type, string depth, string isBidirectionalToString)
        {
            Room start = graph[from];
            Room end = graph[to];
            bool isBidirectional = false;

            if (isBidirectionalToString.Contains("yes"))
                isBidirectional = true;

            if (start != null && end != null)
            {
                // start.AddLink(new Link(end));
            }
            if(isBidirectional)
            {
                // end.AddLink(new Link(start));
            }
        }
      
    }
}
