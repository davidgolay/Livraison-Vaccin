using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms.localResearchs
{
    public class SolverLRFirstlyFirst : SolverLocalResearch
    {
        public SolverLRFirstlyFirst(List<City> cities, Tour inputTour) : base(cities, inputTour)
        {
        }

        public override Tour Solve(City s = null)
        {
            Tour solvedTour = base.LocalResearch(base.InputTour);
            return solvedTour;
        }

        protected override Tour ExploreNeighborhood(Tour tour)
        {
            Tour currentTour = (Tour) tour.Clone();

            return currentTour;
        }
    }
}
