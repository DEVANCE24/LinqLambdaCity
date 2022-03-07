using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLambaCity
{
    class Program
    {
        public static List<string> cities;


        static void Main(string[] args)
        {


            List<string> cities = new List<string>()
            {
                "Mumbai",
                "Delhi",
                "Ahmedabad",
                "Surat",
                "Valsad",
                "Varnasi",
                "Chennai",
                "Bhopal",
                "Darjeeling"
            };

            
            var citiesDescendingLinq = (from city in cities
                                        orderby city descending
                                        select city).ToList();

            var citiesDecendingLambda = cities.OrderByDescending(city => city).ToList();


            var citiesAscendingLinq = (from city in cities
                                       orderby city
                                       select city).ToList();

            var citiesAscendingLambda = cities.OrderBy(city => city).ToList();

            var citiesDescendingLenghtLinq = (from city in cities
                                              orderby city.Length descending
                                              select city).ToList();

            var citiesDescendingLenghtLambda = cities.OrderByDescending(city => city.Length).ToList();


            var citiesAscendingLenghtLinq = (from city in cities
                                             orderby city.Length
                                             select city).ToList();

            var citiesAscendingLenghtLambda = cities.OrderBy(city => city.Length).ToList();


            var citiesVandDLinq = (from city in cities
                                   where city.StartsWith("V") || city.StartsWith("D")
                                   select city).ToList();

            var citiesVandDLambda = cities.Where(city => city.StartsWith("V") || city.StartsWith("D")).ToList();

            var citiesCountALinq = (from city in cities
                                    where city.StartsWith("A")
                                    select city).Count();

            var citiesCountALambda = cities.Count(city => city.StartsWith("A"));

            var citiesOrderedFirstLetterLinq = from city in cities
                                               group city by city[0] into cityGroup
                                               orderby cityGroup.Key
                                               select cityGroup;

            var citiesOrderedFirstLetterLambda = cities.GroupBy(city => city[0]).OrderBy(city => city.Key);

            GetDetails(citiesAscendingLinq);
            Console.WriteLine();
            GetDetails(citiesDescendingLinq);
            Console.WriteLine();
            GetDetails(citiesAscendingLenghtLinq); 
            Console.WriteLine();
            GetDetails(citiesDescendingLenghtLinq);
            Console.WriteLine();
            GetDetails(citiesVandDLinq);
            Console.WriteLine();
            Console.WriteLine("City Name that start with A is: " + citiesCountALinq);
            Console.WriteLine("City Name that start with A is: " + citiesCountALambda);

            foreach (var cityGroup in citiesOrderedFirstLetterLambda)
            {
                Console.WriteLine(cityGroup.Key);

                foreach (var city in cityGroup)
                {
                    Console.WriteLine(city);
                }
            }
            Console.ReadKey();
        }

        public static void GetDetails(List<string> cities)
        {
            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }
    }
}
