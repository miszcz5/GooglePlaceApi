

using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MainApplication;
using MainApplication.Repository;
using Moq;
using Storage;
using WebApplication.Controllers;
using Xunit;

namespace Tests.WebApplicationTests {

    public class PlacesControllerTests : IDisposable {
        public Mock<IRepository> Mock;
        public PlacesController Controller;
        public PlacesControllerTests() {
            Mock = new Mock<IRepository>();
            Controller = new PlacesController(Mock.Object) {Request = new HttpRequestMessage()};
            Controller.Request.SetConfiguration(new HttpConfiguration());
        }
        [Fact]
        public void AddEmptyLocation() {
            using (var result = Controller.PostAddLocation(null)) {
                Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            }
        }

        [Fact]
        public void AddProperLocation() {
            var location = new DefaultLocation();
            Mock.Setup(x => x.AddLocation(location)).Returns(true);
            var controller = new PlacesController(Mock.Object) { Request = new HttpRequestMessage() };
            controller.Request.SetConfiguration(new HttpConfiguration());
            var result = controller.PostAddLocation(location);

            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Fact]
        public void AddDuplicatedLocation() {
            var location = new DefaultLocation();
            Mock.Setup(x => x.AddLocation(location)).Returns(false);
            var controller = new PlacesController(Mock.Object) { Request = new HttpRequestMessage() };
            controller.Request.SetConfiguration(new HttpConfiguration());

            var result = controller.PostAddLocation(location);

            Assert.Equal(HttpStatusCode.Conflict, result.StatusCode);
        }

        public void Dispose() {
            Controller.Dispose();
        }
    }
}