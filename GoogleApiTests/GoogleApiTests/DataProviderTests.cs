using System;
using System.Linq;
using GoogleApi;
using MainApplication;
using Xunit;

namespace Tests.GoogleApiTests {
    public class DataProviderTests {
        [Fact]
        public void GetBarsAsyncWithProperLocation_Then_LocationBarsReturns() {
            var dataProvider = new DataProvider();
            var location = new Location {Latitude = 50.0612603, Longitude = 19.9369816};

            var bars = dataProvider.GetBars(location);
            Assert.Equal(true, bars.Any());
        }

        [Fact]
        public void GetBarsAsyncWithWrongLocation_Then_ApplicationException() {
            var dataProvider = new DataProvider();
            var location = new Location {Latitude = 22222222222250.0612603, Longitude = 222222222219.9369816};

            Assert.Throws<ApplicationException>(() => dataProvider.GetBars(location));
        }
    }
}