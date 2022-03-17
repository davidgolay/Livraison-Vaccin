using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms
{
    public class DistantCitiesSolver : Solver
    {
        public DistantCitiesSolver(List<City> cities) : base(cities)
        {
        }

        public Tour GetMostDistantCities()
        {
            List<City> mostDistantCities = new List<City>();
            City c1 = null;
            City c2 = null;

            double currDistance;
            double maxDistance = double.NegativeInfinity;

            for (int i = 0; i < base.Cities.Count; i++)
            {
                for (int j = 0; j < base.Cities.Count; j++)
                {
                    currDistance = base.Cities.ElementAt(i).getDistanceWith(base.Cities.ElementAt(j));
                    if (currDistance > maxDistance)
                    {
                        maxDistance = currDistance;
                        c1 = base.Cities.ElementAt(i);
                        c2 = base.Cities.ElementAt(j);
                    }
                }
            }
            mostDistantCities.Add(c1);
            mostDistantCities.Add(c2);

            return new Tour(mostDistantCities);
        }

        public override Tour Solve(City s)
        {
            return GetMostDistantCities();
        }
    }
}
