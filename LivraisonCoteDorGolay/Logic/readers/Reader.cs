using LivraisonCoteDor.network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDor.readers
{
    public abstract class Reader
    {
        private string _filepath;


        public Reader(string filepath)
        {
            this._filepath = filepath;
        }

        public abstract List<City> getExtractedCities();
    }

}
