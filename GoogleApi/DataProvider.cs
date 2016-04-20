using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using GoogleApi.ReadModels;
using MainApplication;
using Newtonsoft.Json;
using static System.String;

namespace GoogleApi {
    public class DataProvider : IDataProvider {
        private const string Type = "restaurant";
        private const int Radius = 2000;
        private readonly string key;
        private readonly string url;
        private readonly WebClient webClient;


        public DataProvider() {
            key=ConfigurationManager.AppSettings["googleKey"];
            url = ConfigurationManager.AppSettings["googleUrl"];
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
            return Format(CultureInfo.InvariantCulture, url + "location={0},{1}&type={2}&radius={3}&key={4}", location.Latitude, location.Longitude, Type, Radius, key);
        }
    }
}