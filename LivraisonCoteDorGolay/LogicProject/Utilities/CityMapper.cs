using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.Utilities
{
    public static class CityMapper
    {
        public static List<City> ShuffleCities(List<City> citiesToShuffle)
        {
            return Randomizer.Shuffle(citiesToShuffle);
        }

        public static void CrescentOrderCities(ref List<City> cities)
        {
            var ordered = cities.OrderBy(t => t.Id);
            cities = new List<City>(ordered);
        }

        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            if (indexB > -1 && indexB < list.Count)
            {
                T tmp = list[indexA];
                list[indexA] = list[indexB];
                list[indexB] = tmp;
            }
            return list;
        }


    }
}
