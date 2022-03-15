using Logic.extractors;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestUnitsProject
{
    public class CityListGenerator
    {
        public static List<City> GenerateLinearCoordsCitySet(int wanted, double spreadSize=1d)
        {
            List<City> cities = new List<City>();

            for(int i=0; i<wanted; i++)
            {
                cities.Add(new City(i, "Ville", (double)i*spreadSize, (double)i*spreadSize));
            }
            return cities;
        }

        public static List<City> GenerateCitySetFromFileName(string fileName)
        {
            string startupPath = Environment.CurrentDirectory;
            string path;
            //path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\" + fileName);
            path = Path.Combine(startupPath, @"Data\" + fileName);
            List<string> lines = File.ReadLines(path, Encoding.UTF8).ToList();
            CityExtractorTxt ce = new CityExtractorTxt();
            return (ce.ExtractCitiesFromLines(lines));
        }

        [Fact]
        public void GenerateLinearCoordsCitySetTest()
        {
            int nbCity = 5;
            double spread = 1.5d;

            List<City> cities = GenerateLinearCoordsCitySet(nbCity, spread);

            double expectedId;
            double actualId;
            double expectedLatitude;
            double actualLatitude;
            double expectedLongitude;
            double actualLongitude;

            Assert.NotNull(cities);
            Assert.NotEmpty(cities);

            for (int i = 0; i < nbCity; i++)
            {
                expectedId = i;
                actualId = cities.ToArray()[i].Id;

                expectedLatitude = (double) i*spread;
                actualLatitude = cities.ToArray()[i].Latitude;

                expectedLongitude = (double) i*spread;
                actualLongitude = cities.ToArray()[i].Longitude;

                Assert.Equal(expectedId, actualId);
                Assert.Equal(expectedLatitude, actualLatitude);
                Assert.Equal(expectedLongitude, actualLongitude);
            }

        }
    }
}
