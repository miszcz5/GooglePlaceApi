using System;
using System.Linq;

namespace MainApplication.Repository {
    public class Repository : IRepository {
        private readonly IStorageProvider storageProvider;

        public Repository(IStorageProvider storageProvider) {
            this.storageProvider = storageProvider;
        }

        public LocationModel GetLocations() {
            var locations = storageProvider.GetAllLocations().ToList();
            return new LocationModel { draw = 1, recordsTotal = 1, data = locations, recordsFiltered = locations.Count() };
        }

        public bool AddLocation(Location location) {
            return storageProvider.AddLocation(location);
        }

        public BarModel GetBars(Location location, string search, int draw) {
            var bars = storageProvider.GetBars(location).Where(x=>x.Name.Contains(search)).ToList();
            return new BarModel { draw = draw, recordsTotal = 1, data = bars, recordsFiltered = bars.Count() };

        }
    }
}
