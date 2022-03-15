using LogicProject.networks;
using LogicProject.Utilities;
using System;
using System.Collections.Generic;
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



    }
}
