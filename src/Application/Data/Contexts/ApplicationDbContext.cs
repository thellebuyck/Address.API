using AddressEntity =  Address.API.Application.Data.Entities.Address;
using Microsoft.EntityFrameworkCore;

namespace Address.API.Application.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AddressEntity> Addresses {  get; set; }    

    }
}
