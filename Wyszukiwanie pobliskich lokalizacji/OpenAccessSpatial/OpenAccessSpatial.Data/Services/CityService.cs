using System.Collections.Generic;
using System.Linq;
using OpenAccessSpatial.Core.Data;
using OpenAccessSpatial.Models;

namespace OpenAccessSpatial.Core.Services
{
    /// <summary>
    /// City services.
    /// </summary>
    public class CityService
    {
        /// <summary>
        /// Gets the cities with specified distance from source city.
        /// </summary>
        /// <param name="sourcePostalCode">The postal code of source city.</param>
        /// <param name="distance">The distance in kilometers.</param>
        public IEnumerable<CityDto> GetCities(string sourcePostalCode, int distance)
        {
            using (EntitiesModel ctx = new EntitiesModel())
            {
                City sourceCity = ctx.Cities.Where(city => city.PostalCode == sourcePostalCode).SingleOrDefault();
                if (sourceCity == null)
                {
                    return null;
                }

                int distanceInMeters = distance * 1000;
                return ctx.Cities.Where(city => city.Id != sourceCity.Id
                    && city.Coordinates.STDistance(sourceCity.Coordinates).Value < distanceInMeters)
                    .Select(city => new CityDto(city))
                    .ToList();
            }
        }
    }
}
