using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SCMS.Models;

namespace SCMS.DAL
{
    public class DataBaseContext : DbContext
    {
        public DbSet<POC> POC { get; set; }
        public DbSet<POME> POME { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DestinationPort> DestinationPort { get; set; }
        public DbSet<Alloy> Alloy { get; set; }
        public DbSet<Incoterm> Incoterm { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Shipment> Shipment{ get; set; }
        public DbSet<Container> Container { get; set; }
        public DbSet<BL> BL { get; set; }
        public DbSet<Document> Document { get; set; }


        //USER MANAGEMENT SYSTEM
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<OAuthMembership> OAuthMembership { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            //User Management System
            modelBuilder.Entity<Membership>()
              .HasMany<Role>(r => r.Roles)
              .WithMany(u => u.Members)
              .Map(m =>
              {
                  m.ToTable("webpages_UsersInRoles");
                  m.MapLeftKey("UserId");
                  m.MapRightKey("RoleId");
              });
        }
    }
}