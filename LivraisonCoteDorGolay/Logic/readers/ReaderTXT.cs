using LivraisonCoteDor.network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivraisonCoteDor.readers
{
    public class ReaderTXT : Reader, IReader
    {
        public ReaderTXT(string filepath) : base(filepath)
        {

        }

        public override List<City> getExtractedCities()
        {
            List<City> cities = new List<City>();
            try
            {
                // Set a variable to the My Documents path.
                string docPath =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                var files = from file in Directory.EnumerateFiles(docPath, "*.txt", SearchOption.AllDirectories)
                            from line in File.ReadLines(file)
                            where line.Contains("Microsoft")
                            select new
                            {
                                File = file,
                                Line = line
                            };

                foreach (var f in files)
                {
                    Console.WriteLine($"{f.File}\t{f.Line}");
                }
                Console.WriteLine($"{files.Count().ToString()} files found.");
            }
            catch (UnauthorizedAccessException uAEx)
            {
                Console.WriteLine(uAEx.Message);
            }
            catch (PathTooLongException pathEx)
            {
                Console.WriteLine(pathEx.Message);
            }

            return cities;
        }

        public void Read()
        {

        }
    }
}
