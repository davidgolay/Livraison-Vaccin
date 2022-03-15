using LivraisonCoteDor.network;
using LogicProject.networks;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.algorithmes
{
    public class TourSolver
    {

        private IDictionary<City, bool> visitedCity = new Dictionary<City, bool>();
        private List<City> cities;

        public TourSolver(List<City> cities)
        {
            this.cities = new List<City>(cities);
        }

        public Tour ClosestNeighbour(City nextCity)
        {
            Tour tour = null;

            foreach(City c in cities)
            {
                this.visitedCity[c] = false;
            }



            return tour;
        }



    }
}
