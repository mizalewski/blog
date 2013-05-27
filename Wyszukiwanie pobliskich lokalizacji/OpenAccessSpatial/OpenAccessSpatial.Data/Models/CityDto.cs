using OpenAccessSpatial.Core.Data;

namespace OpenAccessSpatial.Models
{
    /// <summary>
    /// City DTO.
    /// </summary>
    public class CityDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityDto" /> class.
        /// </summary>
        /// <param name="city">The city.</param>
        public CityDto(City city)
        {
            this.Name = city.Name;
            this.Latitude = city.Coordinates.Lat.Value;
            this.Longitude = city.Coordinates.Long.Value;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        /// <value>The latitude.</value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        /// <value>The longitude.</value>
        public double Longitude { get; set; }
    }
}