using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo2.Graph
{
    public class RailWayMap
    {
        public static List<string> GetCityNames()
        {
            var cities = new List<string>();
            cities.Add("哈尔滨");
            cities.Add("长春");
            cities.Add("沈阳");
            cities.Add("大连");

            cities.Add("呼和浩特");
            cities.Add("北京");
            cities.Add("天津");

            cities.Add("乌鲁木齐");
            cities.Add("银川");
            cities.Add("太原");
            cities.Add("石家庄");
            cities.Add("济南");
            cities.Add("青岛");

            cities.Add("西宁");
            cities.Add("兰州");
            cities.Add("西安");
            cities.Add("郑州");
            cities.Add("南京");
            cities.Add("上海");

            cities.Add("拉萨");
            cities.Add("成都");
            cities.Add("重庆");
            cities.Add("武汉");
            cities.Add("合肥");
            cities.Add("杭州");

            cities.Add("昆明");
            cities.Add("贵阳");
            cities.Add("长沙");
            cities.Add("南昌");
            cities.Add("宁波");

            cities.Add("南宁");
            cities.Add("广州");
            cities.Add("厦门");
            cities.Add("福州");

            cities.Add("海口");
            cities.Add("澳门");
            cities.Add("深圳");
            cities.Add("香港");

            return cities;
        }

        public static Dictionary<int, string> GetIndexDictionary()
        {
            var cities = GetCityNames();
            var result = new Dictionary<int, string>();
            for (var i = 0; i < cities.Count; i++)
            {
                result.Add(i, cities[i]);
            }
            return result;
        }

        public static Dictionary<string, int> GetCityDictionary()
        {
            var cities = GetCityNames();
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (var i = 0; i < cities.Count; i++)
            {
                result.Add(cities[i], i);
            }
            return result;
        }

        public static double?[,] BuildMatrix()
        {
            var cities = GetCityDictionary();
            var matrix = new double?[cities.Count, cities.Count];
            SetRailWayDistance("哈尔滨", "长春", 1, cities, matrix);
            SetRailWayDistance("长春", "沈阳", 1, cities, matrix);
            SetRailWayDistance("沈阳", "大连", 1.5, cities, matrix);
            SetRailWayDistance("沈阳", "北京", 3, cities, matrix);
            SetRailWayDistance("沈阳", "天津", 3.5, cities, matrix);
            SetRailWayDistance("大连", "天津", 4, cities, matrix);

            SetRailWayDistance("呼和浩特", "北京", 2, cities, matrix);
            SetRailWayDistance("北京", "天津", 0.5, cities, matrix);
            SetRailWayDistance("呼和浩特", "银川", 7.5, cities, matrix);
            SetRailWayDistance("呼和浩特", "太原", 4.5, cities, matrix);
            SetRailWayDistance("北京", "石家庄", 1, cities, matrix);
            SetRailWayDistance("天津", "石家庄", 1.5, cities, matrix);
            SetRailWayDistance("天津", "济南", 1, cities, matrix);

            SetRailWayDistance("银川", "太原", 6, cities, matrix);
            SetRailWayDistance("太原", "石家庄", 1.5, cities, matrix);
            SetRailWayDistance("石家庄", "济南", 2, cities, matrix);
            SetRailWayDistance("济南", "青岛", 1.5, cities, matrix);
            SetRailWayDistance("乌鲁木齐", "西宁", 9, cities, matrix);
            SetRailWayDistance("银川", "兰州", 7.5, cities, matrix);
            SetRailWayDistance("银川", "西安", 3, cities, matrix);
            SetRailWayDistance("太原", "西安", 3, cities, matrix);
            SetRailWayDistance("太原", "郑州", 2.5, cities, matrix);
            SetRailWayDistance("石家庄", "郑州", 1.5, cities, matrix);
            SetRailWayDistance("济南", "郑州", 3, cities, matrix);
            SetRailWayDistance("济南", "南京", 2, cities, matrix);
            SetRailWayDistance("青岛", "南京", 4.5, cities, matrix);
            SetRailWayDistance("青岛", "上海", 5, cities, matrix);

            SetRailWayDistance("西宁", "兰州", 1, cities, matrix);
            SetRailWayDistance("兰州", "西安", 2.5, cities, matrix);
            SetRailWayDistance("西安", "郑州", 2, cities, matrix);
            SetRailWayDistance("郑州", "南京", 3, cities, matrix);
            SetRailWayDistance("南京", "上海", 1, cities, matrix);
            SetRailWayDistance("西宁", "拉萨", 20, cities, matrix);
            SetRailWayDistance("兰州", "成都", 7, cities, matrix);
            SetRailWayDistance("西安", "成都", 3, cities, matrix);
            SetRailWayDistance("西安", "重庆", 4.5, cities, matrix);
            SetRailWayDistance("郑州", "武汉", 2, cities, matrix);
            SetRailWayDistance("郑州", "合肥", 2.5, cities, matrix);
            SetRailWayDistance("南京", "合肥", 1, cities, matrix);
            SetRailWayDistance("南京", "杭州", 1, cities, matrix);
            SetRailWayDistance("上海", "杭州", 1, cities, matrix);

            SetRailWayDistance("成都", "重庆", 1, cities, matrix);
            SetRailWayDistance("重庆", "武汉", 6, cities, matrix);
            SetRailWayDistance("武汉", "合肥", 1.5, cities, matrix);
            SetRailWayDistance("合肥", "杭州", 2, cities, matrix);
            SetRailWayDistance("成都", "贵阳", 3, cities, matrix);
            SetRailWayDistance("重庆", "贵阳", 2, cities, matrix);
            SetRailWayDistance("武汉", "长沙", 1, cities, matrix);
            SetRailWayDistance("武汉", "南昌", 2, cities, matrix);
            SetRailWayDistance("合肥", "南昌", 4, cities, matrix);
            SetRailWayDistance("杭州", "南昌", 2, cities, matrix);
            SetRailWayDistance("杭州", "宁波", 1, cities, matrix);

            SetRailWayDistance("昆明", "贵阳", 2, cities, matrix);
            SetRailWayDistance("贵阳", "长沙", 3, cities, matrix);
            SetRailWayDistance("长沙", "南昌", 1.5, cities, matrix);
            SetRailWayDistance("昆明", "南宁", 4, cities, matrix);
            SetRailWayDistance("贵阳", "南宁", 5, cities, matrix);
            SetRailWayDistance("贵阳", "广州", 4, cities, matrix);
            SetRailWayDistance("长沙", "广州", 2.5, cities, matrix);
            SetRailWayDistance("南昌", "厦门", 4.5, cities, matrix);
            SetRailWayDistance("南昌", "福州", 3, cities, matrix);
            SetRailWayDistance("宁波", "福州", 3.5, cities, matrix);

            SetRailWayDistance("南宁", "广州", 3, cities, matrix);
            SetRailWayDistance("厦门", "福州", 1.5, cities, matrix);
            SetRailWayDistance("广州", "海口", 10, cities, matrix);
            SetRailWayDistance("广州", "澳门", 1, cities, matrix);
            SetRailWayDistance("广州", "深圳", 0.5, cities, matrix);
            SetRailWayDistance("厦门", "深圳", 2.5, cities, matrix);

            SetRailWayDistance("深圳", "香港", 0.5, cities, matrix);

            return matrix;
        }

        private static void SetRailWayDistance(string from, string to, double hour, Dictionary<string, int> cities, double?[,] matrix)
        {
            if (!string.IsNullOrEmpty(from) && !string.IsNullOrEmpty(to))
            {
                if (from != to && cities.ContainsKey(from) && cities.ContainsKey(to))
                {
                    var fromIndex = cities[from];
                    var toIndex = cities[to];
                    matrix[fromIndex, toIndex] = hour;
                    matrix[toIndex, fromIndex] = hour;
                    return;
                }
            }
            throw new ArgumentException("city does not exists");
        }

        public static double FindShortestPathByBackTracking(string from, string to)
        {
            var matrix = BuildMatrix();
            var graph = new GraphAdjacentMatrix(matrix);
            var cityDictionary = GetCityDictionary();
            var fromIndex = cityDictionary[from];
            var toIndex = cityDictionary[to];
            var result = graph.FindShortestPathByBackTracking(fromIndex, toIndex);
            return result;
        }
    }
}
