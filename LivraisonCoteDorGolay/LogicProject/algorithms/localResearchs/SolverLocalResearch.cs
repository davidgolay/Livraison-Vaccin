using LogicProject.networks;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithms
{
    public abstract class SolverLocalResearch : Solver
    {
        private Tour inputTour;

        public Tour InputTour
        {
            get { return this.inputTour; }
        }

        protected SolverLocalResearch(List<City> cities, Tour inputTour) : base(cities)
        {
            this.inputTour = inputTour;
        }

        protected Tour LocalResearch(Tour inputTour)
        {
            Tour currentTour = inputTour;
            bool finished = false;

            while (!finished)
            {
                finished = true;

                Tour neighborTour = ExploreNeighborhood(currentTour);
                if (neighborTour.Cost < currentTour.Cost)
                {
                    currentTour = neighborTour;
                    finished = false;
                }
            }

            return currentTour;
        }

        protected abstract Tour ExploreNeighborhood(Tour tour);

        protected void SwapIfBetter(ref Tour tour, City c1, City c2)
        {
            Tour outputTour = (Tour)tour.Clone();

            int indexC1 = outputTour.Cities.IndexOf(c1);
            int indexC2 = outputTour.Cities.IndexOf(c2);

            List<City> swapedTourCities = (List<City>) CityMapper.Swap(outputTour.Cities, indexC1, indexC2);
            outputTour = new Tour(swapedTourCities);

            if (outputTour.Cost < tour.Cost)
            {
                tour = outputTour;
            }
        }

    }
}
