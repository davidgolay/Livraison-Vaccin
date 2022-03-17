using LogicProject;
using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitsProject
{
    public class SolverNearInsertionTest
    {
        [Fact]
        public void SolveTest()
        {
            List<City> cities;
            cities = CityListGenerator.GenerateCitySetFromFileName("top80.txt");
            Solver tscna = new SolverNearInsertion(cities);

            //string sexpected = "";
            //string sactual = tscna.Solve(null).DisplayTour();
            //Assert.Equal(sexpected, sactual);

            double expected = 618.10d;
            double actual = tscna.Solve(null).Cost;

            Assert.Equal(Math.Round(expected, 2), Math.Round(actual, 2));
        }
    }
}
