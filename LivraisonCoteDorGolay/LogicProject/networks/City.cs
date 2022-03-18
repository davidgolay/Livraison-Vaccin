using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.networks
{
    public class City
    {
        #region Attributes
        private int id;
        private string name;
        private double latitude;
        private double longitude;
        #endregion

        #region Properties
        public int Id { get => this.id; }

        public string Name { get => this.name; }

        public double Longitude { get => this.longitude; }

        public double Latitude { get => this.latitude; }
        #endregion

        public City(int id, String name, double latitude, double longitude)
        {
            this.id = id;
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
        }

        /// <summary>
        /// Compute the distance of this instance city with the city passed in params
        /// </summary>
        /// <param name="otherCity">The other city</param>
        /// <returns>Distance between Instance City and city passed in params</returns>
        public double getDistanceWith(City otherCity)
        {
            double x1 = this.Longitude;      
            double y1 = this.Latitude;
            double x2 = otherCity.Longitude;
            double y2 = otherCity.Latitude;
            return MyMath.GetDistanceBetweenDegreesCoordinates(x1, y1, x2, y2);
        }

        /// <summary>
        /// Compute the detour cost going from A to B passing by detour City
        /// </summary>
        /// <param name="detour">Detour city</param>
        /// <param name="A">starting city</param>
        /// <param name="B">lasting city</param>
        /// <returns></returns>
        public double CostDetour(City A, City B)
        {
            double detourCost;
            double dAV = A.getDistanceWith(this);
            double dVB = this.getDistanceWith(B);
            double dAB = A.getDistanceWith(B);
            detourCost = dAV + dVB - dAB;        
            return detourCost;
        }

        public double CostSurplus(Tour tour)
        {
            double minimumCost = double.PositiveInfinity;

            for (int i = 0; i < tour.Cities.Count - 1; i++)
            {
                City c1 = tour.Cities.ElementAt(i);
                City c2 = tour.Cities.ElementAt(i + 1);
                double currentCost = this.CostDetour(c1, c2);

                if (currentCost < minimumCost)
                {
                    minimumCost = currentCost;
                }
            }
            return minimumCost;
        }


        public override string ToString()
        {
            string res = "[" + this.id + "] " + this.name;
            return res;
        }


    }

}
