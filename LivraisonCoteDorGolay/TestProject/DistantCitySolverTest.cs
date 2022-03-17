using LogicProject.algorithmes;
using LogicProject.networks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestUnitsProject
{
    public class DistantCitySolverTest
    {
        [Fact]
        public void GetMostDistantCitiesTest()
        {
            DistantCitiesSolver solver = new DistantCitiesSolver();
            List<City> cities = CityListGenerator.GenerateLinearCoordsCitySet(5);
            Tour distantCouple = solver.GetMostDistantCities(cities);

            City firstExpected = cities.ElementAt(0);
            City firstActual = distantCouple.Cities.ElementAt(0);

            City secondExpected = cities.ElementAt(4);
            City secondActual = distantCouple.Cities.ElementAt(1);

            Assert.Equal(firstExpected, firstActual);
            Assert.Equal(secondExpected, secondActual);


            //With custom data set 
            solver = new DistantCitiesSolver();
            City c1 = new City(1, "c1", 2, 0); //|        c3   |
            City c2 = new City(2, "c2", 3, 0); //|             |
            City c3 = new City(3, "c3", 6, 3); //|             |
            City c4 = new City(4, "c4", 6, 0); //|  c1 c2 c4   |

            cities.Clear();
            cities.Add(c1); cities.Add(c2); cities.Add(c3); cities.Add(c4);
            distantCouple = solver.GetMostDistantCities(cities);

            firstExpected = cities.ElementAt(0); //c1 expected
            firstActual = distantCouple.Cities.ElementAt(0);

            secondExpected = cities.ElementAt(2); //c3 expected
            secondActual = distantCouple.Cities.ElementAt(1);

            Assert.Equal(firstExpected, firstActual);
            Assert.Equal(secondExpected, secondActual);


            //With real data set 
            solver = new DistantCitiesSolver();
            cities = CityListGenerator.GenerateCitySetFromFileName("top80.txt");
            distantCouple = solver.GetMostDistantCities(cities);

            firstExpected = cities.ElementAt(23); //23
            firstActual = distantCouple.Cities.ElementAt(0);

            secondExpected = cities.ElementAt(68); //68
            secondActual = distantCouple.Cities.ElementAt(1);

            Assert.Equal(firstExpected, firstActual);
            Assert.Equal(secondExpected, secondActual);

        }

    }
}
