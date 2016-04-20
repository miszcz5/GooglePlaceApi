using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using MainApplication;
using MainApplication.Repository;
using Storage;

namespace WebApplication.Controllers {
    public class PlacesController : ApiController {
        private IRepository repository;

        public PlacesController(IRepository repository) {
            this.repository = repository;
        }

        [Route("api/places/AllLocations")]
        public LocationModel GetAllLocations() {
            var locations = repository.GetLocations();
            return locations;
        }

        [Route("api/places/AddLocation")]
        public HttpResponseMessage PostAddLocation(Location location) {
            if (location == null) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Location is not valid");
            }
            var result = repository.AddLocation(location);
            return result ? Request.CreateErrorResponse(HttpStatusCode.Created, "Location added") : Request.CreateErrorResponse(HttpStatusCode.Conflict, "Location was added");
        }


        [Route("api/places/GetBars")]
        public BarModel GetBars(double latitude, double longitude) {
            try {
                return repository.GetBars(new Location { Latitude = latitude, Longitude = longitude });
            }
            catch (ArgumentNullException) {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) {
                    Content = new StringContent($"No product with latitude = {latitude}, longitude = {longitude}"),
                    ReasonPhrase = "Location Not Found"
                };
                throw new HttpResponseException(resp);
            }
        }
    }
}
