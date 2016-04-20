using GoogleApi;
using MainApplication;
using Storage;
using Xunit;

namespace Tests.StorageTests {
    public class EntityProviderTests {
        [Fact]
        public void Add() {
            var dataProvider = new DataProvider();
            var storageService = new StorageService(dataProvider);
            storageService.AddLocation(new Location {Latitude = -33.870775, Longitude = 151.199025});
        }

        [Fact]
        public void Remove() {
            var dataProvider = new DataProvider();
            var storageService = new StorageService(dataProvider);
            storageService.Delete(new DefaultLocation());
        }

        [Fact]
        public void GetAll() {
            var dataProvider = new DataProvider();
            var storageService = new StorageService(dataProvider);
            var collection = storageService.GetAllLocations();
        }
    }
}