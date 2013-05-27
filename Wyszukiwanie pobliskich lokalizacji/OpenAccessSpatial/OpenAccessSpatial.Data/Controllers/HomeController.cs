using System.Web.Mvc;
using OpenAccessSpatial.Core.Services;

namespace OpenAccessSpatial.Core.Controllers
{
    /// <summary>
    /// Home controller.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly CityService cityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController" /> class.
        /// </summary>
        public HomeController()
        {
            this.cityService = new CityService();
        }

        /// <summary>
        /// Displays page with map.
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Searches the cities in specified distance to source city with specified postal code.
        /// </summary>
        /// <param name="sourcePostalCode">The source city postal code.</param>
        /// <param name="distance">The distance in kilometers.</param>
        /// <returns>Found cities.</returns>
        public JsonResult Search(string sourcePostalCode, int distance)
        {
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = cityService.GetCities(sourcePostalCode, distance)
            };
        }
    }
}
