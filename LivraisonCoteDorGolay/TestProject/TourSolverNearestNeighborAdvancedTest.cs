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
            TourSolver tscna = new TourSolverNearestNeighborAdvanced(cities);

            double expected = 674;
            double actual = tscna.Solve(null).Cost;

            Assert.Equal(Math.Round(expected), Math.Round(actual));
        }
    }
}
