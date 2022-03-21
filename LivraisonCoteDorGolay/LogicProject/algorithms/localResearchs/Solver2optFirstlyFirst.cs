using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms.localResearchs
{
    public class Solver2optFirstlyFirst : SolverLocalResearch
    {
        public Solver2optFirstlyFirst(List<City> cities, Tour inputTour) : base(cities, inputTour)
        {

        }

        public override Tour Solve(City s = null)
        {
            Tour solvedTour = base.LocalResearch(base.InputTour);
            return solvedTour;
        }

        protected override Tour ExploreNeighborhood(Tour tour)
        {
            return null;
        }
    }
}
