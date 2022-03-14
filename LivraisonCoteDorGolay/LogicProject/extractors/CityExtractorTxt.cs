using LivraisonCoteDor.network;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Logic.generators
{
    public class CityExtractorTxt
    {
        public CityExtractorTxt()
        {

        }

        public List<City> ExtractCitiesFromLines(List<string> lines)
        {
            List<City> cities = new List<City>();

            if (lines != null)
            {
                if (lines.Count > 0)
                {
                    foreach (string line in lines)
                    {
                        if (GenerateCityFromLine(line) != null)
                            cities.Add(GenerateCityFromLine(line));
                    }
                }
            }
            return cities;
        }

        private City GenerateCityFromLine(string lineToSplit)
        {
            City city = null;
            char separator = ' ';
            string[] splitedLine = lineToSplit.Split(separator);
            bool okToParse = (splitedLine.Length == 4);
            string s2 = splitedLine[2];
            string s3 = splitedLine[3];

            if (okToParse)
            {
                int id = Int32.Parse(splitedLine[0]);
                string name = splitedLine[1];

                // Carrying dot separator for correct parsing
                CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                ci.NumberFormat.CurrencyDecimalSeparator = ".";

                double longitude = double.Parse(splitedLine[2], NumberStyles.Any, ci);
                double latitude = double.Parse(splitedLine[3], NumberStyles.Any, ci);

                //Generate City Instance from extracted columns
                city = new City(id, name, longitude, latitude);
            }

            return city;
        }
    }
}
