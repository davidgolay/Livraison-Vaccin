using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.networks
{
    public class Tour : ICloneable
    {
        private List<City> cities;
        private double cost;

        public List<City> Cities { get => this.cities; }

        public double Cost
        {
            get {
                double cost = 0;
                City current;
                City next;

                for (int cur = 0; cur < cities.Count - 1; cur++)
                {
                    current = cities.ToArray()[cur];
                    next = cities.ToArray()[cur + 1];
                    cost += current.getDistanceWith(next);
                }

                // Add the distance to starting point
                City firstCity = cities.ToArray()[0];
                current = cities.ToArray()[cities.Count - 1];
                cost += current.getDistanceWith(firstCity);
                return cost;
            }
        }

        public Tour(List<City> cities=null)
        {
            if (cities == null) { this.cities = new List<City>(); }
            else { this.cities = new List<City>(cities); }
        }

        public void TourMinimumCostInsertion(City cityToInsert)
        {
            double minimumCost = double.PositiveInfinity;
            int indexOfInsertion = 0;
            double currentCost;

            for (int i = 0; i < this.Cities.Count - 1; i++)
            {
                City c1 = this.Cities.ElementAt(i);
                City c2 = this.Cities.ElementAt(i + 1);
                currentCost = cityToInsert.CostDetour(c1, c2);

                if (currentCost < minimumCost)
                {
                    minimumCost = currentCost;
                    indexOfInsertion = i+1;
                }
            }

            City lastCity = this.Cities.ElementAt(this.Cities.Count - 1);
            City firstCity = this.Cities.ElementAt(0);

            currentCost = cityToInsert.CostDetour(lastCity, firstCity);
            if (currentCost < minimumCost)
                this.Cities.Insert(0, cityToInsert);
            else
                this.Cities.Insert(indexOfInsertion, cityToInsert);
        }

        public string DisplayTour()
        {
            string res = "";
            if (this.cities != null)
            {
                foreach (City city in this.cities)
                    res += city.ToString() + "\n";
            }
            else res = "Empty tour";
            return res;
        }

        public object Clone()
        {
            return new Tour(this.Cities);
        }
    }
}
