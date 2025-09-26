
using Addresses.API.Application.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Addresses.API.Application.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses {  get; set; }    
        public DbSet<StateCode> StateCodes { get; set; }

    }
}
