using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.GreedyAlgorithm
{
    public class RadioCover
    {
        //1.选出这样一个广播台，即它覆盖了最多的未覆盖的州。即便这个广播台覆盖了一些已覆盖的州，也没有关系
        //2.重复第一步，直到覆盖了所有的州
        public List<HashSet<string>> MinConver(List<HashSet<string>> citiesList)
        { 
            HashSet<string> allCities = new HashSet<string>();
            foreach (var cities in citiesList)
            {
                foreach (var city in cities)
                {
                    allCities.Add(city);
                }
            }

            List<HashSet<string>> result = new List<HashSet<string>>();
            while (allCities.Count > 0)
            { 
                var longestCoveredCities = new HashSet<string>();
                HashSet<string> candidate = null;
                foreach (var cities in citiesList)
                {
                    var allCitiesCopy = allCities.ToList<string>().ToHashSet<string>();
                    allCitiesCopy.IntersectWith(cities);
                    if (allCitiesCopy.Count > longestCoveredCities.Count)
                    {
                        longestCoveredCities = allCitiesCopy;
                        candidate = cities;
                    }
                }
                if (candidate != null)
                {
                    allCities.ExceptWith(longestCoveredCities);
                    result.Add(candidate);
                }
            }
            return result;
        }
    }
}
