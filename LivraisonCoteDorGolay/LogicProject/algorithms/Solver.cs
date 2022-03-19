using LogicProject.networks;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms
{
    public abstract class Solver
    {

        private Dictionary<City, bool> visitedCity = new Dictionary<City, bool>();
        private List<City> cities;
        private string name;

        public Dictionary<City, bool> VisitedCity { get => this.visitedCity; }

        public List<City> Cities { get => this.cities;  }
        public string Name { get => name; set => name = value; }

        public Solver(List<City> cities)
        {
            if(cities != null) 
                this.cities = new List<City>(cities);
        }

        public abstract Tour Solve(City s=null);

        public City ClosestCity(City targetCity, bool unvisitedOnly = true)
        {
            City closestCity = null;
            double minDistance = double.PositiveInfinity;
            double distance;
            bool updateCondition;

            foreach (City currentCity in cities)
            {
                distance = currentCity.getDistanceWith(targetCity);

                updateCondition = (distance < minDistance) && (targetCity != currentCity);
                if (unvisitedOnly){ updateCondition = updateCondition && (this.visitedCity[currentCity] == false); }

                if (updateCondition)
                {
                    minDistance = distance;
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

        public Tour BestTourSolution(List<Tour> tours)
        {
            double bestCost = double.PositiveInfinity;
            Tour bestTour = null;

            foreach(Tour currentTour in tours)
            {
                if(currentTour.Cost < bestCost)
                {
                    bestTour = currentTour;
                    bestCost = currentTour.Cost;
                }
            }
            return bestTour;
        }
    }
}
