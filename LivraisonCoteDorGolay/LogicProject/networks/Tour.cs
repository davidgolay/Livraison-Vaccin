using LivraisonCoteDor.network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.networks
{
    public abstract class Tour
    {
        private List<City> cities;

        public List<City> Cities { get => this.cities; }

        public Tour(List<City> cities)
        {
            this.cities = cities;
        }

        public double Cost()
        {
            double cost = 0;
            City current;
            City next;

            for (int cur=0; cur < cities.Count - 1; cur++)
            {
                current = cities.ToArray()[cur];
                next = cities.ToArray()[cur + 1];
                cost += current.getDistanceWith(next);
            }

            City firstCity = cities.ToArray()[0];
            current = cities.ToArray()[cities.Count - 1];
            cost += current.getDistanceWith(firstCity);
            return cost;
        }

        public abstract string DisplayTour();

    }
}
