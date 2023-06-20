using drone_delivery_service_api.Business;
using drone_delivery_service_api.Context.Interface;
using drone_delivery_service_api.Domain;
using Microsoft.EntityFrameworkCore;

namespace drone_delivery_service_api.Context
{
    public class DroneContext : IDroneContext
    {
        public void DeleteDrone(Drone drone)
        {
            using (var ctx = new AppDbContext())
            {
                var droneRow = ctx.Drone.Where(x => x.ID == drone.ID).FirstOrDefault();
                if (droneRow != null)
                {
                    ctx.Drone.Remove(droneRow);
                    ctx.SaveChanges();
                }
            }
        }

        public List<Drone> Drones()
        {
            using (var ctx = new AppDbContext())
            {
                return ctx.Drone.ToList();
            }
        }

        public void IncludeDrones(List<Drone> drones)
        {
            using (var ctx = new AppDbContext())
            {
                ctx.Drone.AddRange(drones);
                ctx.SaveChanges();
            }
        }

        public void UpdateDrones(List<Drone> drones)
        {
            using (var ctx = new AppDbContext())
            {
                foreach (var drone in drones)
                    ctx.Entry<Drone>(drone).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
