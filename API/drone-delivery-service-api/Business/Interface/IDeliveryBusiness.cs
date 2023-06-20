using drone_delivery_service_api.Domain;

namespace drone_delivery_service_api.Business.Interface
{
    public interface IDeliveryBusiness
    {
        List<Delivery> deliveries();
        void Includedeliveries(List<Delivery> deliveries);
        void Updatedeliveries(List<Delivery> deliveries);
        void DeleteDelivery(Delivery deliveries);
    }
}
