using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestUnitsProject
{
    public class SolverNearestNeighborTest
    {
        [Fact]
        public void NearestNeighborTest()
        {
            List<City> cities;
            cities = CityListGenerator.GenerateCitySetFromFileName("top80.txt");
            //cities = CityListGenerator.GenerateLinearCoordsCitySet(90);
            Solver ts = new SolverNearestNeighbor(cities);
            City firstCity = cities.ToArray()[0];
            Tour tour = ts.Solve(firstCity);

            double expected = 713;
            double actual = tour.Cost;

            Assert.Equal(Math.Round(expected), Math.Round(actual));
        }



    }
}
