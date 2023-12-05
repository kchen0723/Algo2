using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Pramp
{
    public class TimePlanner
    {
        public static int GetMeetingPlanner(int[,] slotsA, int[,] slotsB, int duration)
        {
            if (slotsA == null || slotsB == null || slotsA.Length == 0 || slotsB.Length == 0)
            {
                return 0;
            }

            var aIndex = 0;
            var bIndex = 0;
            while(aIndex < slotsA.Length && bIndex < slotsB.Length)
            {
                var start = Math.Max(slotsA[aIndex, 0], slotsB[bIndex, 0]);
                var end = Math.Min(slotsA[aIndex, 1], slotsB[bIndex, 1]);
                if (end - start > duration)
                {
                    return start;
                }

                if (slotsA[aIndex, 0] > slotsB[bIndex, 0])
                {
                    bIndex++;
                }
                else
                { 
                    aIndex++;
                }
            }
            return 0;
        }
    }
}
