using LivraisonCoteDor.network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.networks
{
    public abstract class Tour
    {
        private List<City> cities;

        public Tour(List<City> cities)
        {
            this.cities = cities;
        }

        public string getTourString()
        {
            string res = "";

            if(cities != null)
            {
                foreach (City city in cities)
                    res += city.ToString() + "\n";
            }
            else res = "Empty tour";

            return res;
        }

    }
}
