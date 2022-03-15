﻿using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicProject.networks
{
    public class Tour
    {
        private List<City> cities;

        public List<City> Cities { get => this.cities; }

        public Tour(List<City> cities=null)
        {
            if (cities == null) { this.cities = new List<City>(); }
            else { this.cities = new List<City>(cities); }
        }

        public double Cost()
        {
            double cost = 0;
            City current;
            City next;

            for (int cur = 0; cur < cities.Count - 1; cur++)
            {
                current = cities.ToArray()[cur];
                next = cities.ToArray()[cur + 1];
                cost += current.getDistanceWith(next);
            }

            // Add the distance to starting point
            City firstCity = cities.ToArray()[0];
            current = cities.ToArray()[cities.Count - 1];
            cost += current.getDistanceWith(firstCity);
            return cost;
        }

        public string DisplayTour()
        {
            string res = "";
            if (this.cities != null)
            {
                foreach (City city in this.cities)
                    res += city.ToString() + "\n";
                res += "TOTAL COST: " + Cost();
            }
            else res = "Empty tour";
            return res;
        }


    }
}
