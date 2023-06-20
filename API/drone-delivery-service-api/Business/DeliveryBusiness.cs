using drone_delivery_service_api.Business.Interface;
using drone_delivery_service_api.Context.Interface;
using drone_delivery_service_api.Domain;

namespace drone_delivery_service_api.Business
{
    public class DeliveryBusiness : IDeliveryBusiness
    {
        private readonly IDeliveryContext _deliveryContext;

        public DeliveryBusiness(IDeliveryContext deliveryContext)
        {
            _deliveryContext = deliveryContext;
        }
      
        public void DeleteDelivery(Delivery deliveries)
        {
            _deliveryContext.DeleteDelivery(deliveries);
        }

        public List<Delivery> deliveries()
        {
            return _deliveryContext.Deliveries();
        }

        public void Includedeliveries(List<Delivery> deliveries)
        {
            _deliveryContext.Includedeliveries(deliveries);
        }

        public void Updatedeliveries(List<Delivery> deliveries)
        {
            _deliveryContext.Updatedeliveries(deliveries);
        }

       
    }
}
