using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms
{
    public class SolverNearInsertion : Solver
    {
        public SolverNearInsertion(List<City> cities) : base(cities)
        {
        }

        public override Tour Solve(City s)
        {
            List<City> citiesToVisit = new List<City>(base.Cities);
            DistantCitiesSolver dcs = new DistantCitiesSolver(base.Cities);
            Tour tour = new Tour();
            tour = dcs.GetMostDistantCities();
            citiesToVisit.Remove(tour.Cities.ElementAt(0));
            citiesToVisit.Remove(tour.Cities.ElementAt(1));

            City next = null;
            
            //Tant que toutes les villes n'ont pas été visité
            while(citiesToVisit.Count > 0)
            {
                double minimumCost = double.PositiveInfinity;
                double currDistance;

                foreach(City c in citiesToVisit)
                {
                    currDistance = c.CostSurplus(tour);
                    if(currDistance < minimumCost)
                    {
                        minimumCost = currDistance;
                        next = c;
                    }                   
                }
                tour.TourMinimumCostInsertion(next);
                citiesToVisit.Remove(next);
            }

            return tour;
        }
    }
}
