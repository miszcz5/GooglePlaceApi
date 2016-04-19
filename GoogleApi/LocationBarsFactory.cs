using System.Collections.Generic;
using GoogleApi.ReadModels;
using MainApplication;

namespace GoogleApi {
    public static class LocationBarsFactory {
        public static Bar Map(this results item) {
            return new Bar {Name = item.name};
        }
    }
}
