using LivraisonCoteDor.network;
using Logic.generators;
using LogicProject.networks;
using LogicProject.Utilities;
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
        public void getCitiesFromTop80()
        {
            string fileName = "top80.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\" + fileName);

            List<string> lines = File.ReadLines(path, Encoding.UTF8).ToList();
            CityExtractorTxt ce = new CityExtractorTxt();
            Tour tour = new Tour(ce.ExtractCitiesFromLines(lines));

            double expected = 2688.1913483752396d;
            double actual = tour.Cost();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClosestCity()
        {
            Tour tour = new Tour(CityListGenerator.GenerateLinearCoordsCitySet(5));

            City firstCity = tour.Cities.ToArray()[0];

            City expected = tour.Cities.ToArray()[1];
            City actual = tour.ClosestCity(firstCity);

            Assert.Equal(expected.Id, actual.Id);


        }
    }
}
