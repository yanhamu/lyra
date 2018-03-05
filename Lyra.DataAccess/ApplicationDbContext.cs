using Lyra.DataAccess.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Lyra.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            MapPlayer(builder.Entity<Player>());

            base.OnModelCreating(builder);
        }

        private void MapPlayer(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Realm).WithMany().HasForeignKey(e => e.RealmId);
            builder.OwnsOne(e => e.Turns);
        }

        public DbSet<Realm> Realms { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
