using drone_delivery_service_api.Business.Interface;
using drone_delivery_service_api.Context.Interface;
using drone_delivery_service_api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace drone_delivery_service_api.Controllers
{
    [ApiController]
    [Route("Drones")]
    public class DronesController : ControllerBase
    {
        private readonly IDroneBusiness _droneBusiness;

        public DronesController(IDroneBusiness droneBusiness)
        {
            _droneBusiness = droneBusiness;
        }

        [HttpGet]
        public IActionResult Drone()
        {
            var Return = _droneBusiness.Drones();
            if (Return.Count() == 0)
                return NoContent();
            return Ok(Return);
        }

        [HttpPost]
        public void IncludeDrones(List<Drone> drones)
        {
            _droneBusiness.IncludeDrones(drones);
        }

        [HttpPut]
        public void UpdateDrones(List<Drone> drones)
        {
            _droneBusiness.UpdateDrones(drones);
        }

        [HttpDelete]
        public void DeleteDrone(Drone drones)
        {
            _droneBusiness.DeleteDrone(drones);
        }
    }
}
