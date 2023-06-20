using drone_delivery_service_api.Domain;

namespace drone_delivery_service_api.Business.Interface
{
    public interface IRoutesBusiness
    {
        List<OptimizedRoutes> Routes();
    }
}
