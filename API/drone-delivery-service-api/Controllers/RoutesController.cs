using drone_delivery_service_api.Business.Interface;
using drone_delivery_service_api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace drone_delivery_service_api.Controllers
{
    [ApiController]
    [Route("Routes")]
    public class RoutesController : ControllerBase
    {
        private readonly IRoutesBusiness _routesBusiness;

        public RoutesController(IRoutesBusiness routesBusiness)
        {
            _routesBusiness = routesBusiness;
        }
        
        [HttpGet]
        public IActionResult Routes()
        {
            var routes = _routesBusiness.Routes();
            if (routes.Count() == 0)
                return NoContent();
            return Ok(routes);
        }

    }
}
