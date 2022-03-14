using LivraisonCoteDor.network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.networks
{
    public class TourCrescent : Tour
    {
        public TourCrescent(List<City> cities) : base(cities)
        {

        }

        public override string DisplayTour()
        {
            string res = "";
            if (base.Cities != null)
            {
                foreach (City city in base.Cities)
                    res += city.ToString() + "\n";
                res += "TOTAL COST: " + Cost();
            }
            else res = "Empty tour";
            return res;
        }
    }
}
