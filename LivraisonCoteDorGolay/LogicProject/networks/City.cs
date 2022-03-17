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
        public double DetourCost(City A, City B)
        {
            double detourCost;
            detourCost = A.getDistanceWith(this) + this.getDistanceWith(B) - A.getDistanceWith(B);        
            return detourCost;
        }

        public double DetourCost(Tour tour)
        {
            City c1;
            City c2;
            double minimumCost = double.PositiveInfinity;
            double currentCost;

            for (int i = 0; i < tour.Cities.Count - 1; i++)
            {
                c1 = tour.Cities.ElementAt(i);
                c2 = tour.Cities.ElementAt(i + 1);
                currentCost = this.DetourCost(c1, c2);

                if (currentCost < minimumCost)
                {
                    minimumCost = currentCost;
                }
            }
            return minimumCost;
        }

        public Tour TourDetourBy(Tour tour)
        {
            City c1;
            City c2;
            Tour newTour = null;
            double minimumCost = double.PositiveInfinity;
            double currentCost;

            for(int i = 0; i<tour.Cities.Count-1; i++)
            {
                c1 = tour.Cities.ElementAt(i);
                c2 = tour.Cities.ElementAt(i + 1);
                currentCost = this.DetourCost(c1, c2);

                if(currentCost < minimumCost)
                {
                    newTour = tour;
                    newTour.Cities.Insert(i, this);
                }
            }
            return newTour;
        }



        public override string ToString()
        {
            string res = "ID: " + this.id + " NAME: " + this.name;
            return res;
        }


    }

}
