using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms
{
    public class SolverNearestNeighborAdvanced : Solver
    {
        public SolverNearestNeighborAdvanced(List<City> cities) : base(cities)
        {
        }

        public override Tour Solve(City s)
        {
            SolverNearestNeighbor tscn = new SolverNearestNeighbor(base.Cities);
            List<Tour> tours = new List<Tour>();

            foreach(City c in base.Cities)
                tours.Add(tscn.Solve(c));

            Tour bestComputedSolution = base.BestTourSolution(tours);
            return bestComputedSolution;
        }
    }
}
