using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitsProject
{
    public class SolverNearestNeighborAdvancedTest
    {
        [Fact]
        public void NearestNeighborAdvancedTest()
        {
            List<City> cities;
            cities = CityListGenerator.GenerateCitySetFromFileName("top80.txt");
            Solver tscna = new SolverNearestNeighborAdvanced(cities);

            double expected = 674;
            double actual = tscna.Solve(null).Cost;

            Assert.Equal(Math.Round(expected), Math.Round(actual));
        }
    }
}
