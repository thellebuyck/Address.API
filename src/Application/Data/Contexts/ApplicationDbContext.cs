
using Addresses.API.Application.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Addresses.API.Application.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<StateCode> StateCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnStateCodesModelCreating(modelBuilder);
            OnAddressesModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void OnAddressesModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.Id).HasColumnOrder(1);
            modelBuilder.Entity<Address>()
                .Property(e =>e.StateCodeId).HasColumnOrder(2).IsRequired();    
            modelBuilder.Entity<Address>()
                .Property(e => e.StreetName).HasColumnOrder(3).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Address>()
                .Property(e => e.StreetNameExt).HasColumnOrder(4).HasMaxLength(100);
            modelBuilder.Entity<Address>()
                .Property(e => e.City).HasColumnOrder(5).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Address>()
                .Property(e => e.ZipCode).HasColumnOrder(6).HasMaxLength(20).IsRequired();
            
        }

        private void OnStateCodesModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateCode>()
                .Property(e => e.Id).HasColumnOrder(1);
            modelBuilder.Entity<StateCode>()
                .Property(e => e.Code).HasColumnOrder(2).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<StateCode>()
                .Property(e => e.Name).HasColumnOrder(3).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<StateCode>().HasData(
                 new StateCode { Id = 1, Code = "AL", Name = "Alabama" },
            new StateCode { Id = 2, Code = "AK", Name = "Alaska" },
            new StateCode { Id = 3, Code = "AZ", Name = "Arizona" },
            new StateCode { Id = 4, Code = "AR", Name = "Arkansas" },
            new StateCode { Id = 5, Code = "CA", Name = "California" },
            new StateCode { Id = 6, Code = "CO", Name = "Colorado" },
            new StateCode { Id = 7, Code = "CT", Name = "Connecticut" },
            new StateCode { Id = 8, Code = "DE", Name = "Delaware" },
            new StateCode { Id = 9, Code = "FL", Name = "Florida" },
            new StateCode { Id = 10, Code = "GA", Name = "Georgia" },
            new StateCode { Id = 11, Code = "HI", Name = "Hawaii" },
            new StateCode { Id = 12, Code = "ID", Name = "Idaho" },
            new StateCode { Id = 13, Code = "IL", Name = "Illinois" },
            new StateCode { Id = 14, Code = "IN", Name = "Indiana" },
            new StateCode { Id = 15, Code = "IA", Name = "Iowa" },
            new StateCode { Id = 16, Code = "KS", Name = "Kansas" },
            new StateCode { Id = 17, Code = "KY", Name = "Kentucky" },
            new StateCode { Id = 18, Code = "LA", Name = "Louisiana" },
            new StateCode { Id = 19, Code = "ME", Name = "Maine" },
            new StateCode { Id = 20, Code = "MD", Name = "Maryland" },
            new StateCode { Id = 21, Code = "MA", Name = "Massachusetts" },
            new StateCode { Id = 22, Code = "MI", Name = "Michigan" },
            new StateCode { Id = 23, Code = "MN", Name = "Minnesota" },
            new StateCode { Id = 24, Code = "MS", Name = "Mississippi" },
            new StateCode { Id = 25, Code = "MO", Name = "Missouri" },
            new StateCode { Id = 26, Code = "MT", Name = "Montana" },
            new StateCode { Id = 27, Code = "NE", Name = "Nebraska" },
            new StateCode { Id = 28, Code = "NV", Name = "Nevada" },
            new StateCode { Id = 29, Code = "NH", Name = "New Hampshire" },
            new StateCode { Id = 30, Code = "NJ", Name = "New Jersey" },
            new StateCode { Id = 31, Code = "NM", Name = "New Mexico" },
            new StateCode { Id = 32, Code = "NY", Name = "New York" },
            new StateCode { Id = 33, Code = "NC", Name = "North Carolina" },
            new StateCode { Id = 34, Code = "ND", Name = "North Dakota" },
            new StateCode { Id = 35, Code = "OH", Name = "Ohio" },
            new StateCode { Id = 36, Code = "OK", Name = "Oklahoma" },
            new StateCode { Id = 37, Code = "OR", Name = "Oregon" },
            new StateCode { Id = 38, Code = "PA", Name = "Pennsylvania" },
            new StateCode { Id = 39, Code = "RI", Name = "Rhode Island" },
            new StateCode { Id = 40, Code = "SC", Name = "South Carolina" },
            new StateCode { Id = 41, Code = "SD", Name = "South Dakota" },
            new StateCode { Id = 42, Code = "TN", Name = "Tennessee" },
            new StateCode { Id = 43, Code = "TX", Name = "Texas" },
            new StateCode { Id = 44, Code = "UT", Name = "Utah" },
            new StateCode { Id = 45, Code = "VT", Name = "Vermont" },
            new StateCode { Id = 46, Code = "VA", Name = "Virginia" },
            new StateCode { Id = 47, Code = "WA", Name = "Washington" },
            new StateCode { Id = 48, Code = "WV", Name = "West Virginia" },
            new StateCode { Id = 49, Code = "WI", Name = "Wisconsin" },
            new StateCode { Id = 50, Code = "WY", Name = "Wyoming" });
        }
    }
}
