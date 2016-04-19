using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using MainApplication;
using Storage;

namespace WebApplication.Controllers
{
    public class PlacesController : ApiController
    {
        private IRepository repository;

        public PlacesController(IRepository repository) {
            this.repository = repository;
        }
        [Route("api/places/AllLocations")]
        public LocationModel AllLocations() {
            var locations = repository.GetLocations();
            return locations;
        }

        [Route("api/places/AllLocations")]
        public LocationModel GetAllLocations() {
            var locations = repository.GetLocations();
            return locations;
        }

        [Route("api/places/AddLocation")]
        public HttpResponseMessage PostAddLocation(Location location) {
            if (location == null) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Location is not valid");
            }
            repository.AddLocation(location);
            return Request.CreateErrorResponse(HttpStatusCode.OK, "Location added");
           
        }


        [Route("api/places/GetBars")]
        public BarModel GetBars(double latitude, double longitude) {
            return repository.GetBars(new Location {Latitude = latitude, Longitude = longitude });
        }
    }
}
