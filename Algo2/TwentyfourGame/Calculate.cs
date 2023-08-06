using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algo2.TwentyfourGame
{
    public class Calculate
    {
        public static List<string> GetTokens(string src)
        {
            var result = new List<string>();
            if (string.IsNullOrEmpty(src))
            {
                return result;
            }

            var pattern = "[0-9]+[\\.0-9]*|[\\(\\)+\\-\\*/]";
            var mathResult = Regex.Matches(src, pattern);
            for (var i = 0; i < mathResult.Count; i++)
            { 
                var item = mathResult[i];
                result.Add(item.Value);
            }
            return result;
        }
    }
}
