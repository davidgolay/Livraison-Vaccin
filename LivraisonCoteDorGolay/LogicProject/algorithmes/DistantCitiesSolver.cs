using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithmes
{
    public class DistantCitiesSolver
    {
        public Tour GetMostDistantCities(List<City> cities)
        {
            City s = cities.ElementAt(0);
            List<City> mostDistantCities = new List<City>();
            City c1 = null;
            City c2 = null;

            double currDistance;
            double maxDistance = double.NegativeInfinity;

            for (int i = 0; i < cities.Count; i++)
            {
                for (int j = 0; j < cities.Count; j++)
                {
                    currDistance = cities.ElementAt(i).getDistanceWith(cities.ElementAt(j));
                    if (currDistance > maxDistance)
                    {
                        maxDistance = currDistance;
                        c1 = cities.ElementAt(i);
                        c2 = cities.ElementAt(j);
                    }
                }
            }
            mostDistantCities.Add(c1);
            mostDistantCities.Add(c2);

            return new Tour(mostDistantCities);
        }
    }
}
