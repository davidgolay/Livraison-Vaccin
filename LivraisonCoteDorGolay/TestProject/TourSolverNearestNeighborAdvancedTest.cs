using LogicProject.algorithmes;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitsProject
{
    public class TourSolverNearestNeighborAdvancedTest
    {
        [Fact]
        public void NearestNeighborAdvancedTest()
        {
            List<City> cities;
            cities = CityListGenerator.GenerateCitySetFromFileName("top80.txt");
            TourSolver ts = new TourSolverNearestNeighbor(cities);
            City firstCity = cities.ToArray()[0];
            Tour tour = ts.Solve(firstCity);

            double expected = 713;
            double actual = tour.Cost;

            Assert.Equal(Math.Round(expected), Math.Round(actual));
        }
    }
}
