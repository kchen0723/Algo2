using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.HanoiTower
{
    public class HonoiEntity
    {
        public string Name { get; set; }
        public List<int> Data { get; set; } = new List<int>(); //index 0 is the smallest one, the last one is the biggest.
    }

    public class Honoi
    {
        public static void Solve(HonoiEntity source, HonoiEntity help, HonoiEntity target)
        {
            if (source == null || help == null || target == null || source.Data.Count == 0)
            {
                return;
            }
            SolveHelp(source, help, target, source.Data.Count);
        }

        private static void SolveHelp(HonoiEntity source, HonoiEntity help, HonoiEntity target, int movingCount)
        {
            if (movingCount == 1)
            {
                Console.WriteLine("Moving {0} from {1} to {2}", source.Data[0], source.Name, target.Name);
                target.Data.Insert(0, source.Data[0]);
                source.Data.RemoveAt(0);
                PrintStacks(source, help, target);
                return;
            }

            SolveHelp(source, target, help, movingCount - 1);

            Console.WriteLine("now moving {0} from {1} to {2}", source.Data[0], source.Name, target.Name);
            target.Data.Insert(0, source.Data[0]);
            source.Data.RemoveAt(0);

            SolveHelp(help, source, target, movingCount - 1);
        }

        private static void PrintStacks(HonoiEntity source, HonoiEntity help, HonoiEntity target)
        {
            Console.WriteLine("Now the stacks are: {0}:{1}, {2}:{3}, {4}:{5}", 
                source.Name, string.Join(",", source.Data),
                help.Name, string.Join(",", help.Data),
                target.Name, string.Join(",", target.Data));
        }
    }
}
