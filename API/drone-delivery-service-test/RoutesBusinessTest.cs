using drone_delivery_service_api.Business;
using drone_delivery_service_api.Business.Interface;
using drone_delivery_service_api.Context.Interface;
using drone_delivery_service_api.Domain;
using Moq;
using Xunit;

namespace drone_delivery_service_api.Tests
{
    public class RoutesBusinessTest
    {
        [Fact]
        public void Routes_ShouldReturnOptimizedRoutes()
        {
            var droneContextMock = new Mock<IDroneContext>();
            var deliveryContextMock = new Mock<IDeliveryContext>();

            var deliveries = new List<Delivery>
            {
                new Delivery { ID = 1, Location = "Location1", Weight = 10 },
                new Delivery { ID = 2, Location = "Location2", Weight = 20 },
                new Delivery { ID = 3, Location = "Location3", Weight = 15 }
            };
            var drones = new List<Drone>
            {
                new Drone { ID = 1, Name = "Drone1", MaxWeight = 30 },
                new Drone { ID = 2, Name = "Drone2", MaxWeight = 25 }
            };

            droneContextMock.Setup(c => c.Drones()).Returns(drones);
            deliveryContextMock.Setup(c => c.Deliveries()).Returns(deliveries);

            var routesBusiness = new RoutesBusiness(droneContextMock.Object, deliveryContextMock.Object);

            var result = routesBusiness.Routes();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);

            Assert.Equal("Drone1", result[0].DroneName);
            Assert.Single(result[0].TripsList);

            Assert.Equal("Drone2", result[1].DroneName);
            Assert.Single(result[1].TripsList);
        }
    }
}
