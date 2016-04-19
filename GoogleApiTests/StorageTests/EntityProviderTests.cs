using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleApi;
using MainApplication;
using Storage;
using Storage.ReadModels;
using Xunit;

namespace Tests.StorageTests {
    public class EntityProviderTests {
        [Fact]
        public void Add() {
           var dataProvider = new DataProvider();
           var storageService =  new StorageService(dataProvider);
            storageService.AddLocation(new Location {Latitude = -33.870775 ,Longitude = 151.199025 });

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
