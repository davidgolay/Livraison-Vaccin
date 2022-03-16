using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithmes
{
    public class TourSolverNearestNeighborAdvanced : TourSolver
    {
        public TourSolverNearestNeighborAdvanced(List<City> cities) : base(cities)
        {

        }

        public override Tour Solve(City s)
        {
            TourSolverNearestNeighbor tscn = new TourSolverNearestNeighbor(base.Cities);

            List<Tour> tours = new List<Tour>();

            foreach(City c in base.Cities)
            {
                tours.Add(tscn.Solve(c));
            }

            Tour bestComputedSolution = base.BestTourSolution(tours);

            return bestComputedSolution;
        }


    }
}
