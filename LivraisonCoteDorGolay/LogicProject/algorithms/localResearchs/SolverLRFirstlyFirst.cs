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
            Tour neighborTour = (Tour)tour.Clone();
            for (int i=0; i<currentTour.Cities.Count-1; i++)
            {
                City c1 = currentTour.Cities.ElementAt(i);
                City c2 = currentTour.Cities.ElementAt(i+1);
                SwitchIfBetter(ref neighborTour, c1, c2 );
            }
            return neighborTour;
        }
    }
}
