using drone_delivery_service_api.Business.Interface;
using drone_delivery_service_api.Context.Interface;
using drone_delivery_service_api.Domain;

namespace drone_delivery_service_api.Business
{
    public class DroneBusiness : IDroneBusiness
    {
        private readonly IDroneContext _droneContext;

        public DroneBusiness(IDroneContext droneContext)
        {
            _droneContext = droneContext;
        }

        public void DeleteDrone(Drone drone)
        {
            _droneContext.DeleteDrone(drone);
        }

        public List<Drone> Drones()
        {
            return _droneContext.Drones();
        }

        public void IncludeDrones(List<Drone> drones)
        {
            _droneContext.IncludeDrones(drones);
        }

        public void UpdateDrones(List<Drone> drones)
        {
            _droneContext.UpdateDrones(drones);
        }

       
    }
}
