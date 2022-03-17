using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms
{
    public class SolverNearestNeighbor : Solver
    {
        public SolverNearestNeighbor(List<City> cities) : base(cities)
        {
        }

        public override Tour Solve(City s)
        {
            Tour tour = new Tour();
            ResetVisitedCity();
            tour.Cities.Add(s);

            base.VisitedCity[s] = true;
            City next = null;

            while (base.VisitedCity.ContainsValue(false))
            {
                next = this.ClosestCity(s);
                base.VisitedCity[next] = true;
                tour.Cities.Add(next);
                s = next;
            }
            return tour;
        }
    }
}
