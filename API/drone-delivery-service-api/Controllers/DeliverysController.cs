using drone_delivery_service_api.Business;
using drone_delivery_service_api.Business.Interface;
using drone_delivery_service_api.Context.Interface;
using drone_delivery_service_api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace drone_delivery_service_api.Controllers
{
    [ApiController]
    [Route("deliveries")]
    public class deliveriesController : ControllerBase
    {
        private readonly IDeliveryBusiness _deliveryBusiness;

        public deliveriesController(IDeliveryBusiness deliveryBusiness)
        {
            _deliveryBusiness = deliveryBusiness;
        }

        [HttpGet]
        public IActionResult deliveries()
        {
            var Return = _deliveryBusiness.deliveries();
            if (Return.Count() == 0)
                return NoContent();
            return Ok(Return);
        }

        [HttpPost]
        public void Includedeliveries(List<Delivery> deliveries)
        {
            _deliveryBusiness.Includedeliveries(deliveries);
        }

        [HttpPut]
        public void Updatedeliveries(List<Delivery> deliveries)
        {
            _deliveryBusiness.Updatedeliveries(deliveries);
        }

        [HttpDelete]
        public void DeleteDelivery(Delivery deliveries)
        {
            _deliveryBusiness.DeleteDelivery(deliveries);
        }
    }
}
