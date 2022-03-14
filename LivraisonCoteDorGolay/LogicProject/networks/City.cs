using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDor.network
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

        public double getDistanceBetween(City firstCity, City otherCity)
        {
            double x1 = firstCity.Longitude;
            double y1 = firstCity.Latitude;
            double x2 = otherCity.Longitude;
            double y2 = otherCity.Latitude;
            return MyMath.GetDistanceBetweenDegreesCoordinates(x1, y1, x2, y2);
        }

        public override string ToString()
        {
            string res = "ID: " + this.id + " NAME: " + this.name;
            return res;
        }

    }

}
