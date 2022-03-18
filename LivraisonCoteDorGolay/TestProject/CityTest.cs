using LogicProject.networks;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestUnitsProject
{
    public class CityTest
    {
        [Fact]
        public void getDistanceWithTest()
        {
            City c1 = new City(1, "Dijon", 47.3167d, 5.01667d);
            City c2 = new City(2, "Beaune", 47.0333d, 4.83333d);
            double expected = 34.425096765231004d;
            double actual = c1.getDistanceWith(c2);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CostDetour()
        {
            City c1 = new City(1, "Dijon", 47.3167d, 5.01667d);
            City c2 = new City(2, "Beaune", 47.0333d, 4.83333d);
            City detour = new City(24, "SEURRE", 47d, 5.15d);

            double expected = 26.496d;
            double actual = detour.CostDetour(c1, c2);
            Assert.Equal(expected, Math.Round(actual, 3));
        }

        [Fact]
        public void CostSurplus()
        {
            City c1 = new City(1, "Dijon", 47.3167d, 5.01667d);
            City c2 = new City(2, "Beaune", 47.0333d, 4.83333d);
            City c3 = new City(18, "GEVREY-CHAMBERTIN", 47.2333d, 4.95d);
            City detour = new City(18, "NUITS-SAINT-GEORGES", 47.1333, 4.95d);

            List<City> cities = new List<City>();
            cities.Add(c1);
            cities.Add(c2);
            cities.Add(c3);

            Tour tour = new Tour(cities);

            double expected = 0.782d;
            double actual = detour.CostSurplus(tour);
            Assert.Equal(expected, Math.Round(actual, 3));
        }

    }
}
