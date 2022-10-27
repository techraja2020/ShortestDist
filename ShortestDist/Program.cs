using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestDist
{
    class Program
    {
        public class neigb
        {
            public string Node { get; set; }
            public int Dist { get; set; }
        }
        static void Main(string[] args)
        {
            Dictionary<string, int> NodeShortDist = new Dictionary<string, int>();
            NodeShortDist.Add("A", 0);
            NodeShortDist.Add("B", 1000);
            NodeShortDist.Add("C", 1000);
            NodeShortDist.Add("D", 1000);
            NodeShortDist.Add("E", 1000);
            NodeShortDist.Add("F", 1000);
          //  NodeShortDist.Add("G", 1000);
            ArrayList res = new ArrayList();
            res.Add(NodeShortDist.First().Key);
            Dictionary<string, List<neigb>> dict = new Dictionary<string, List<neigb>>();
            dict.Add("A",new List<neigb>() { new neigb() { Node = "B", Dist = 2 }, new neigb() { Node = "C", Dist = 3 } } ) ;
            dict.Add("B", new List<neigb>() { new neigb() { Node = "C", Dist = 5 }, new neigb() { Node = "D", Dist = 6 }, new neigb() { Node = "E", Dist = 5 }, new neigb() { Node = "A", Dist = 2 } });
            dict.Add("C", new List<neigb>() {  new neigb() { Node = "D", Dist = 7 } , new neigb() { Node = "A", Dist = 3 }, new neigb() { Node = "B", Dist = 5 } });
            dict.Add("D", new List<neigb>() {  new neigb() { Node = "E", Dist = 12 } , new neigb() { Node = "F", Dist = 3 }, new neigb() { Node = "B", Dist = 6 }, new neigb() { Node = "C", Dist = 7 } });
            dict.Add("E", new List<neigb>() { new neigb() { Node = "F", Dist = 6 }, new neigb() { Node = "D", Dist = 12 } , new neigb() { Node = "B", Dist = 5 }  });
          //  dict.Add("F", new List<neigb>() { new neigb() { Node = "E", Dist = 6 }, new neigb() { Node = "D", Dist = 3 }, new neigb() { Node = "G", Dist = 2 } });
            foreach (var e in dict)
            {
                foreach(var n in e.Value)
                {
                    if (e.Key == "A")
                    {
                        NodeShortDist[n.Node] = n.Dist;
                        
                    }
                    else
                    {
                        if(NodeShortDist[n.Node]>n.Dist)
                        {
                            if(NodeShortDist[n.Node]==1000)
                            {
                                NodeShortDist[n.Node] = n.Dist+ NodeShortDist[e.Key];
                                string Path = e.Key;
                                if(!res.Contains(Path))
                                {
                                    res.Add(e.Key);
                                }
                               
                            }
                            
                            
                        }
                    }

                }
               
            }
            res.Add(NodeShortDist.Last().Key);
            Console.WriteLine(string.Join("-->",res.ToArray()));
            Console.WriteLine("Total Distance Coverd: " +NodeShortDist[NodeShortDist.Last().Key]);
            Console.ReadLine();
        }
    }
}
