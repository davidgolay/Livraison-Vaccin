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
        private float _lt;
        private float _lg;
        #endregion

        #region Properties
        public int Id { get => this._id; }

        public string Name { get => this._name; }

        public float Longitude { get => this._lg; }

        public float Latitude { get => this._lt; }
        #endregion

        public City(int id, String name, float lt, float lg)
        {
            this._id = id;
            this._name = name;
            this._lt = lt;
            this._lg = lg;
        }

    }

}
