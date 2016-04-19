using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.ReadModels;
using MainApplication;
using Storage.ReadModels;

namespace Storage {
    public class StorageService: IStorageProvider {
        private readonly IDataProvider dataProvider;

        public StorageService(IDataProvider dataProvider) {
            this.dataProvider = dataProvider;
        }

        public bool AddLocation(Location location) {
            {
                using (var context = new LocationBarsDbContext()) {
                    if (IsLocationAdded(context.LocationBarsEntities, location)) return false;
                    var data = GetRemoteData(location);
                    SaveData(context, data, location);
                }
                return true;
            }
        }
        public  bool Delete(Location location) {
            using (var context = new LocationBarsDbContext()) {
                var locationBars = FindLocation(context.LocationBarsEntities, location);
                if (locationBars == null) return true;
                context.LocationBarsEntities.Remove(locationBars);
                return context.SaveChanges() > 0;
            }
        }

        public IEnumerable<Location> GetAllLocations() {
            IList<Location> result = new List<Location>();
            using (var context = new LocationBarsDbContext()) {
                foreach (var locationBarsEntity in context.LocationBarsEntities.ToList()) {
                    result.Add(new Location {Latitude = locationBarsEntity.Location.Latitude, Longitude = locationBarsEntity.Location.Longitude});
                }
            }
            return result;
        }

        public IEnumerable<Bar> GetBars(Location location) {
            IList<Bar> bars = new List<Bar>();
            using (var context = new LocationBarsDbContext()) {
               var locationBars = FindLocation(context.LocationBarsEntities, location);
                foreach (var bar in locationBars.BarEntities) {
                    bars.Add(new Bar {Name = bar.Name});
                }
            }
            return bars;
        }

        private static bool IsLocationAdded(IQueryable<LocationBarsEntity> collection, Location location) {
            var locationBars = FindLocation(collection, location);
            return locationBars != null;
        }

        private static LocationBarsEntity FindLocation(IQueryable<LocationBarsEntity> collection, Location location) {
            const double range = 0.01;
            return collection.FirstOrDefault(x => Math.Abs(x.Location.Longitude - location.Longitude) < range && Math.Abs(x.Location.Latitude - location.Latitude) < range);
        }

        private IEnumerable<Bar> GetRemoteData(Location location) {
            return dataProvider.GetBars(location);
        }

        private static void SaveData(LocationBarsDbContext context, IEnumerable<Bar> data, Location location) {
            context.LocationBarsEntities.Add(location.Map(data));
            context.SaveChanges();
        }


    }
}