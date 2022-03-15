using LivraisonCoteDor.network;
using Logic.generators;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace TestProject
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
            TourCrescent tour = new TourCrescent(ce.ExtractCitiesFromLines(lines));

            double expected = 2688.1913483752396d;
            double actual = tour.Cost();

            Assert.Equal(expected, actual);
        }
    }
}
