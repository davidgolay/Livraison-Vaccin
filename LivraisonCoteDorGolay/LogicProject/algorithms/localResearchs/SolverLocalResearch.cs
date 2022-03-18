using LogicProject.networks;
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
    }
}
