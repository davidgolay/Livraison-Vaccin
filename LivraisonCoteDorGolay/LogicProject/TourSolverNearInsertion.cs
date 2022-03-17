using LogicProject.algorithmes;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject
{
    public class TourSolverNearInsertion : TourSolver
    {
        public TourSolverNearInsertion(List<City> cities) : base(cities)
        {
        }

        public override Tour Solve(City s)
        {
            Tour tour = new Tour();
            List<City> citiesToVisit = new List<City>(base.Cities);
            ResetVisitedCity();
            DistantCitiesSolver dcs = new DistantCitiesSolver();
            tour = dcs.GetMostDistantCities(base.Cities);
            base.VisitedCity[tour.Cities.ElementAt(0)] = true;
            base.VisitedCity[tour.Cities.ElementAt(1)] = true;
            City next = null;
            
            while (base.VisitedCity.ContainsValue(false))
            {            
                double currCost;
                double minCost = double.PositiveInfinity;
                foreach (City c in citiesToVisit)
                {
                    currCost = c.DetourCost(tour);
                    if(currCost < minCost)
                    {
                        minCost = currCost;
                        next = c;
                    }
                }
            }
            return tour;
        }
    }
}
