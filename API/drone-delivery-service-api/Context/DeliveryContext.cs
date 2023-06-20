using drone_delivery_service_api.Business;
using drone_delivery_service_api.Context.Interface;
using drone_delivery_service_api.Domain;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace drone_delivery_service_api.Context
{
    public class DeliveryContext : IDeliveryContext
    {
        public void DeleteDelivery(Delivery deliveries)
        {
            using (var ctx = new AppDbContext())
            {
                var deliverRow = ctx.Delivery.Where(x => x.ID == deliveries.ID).FirstOrDefault();
                if (deliverRow != null)
                {
                    ctx.Delivery.Remove(deliverRow);
                    ctx.SaveChanges();
                }
            }
        }

        List<Delivery> IDeliveryContext.Deliveries()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Delivery.ToList();
            }
        }

        public void Includedeliveries(List<Delivery> deliveries)
        {
            using (var ctx = new AppDbContext())
            {
                ctx.Delivery.AddRange(deliveries);
                ctx.SaveChanges();
            }
        }

        public void Updatedeliveries(List<Delivery> deliveries)
        {
            using (var ctx = new AppDbContext())
            {
                foreach (var delivery in deliveries)
                    ctx.Entry<Delivery>(delivery).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }


    }
}
