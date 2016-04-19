using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GoogleApi.ReadModels;
using MainApplication;
using Newtonsoft.Json;
using static System.String;

namespace GoogleApi {
    public class DataProvider : IDataProvider {
        private const string Type = "restaurant";
        private const int Radius = 2000;
        private const string Key = "AIzaSyAHnDojAaLlZ8C9ArUCaZ2ge4mINlcfnlw";
        private readonly string url = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";
        private readonly WebClient webClient;


        public DataProvider() {
            webClient = new WebClient();
        }

        public IEnumerable<Bar> GetBars(Location location) {
            var response = GetPlaces(location);
            return response.Select(x => x.Map());
        }

        private IEnumerable<results> GetPlaces(Location location) {
            var response = JsonConvert.DeserializeObject<GooglePlacesResponse>(
                webClient.DownloadString(GetUrl(location))
                );
            if (response.status != "OK")
                throw new ApplicationException("Connection to google web api failed");
            return response.results;
        }

        private string GetUrl(Location location) {
            return Format(System.Globalization.CultureInfo.InvariantCulture, url + "location={0},{1}&type={2}&radius={3}&key={4}", location.Latitude, location.Longitude, Type, Radius, Key);
        }
    }
}