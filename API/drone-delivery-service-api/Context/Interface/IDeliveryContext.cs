using drone_delivery_service_api.Business;
using drone_delivery_service_api.Domain;

namespace drone_delivery_service_api.Context.Interface
{
    public interface IDeliveryContext
    {
        List<Delivery> Deliveries();
        void Includedeliveries(List<Delivery> deliveries);
        void Updatedeliveries(List<Delivery> deliveries);
        void DeleteDelivery(Delivery deliveries);
    }
}
