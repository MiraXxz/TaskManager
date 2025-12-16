using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities.User;

namespace TaskManager.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SecurityGroup> SecurityGroups { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SecurityGroupRole>()
                .ToTable("SecurityGroupRoles");

            modelBuilder.Entity<Role>()
                .ToTable("Roles");

            modelBuilder.Entity<User>()
                .HasOne(u => u.SecurityGroup)
                .WithMany(sg => sg.Users)
                .HasForeignKey(u => u.SecurityGroupId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SecurityGroup>()
                .HasKey(sg => sg.Id);

            modelBuilder.Entity<SecurityGroupRole>()
                .HasKey(sgr => new { sgr.RoleId, sgr.SecurityGroupId});

            modelBuilder.Entity<SecurityGroupRole>()
               .HasOne(sgr => sgr.SecurityGroup)
               .WithMany(sg => sg.SecurityGroupRoles)
               .HasForeignKey(sgr => sgr.SecurityGroupId);

            modelBuilder.Entity<SecurityGroupRole>()
                .HasOne(sgr => sgr.Role)
                .WithMany(sgr => sgr.SecurityGroupRoles)
                .HasForeignKey(sgr => sgr.RoleId);
        }


    }
}
