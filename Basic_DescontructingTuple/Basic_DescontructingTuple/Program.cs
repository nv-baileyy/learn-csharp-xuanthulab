using System;

namespace Basic_DescontructingTuple
{
    internal class Program
    {
        private static (string, int, double) QueryCityData(string name)
        {
            if (name == "New York City")
                return (name, 8175133, 468.48);

            return ("", 0, 0);
        }

        private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "New York City")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }

        private static void Main(string[] args)
        {
            var result = QueryCityData("New York City");

            var city = result.Item1;
            var pop = result.Item2;
            var size = result.Item3;
            Console.WriteLine($"city: {city}, pop: {pop}, size: {size}");

            (string a, int b, double c) = QueryCityData("New York City");
            Console.WriteLine($"a = {a}, b={b}, c={c}");

            string City = "Raleigh";
            int population = 458880;
            double area = 144.8;

            (City, population, area) = QueryCityData("New York City");
            Console.WriteLine($"city: {City}, pop: {population}, size: {area}");
            // Do something with the data.

            var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

            Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
        }
    }
}