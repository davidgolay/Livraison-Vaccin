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
        private int _id;
        private string _name;
        private double _lt;
        private double _lg;
        #endregion

        #region Properties
        public int Id { get => this._id; }

        public string Name { get => this._name; }

        public double Longitude { get => this._lg; }

        public double Latitude { get => this._lt; }
        #endregion

        public City(int id, String name, double lt, double lg)
        {
            this._id = id;
            this._name = name;
            this._lt = lt;
            this._lg = lg;
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

    }

}
