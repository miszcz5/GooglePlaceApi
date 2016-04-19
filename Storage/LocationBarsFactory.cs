using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainApplication;
using Storage.ReadModels;

namespace Storage {
    public static class LocationBarsFactory {
        public static LocationBarsEntity Map(this Location location, IEnumerable<Bar> bars) {
            var locationBarsEntity = new LocationBarsEntity {
                Location = new LocationEntity {
                    Longitude = location.Longitude,
                    Latitude = location.Latitude
                },
                BarEntities = new List<BarEntity>()
            };
            foreach (var bar in bars) {
                locationBarsEntity.BarEntities.Add(new BarEntity { Name = bar.Name });
            }
            return locationBarsEntity;
        }
    }
}
