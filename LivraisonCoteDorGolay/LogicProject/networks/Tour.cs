using LivraisonCoteDor.network;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.networks
{
    public class Tour
    {
        private List<City> cities;

        public List<City> Cities { get => this.cities; }

        public Tour(List<City> cities)
        {
            this.cities = new List<City>(cities);
        }

        public double Cost()
        {
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


        public City ClosestCity(City targetCity)
        {
            City closestCity = null;
            double minimumDistance = double.PositiveInfinity;
            double distance;
            bool updatingClosestCondition;

            foreach(City currentCity in this.cities)
            {
                distance = currentCity.getDistanceWith(targetCity);
                updatingClosestCondition = (distance < minimumDistance) && (targetCity != currentCity);

                if (updatingClosestCondition)
                {
                    minimumDistance = distance;
                    closestCity = currentCity;
                }
            }
            return closestCity;
        }

        public string DisplayTour()
        {
            string res = "";
            if (this.cities != null)
            {
                foreach (City city in this.cities)
                    res += city.ToString() + "\n";
                res += "TOTAL COST: " + Cost();
            }
            else res = "Empty tour";
            return res;
        }


    }
}
