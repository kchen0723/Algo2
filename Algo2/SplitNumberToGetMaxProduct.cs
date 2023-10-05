using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2
{
    public class SplitNumberToGetMaxProduct
    {
        //How to split number so we can get max product 
        public static int GetMaxProductBySplitNumber(int num)
        {
            if (num < 0)
            {
                return 0;
            }
            int power = num / 3;
            int mod = num % 3;
            if(mod == 0)
            {
                return (int)Math.Pow(3, power);        //split so every number is 3, then the product is the 3 pow.
            }
            else if(mod == 1) 
            {
                return 4 * (int)Math.Pow(3, power - 1);  //split so every number is 3, but the last one is 4.
            }
            else if(mod == 2)
            {
                return 2 * (int)Math.Pow(3, power);  //split so every number is 3, except the last one is 2.
            }
            return 0;
        }
    }
}
