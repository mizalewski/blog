using System.Collections.Generic;
using System.Linq;
using Microsoft.SqlServer.Types;
using System;

namespace OpenAccessSpatial1
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddCityToDatabase();
            FindCities();
        }

        /// <summary>
        /// Przykład dodawania miejscowości do bazy.
        /// </summary>
        private static void AddCityToDatabase()
        {
            using (EntitiesModel ctx = new EntitiesModel())
            {
                City city = new City();
                city.Name = "Warszawa";
                city.PostalCode = "00-001";
                city.Coordinates = BuildPoint(52.229837, 21.011771);
                ctx.Add(city);
                ctx.SaveChanges();
            }
        }

        private static void FindCities()
        {
        	using (EntitiesModel ctx = new EntitiesModel())
            {
                SqlGeography line = BuildLine(52.194390, 16.194309, 56.194396, 16.194309);
                IList<City> cities = ctx.Cities.Where(city => city.Coordinates.STIntersects(line).Equals(1)).ToList();
                foreach (City city in cities)
                {
                    Console.WriteLine("Miejscowość = {0}, Kod pocztowy = {1}, szerokość geograficzna = {2}, długość geograficzna = {3}",
                        city.Name, city.PostalCode, city.Coordinates.Lat, city.Coordinates.Long);
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// Przykład stworzenia obiektu zawierającego punkt.
        /// </summary>
        /// <param name="latitude">Szerokość geograficzna punktu.</param>
        /// <param name="longitude">Długość geograficzna punktu.</param>
        /// <returns></returns>
        private static SqlGeography BuildPoint(double latitude, double longitude)
        {
            SqlGeographyBuilder builder = new SqlGeographyBuilder();
            builder.SetSrid(4326);
            builder.BeginGeography(OpenGisGeographyType.Point);
            builder.BeginFigure(latitude, longitude);
            builder.EndFigure();
            builder.EndGeography();

            return builder.ConstructedGeography;
        }

        /// <summary>
        /// Przykład stworzenia obiektu zawierającego linię.
        /// </summary>
        /// <param name="latitude1">Szerokość geograficzna pierwszego punktu.</param>
        /// <param name="longitude1">Długość geograficzna pierwszego punktu.</param>
        /// <param name="latitude2">Szerokość geograficzna drugiego punktu.</param>
        /// <param name="longitude2">Długość geograficzna drugiego punktu.</param>
        /// <returns></returns>
        private static SqlGeography BuildLine(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            SqlGeographyBuilder builder = new SqlGeographyBuilder();
            builder.SetSrid(4326);
            builder.BeginGeography(OpenGisGeographyType.LineString);
            builder.BeginFigure(latitude1, longitude1);
            builder.AddLine(latitude2, longitude2);
            builder.EndFigure();
            builder.EndGeography();

            return builder.ConstructedGeography;
        }
    }
}
