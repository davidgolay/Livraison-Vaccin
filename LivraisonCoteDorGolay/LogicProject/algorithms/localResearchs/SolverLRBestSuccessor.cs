using LogicProject.networks;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms.localResearchs
{
    public class SolverLRBestSuccessor : SolverLocalResearch
    {
        public SolverLRBestSuccessor(List<City> cities, Tour inputTour) : base(cities, inputTour)
        {
        }

        public override Tour Solve(City s = null)
        {
            Tour solvedTour = base.LocalResearch(base.InputTour);
            return solvedTour;
        }

        protected override Tour ExploreNeighborhood(Tour tour)
        {
            List<City> cities = new List<City>(tour.Cities);
            Tour neighbor = new Tour(new List<City>(cities));
            Tour beestNeighboor = tour;
            List<Tour> tours = new List<Tour>();
            for (int i = 1; i < neighbor.Cities.Count - 2; i++)
            {
                double distance1 =
                        cities.ElementAt(i - 1).getDistanceWith(cities.ElementAt(i)) + cities.ElementAt(i + 1).getDistanceWith(cities.ElementAt(i + 2));
                double distance2 =
                        cities.ElementAt(i - 1).getDistanceWith(cities.ElementAt(i + 1)) + cities.ElementAt(i).getDistanceWith(cities.ElementAt(i + 2));
                if (distance1 > distance2)
                {
                    List<City> swapedTourCities = (List<City>)CityMapper.Swap(neighbor.Cities, i, i+1);
                    neighbor = new Tour(swapedTourCities);
                    tours.Add(neighbor);
                }
            }
            //il existe un meilleur voisin
            if (tours.Count > 0) beestNeighboor = BestNeighbor(tours);
            return beestNeighboor;
        }

        private Tour BestNeighbor(List<Tour> tours)
        {
            Tour bestTour = tours.ElementAt(0);
            double minimalCost = Double.PositiveInfinity;
            foreach (Tour t in tours)
            {
                double currentCost = t.Cost;
                if (currentCost < minimalCost)
                {
                    bestTour = t;
                    minimalCost = currentCost;
                }
            }
            return bestTour;
        }
    }
}
