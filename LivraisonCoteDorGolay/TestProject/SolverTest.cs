using LogicProject.algorithms;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestUnitsProject
{
    public class SolverTest
    {
        [Fact]
        public void ClosestCityTest()
        {
            Solver ts;
            ts = new SolverNearestNeighbor(CityListGenerator.GenerateCitySetFromFileName("top80.txt"));
            ts.ResetVisitedCity();

            City DijonExpectedClosest = ts.ClosestCity(ts.Cities.ToArray()[0]);
            City DijonActualClosest = ts.Cities.ToArray()[3]; //actually 'Talant' 

            Assert.Equal(DijonExpectedClosest, DijonActualClosest);
            Assert.Equal(DijonExpectedClosest.Id, DijonActualClosest.Id);

            City ArcSurTilleExpectedClosest = ts.ClosestCity(ts.Cities.ToArray()[22]); //'Arc sur tille' closest
            City ArcSurTilleActualClosest = ts.Cities.ToArray()[30]; //actually 'Couternon'

            Assert.Equal(ArcSurTilleExpectedClosest, ArcSurTilleActualClosest);
            Assert.Equal(ArcSurTilleExpectedClosest.Id, ArcSurTilleActualClosest.Id);

            City GevreyExpectedClosest = ts.ClosestCity(ts.Cities.ToArray()[17]); //'Gevrey' closest
            City GevreyActualClosest = ts.Cities.ToArray()[14]; //actually 'Marsannay la cote'

            Assert.Equal(GevreyExpectedClosest, GevreyActualClosest);
            Assert.Equal(GevreyExpectedClosest.Id, GevreyActualClosest.Id);
        }

        [Fact]
        public void ResetVisitedTest()
        {
            List<City> cities = CityListGenerator.GenerateLinearCoordsCitySet(5);
            Solver ts = new SolverNearestNeighbor(cities);

            ts.ResetVisitedCity();

            bool expected = ts.VisitedCity.ContainsValue(true);
            bool actual = false;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BestTourSolutionTest()
        {
            Solver ts = new SolverNearestNeighbor(null);
            Tour t1 = new Tour(CityListGenerator.GenerateLinearCoordsCitySet(5));
            Tour t2 = new Tour(CityListGenerator.GenerateLinearCoordsCitySet(10));
            Tour t3 = new Tour(CityListGenerator.GenerateLinearCoordsCitySet(3));
            List<Tour> tours = new List<Tour>();
            tours.Add(t1);
            tours.Add(t2);
            tours.Add(t3);

            Tour expected = t3;
            Tour actual = ts.BestTourSolution(tours);

            Assert.Equal(expected, actual);

        }
    }
}
