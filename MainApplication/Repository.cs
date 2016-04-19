using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication {
    public class Repository : IRepository {
        private readonly IStorageProvider storageProvider;

        public Repository(IStorageProvider storageProvider) {
            this.storageProvider = storageProvider;
        }

        public LocationModel GetLocations() {
            var locations = storageProvider.GetAllLocations().ToList();
            return new LocationModel { draw = 1, recordsTotal = 1, data = locations, recordsFiltered = locations.Count()};
        }

        public bool AddLocation(Location location) {
            return storageProvider.AddLocation(location);
        }

        public BarModel GetBars(Location location) {
            var bars= storageProvider.GetBars(location).ToList();
            return new BarModel { draw = 1, recordsTotal = 1, data = bars, recordsFiltered = bars.Count() };

        }
    }

    [DataContract]
    public class LocationModel {
        [DataMember]
        public int draw { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public IEnumerable<Location> data { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }

    [DataContract]
    public class BarModel {
        [DataMember]
        public int draw { get; set; }
        [DataMember]
        public int recordsTotal { get; set; }
        [DataMember]
        public IEnumerable<Bar> data { get; set; }
        [DataMember]
        public int recordsFiltered { get; set; }
    }
}
