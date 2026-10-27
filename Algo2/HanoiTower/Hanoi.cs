using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.HanoiTower
{
    public class HanoiEntity
    {
        public string Name { get; set; }
        public Stack<int> Data { get; set; } = new Stack<int>();
    }

    public class HanoiTask
    { 
        public HanoiEntity Source { get; set; }
        public HanoiEntity Auxiliary { get; set; }
        public HanoiEntity Target { get; set; }
        public int DiskCount { get; set; }

    }

    public class Hanoi
    {
        public static void SolveByIteration(HanoiEntity source, HanoiEntity auxiliary, HanoiEntity target)
        {
            if (source == null || auxiliary == null || target == null || source.Data.Count == 0)
            {
                return;
            }

            HanoiTask root = new HanoiTask() {Source = source, Auxiliary = auxiliary, Target = target, DiskCount = source.Data.Count};
            Stack<HanoiTask> stack = new Stack<HanoiTask>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.DiskCount == 1)
                {
                    Console.WriteLine("Moving {0} from {1} to {2}", current.Source.Data.Peek(), current.Source.Name, current.Target.Name);
                    current.Target.Data.Push(current.Source.Data.Pop());
                    PrintStacks(current.Source, current.Auxiliary, current.Target);
                }
                else
                {
                    HanoiTask moveToTarget = new HanoiTask() { Source = current.Auxiliary, Auxiliary = current.Source, Target = current.Target, DiskCount = current.DiskCount - 1 };
                    stack.Push(moveToTarget);

                    HanoiTask moveOne = new HanoiTask() { Source = current.Source, Auxiliary = current.Auxiliary, Target = current.Target, DiskCount = 1 };
                    stack.Push(moveOne);

                    HanoiTask moveToHelp = new HanoiTask() { Source = current.Source, Auxiliary = current.Target, Target = current.Auxiliary, DiskCount = current.DiskCount - 1 };
                    stack.Push(moveToHelp);
                }
            }
        }

        public static void SolveByRecursive(HanoiEntity source, HanoiEntity auxiliary, HanoiEntity target)
        {
            if (source == null || auxiliary == null || target == null || source.Data.Count == 0)
            {
                return;
            }
            SolveByRecursiveHelp(source, auxiliary, target, source.Data.Count);
        }

        private static void SolveByRecursiveHelp(HanoiEntity source, HanoiEntity auxiliary, HanoiEntity target, int count)
        {
            if (count == 1)
            {
                Console.WriteLine("Moving {0} from {1} to {2}", source.Data.Peek(), source.Name, target.Name);
                target.Data.Push(source.Data.Pop());
                PrintStacks(source, auxiliary, target);
                return;
            }

            SolveByRecursiveHelp(source, target, auxiliary, count - 1);

            Console.WriteLine("now moving {0} from {1} to {2}", source.Data.Peek(), source.Name, target.Name);
            target.Data.Push(source.Data.Pop());

            SolveByRecursiveHelp(auxiliary, source, target, count - 1);
        }

        private static void PrintStacks(HanoiEntity source, HanoiEntity auxiliary, HanoiEntity target)
        {
            List<HanoiEntity> hanoies = new List<HanoiEntity>() { source, auxiliary, target};
            source = hanoies.First(item => item.Name == "Source");
            auxiliary = hanoies.First(item => item.Name == "Auxiliary");
            target = hanoies.First(item => item.Name == "Target");
            Console.WriteLine("Now the stacks are: {0}:{1}, {2}:{3}, {4}:{5}", 
                source.Name, string.Join(",", source.Data),
                auxiliary.Name, string.Join(",", auxiliary.Data),
                target.Name, string.Join(",", target.Data));
        }
    }
}
