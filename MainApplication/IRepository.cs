using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApplication {
    public interface IRepository {
        LocationModel GetLocations();
        bool AddLocation(Location location);
        BarModel GetBars(Location location);
    }
}
