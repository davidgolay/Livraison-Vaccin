using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.Utilities
{
    public class CityMapper
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

    }
}
