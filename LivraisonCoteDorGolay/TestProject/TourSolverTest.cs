using LogicProject.algorithmes;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestUnitsProject
{
    public class TourSolverTest
    {
        [Fact]
        public void ClosestNeighboursTest()
        {
            List<City> cities;
            cities = CityListGenerator.GenerateCitySetFromFileName("top80.txt");
            //cities = CityListGenerator.GenerateLinearCoordsCitySet(90);
            TourSolver ts = new TourSolver(cities);
            City firstCity = cities.ToArray()[0];
            Tour tour = ts.ClosestNeighbourMethod(firstCity);

            double expected = 50d;
            double actual = tour.Cost();

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ClosestCityTest()
        {
            TourSolver ts;
            ts = new TourSolver(CityListGenerator.GenerateCitySetFromFileName("top80.txt"));
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
            TourSolver ts = new TourSolver(cities);

            ts.ResetVisitedCity();

            bool expected = ts.VisitedCity.ContainsValue(true);
            bool actual = false;

            Assert.Equal(expected, actual);
        }
    }
}
