using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication {
    public interface IStorageProvider {
        bool AddLocation(Location location);
        bool Delete(Location location);
        IEnumerable<Location> GetAllLocations();
        IEnumerable<Bar> GetBars(Location location);
    }
}
