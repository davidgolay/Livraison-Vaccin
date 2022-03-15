using LogicProject.networks;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithmes
{
    public class TourSolver
    {

        private Dictionary<City, bool> visitedCity = new Dictionary<City, bool>();
        private List<City> cities;

        public Dictionary<City, bool> VisitedCity { get => this.visitedCity; }

        public List<City> Cities { get => this.cities;  }

        public TourSolver(List<City> cities)
        {
            this.cities = new List<City>(cities);
        }

        public Tour ClosestNeighbourMethod(City s)
        {
            Tour tour = new Tour();
            ResetVisitedCity();
            tour.Cities.Add(s);
            this.visitedCity[s] = true;
            City next = null;

            while (this.visitedCity.ContainsValue(false))
            {
                next = this.ClosestCity(s);
                this.visitedCity[next] = true;
                tour.Cities.Add(next);
                s = next;
            }
            return tour;
        }



        public City ClosestCity(City targetCity, bool unvisitedOnly = true )
        {
            City closestCity = null;
            double minimumDistance = double.PositiveInfinity;
            double distance;
            bool updatingClosestCondition;

            foreach (City currentCity in cities)
            {
                distance = currentCity.getDistanceWith(targetCity);

                updatingClosestCondition = (distance < minimumDistance) && (targetCity != currentCity);
                if (unvisitedOnly){ updatingClosestCondition = updatingClosestCondition && (this.visitedCity[currentCity] == false); }

                if (updatingClosestCondition)
                {
                    minimumDistance = distance;
                    closestCity = currentCity;
                }
            }
            return closestCity;
        }

        public void ResetVisitedCity()
        {      
            foreach (City c in this.cities)
                this.visitedCity[c] = false;
        }
    }
}
