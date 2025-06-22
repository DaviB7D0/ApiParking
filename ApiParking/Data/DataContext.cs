using Microsoft.EntityFrameworkCore;
using ApiParking.Models;

namespace ApiParking.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options) 
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<UserModel> Users => Set<UserModel>();
        public DbSet<VehicleModel> Vehicles => Set<VehicleModel>(); 
        public DbSet<BranchModel> Branches => Set<BranchModel>();
    }
}
