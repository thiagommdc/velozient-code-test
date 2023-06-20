using drone_delivery_service_api.Business.Interface;
using drone_delivery_service_api.Context.Interface;
using drone_delivery_service_api.Domain;
using System;
using System.Collections.Generic;

namespace drone_delivery_service_api.Business
{
    public class RoutesBusiness : IRoutesBusiness
    {
        private readonly IDroneContext _droneContext;
        private readonly IDeliveryContext _deliveryContext;

        public RoutesBusiness(IDroneContext droneContext, IDeliveryContext deliveryContext)
        {
            _droneContext = droneContext;
            _deliveryContext = deliveryContext;
        }

        public List<OptimizedRoutes> Routes()
        {
            List<OptimizedRoutes> optimizedRoutes = new();
            var deliveries = _deliveryContext.Deliveries();
            var drones = _droneContext.Drones().Select(t => new DroneLocations()
            {
                Name = t.Name,
                ID = t.ID,
                MaxWeight = t.MaxWeight,
                Trips = new List<List<string>>()
            }).ToList();

            CalculateOptimizedRoutes(drones, deliveries);

            foreach (var drone in drones)
                optimizedRoutes.Add(new OptimizedRoutes()
                {
                    DroneName = drone.Name,
                    TripsList = drone.Trips
                });

            return optimizedRoutes;
        }

        public static List<DroneLocations> CalculateOptimizedRoutes(List<DroneLocations> drones, List<Delivery> deliveries)
        {
            var deliveryCombinationsTemp = GenerateCombinations(deliveries);
            var deliveryCombinations = deliveryCombinationsTemp.Select(t => new DeliveryList()
            {
                Deliveries = t.ToList(),
                Weight = t.Sum(t => t.Weight)
            });

            int maxWeight = drones.OrderByDescending(t => t.MaxWeight).FirstOrDefault().MaxWeight;
            deliveryCombinations = deliveryCombinations.Where(t => t.Weight <= maxWeight).OrderByDescending(t => t.Weight).ToList();

            DroneTrips(drones, deliveryCombinations.ToList());

            return drones;
        }

        public static void DroneTrips(List<DroneLocations> drones, List<DeliveryList> Combination)
        {
            var deliveryCombinations = Combination.Select(t => t);
            drones.ForEach(t => t.Trips = new());
            do
            {
                foreach (var drone in drones.OrderByDescending(t => t.MaxWeight))
                {
                    var heaviestDelivery = deliveryCombinations.FirstOrDefault(t => t.Weight <= drone.MaxWeight);

                    if (heaviestDelivery == null) continue;

                    drone.Trips.Add(heaviestDelivery.Deliveries.Select(t => t.Location).ToList());

                    var heaviestDeliveryIds = heaviestDelivery.Deliveries.Select(t => t.ID).ToList();

                    deliveryCombinations = deliveryCombinations.Where(t =>
                        t.Deliveries.Any(k => heaviestDeliveryIds.Contains(k.ID)) == false).ToList();
                }
            } while (deliveryCombinations.Count() > 0);
        }
        private static List<List<T>> GenerateCombinations<T>(List<T> obj) where T : new()
        {
            int totalCombinations = (int)Math.Pow(2, obj.Count) - 1;
            List<List<T>> combinations = new();

            for (int i = 1; i <= totalCombinations; i++)
            {
                List<T> combination = new List<T>();

                for (int j = 0; j < obj.Count; j++)
                {
                    int bit = (i & (1 << j));
                    if (bit != 0)
                    {
                        T obj2 = obj[j];
                        combination.Add(obj2);
                    }
                }
                combinations.Add(combination);
            }
            return combinations;
        }


    }
}
