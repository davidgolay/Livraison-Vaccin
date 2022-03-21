using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms.localResearchs
{
    public class SolverLRPremierQuelconque : SolverLocalResearch
    {
        public SolverLRPremierQuelconque(List<City> cities, Tour inputTour) : base(cities, inputTour)
        {
        }

        public override Tour Solve(City s = null)
        {
            Tour solvedTour = base.LocalResearch(base.InputTour);
            return solvedTour;
        }

        protected override Tour ExploreNeighborhood(Tour tour)
        {
            Tour currentTour = (Tour)tour.Clone();
            Tour neighborTour = (Tour)tour.Clone();
            for (int i = 0; i < currentTour.Cities.Count - 1; i++)
            {
                for(int j = 0; j< currentTour.Cities.Count; j++)
                {
                    City c1 = currentTour.Cities.ElementAt(i);
                    City c2 = currentTour.Cities.ElementAt(j);
                    SwapIfBetter(ref neighborTour, c1, c2);
                }
            }
            return neighborTour;
        }
    }
}
