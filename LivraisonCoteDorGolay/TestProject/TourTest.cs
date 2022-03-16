using Logic.extractors;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace TestUnitsProject
{
    public class TourTest
    {
        [Fact]
        public void ConstructorTest()
        {
            Tour t1 = new Tour();
            List<City> expected = t1.Cities;

            Assert.NotNull(t1.Cities);
            Assert.Empty(t1.Cities);

            Tour t2 = new Tour(CityListGenerator.GenerateLinearCoordsCitySet(5));
            Assert.NotNull(t2.Cities);
            Assert.NotEmpty(t2.Cities);
            Assert.Equal(5, t2.Cities.Count);
        }

        [Fact]
        public void getCitiesFromTop80()
        {
            Tour tour = new Tour(CityListGenerator.GenerateCitySetFromFileName("top80.txt"));
            double expected = 2688.1913483752396d;
            double actual = tour.Cost;
            Assert.Equal(expected, actual);
        }

    }
}
