using Microsoft.EntityFrameworkCore;
using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Domain.ValueObjects;

namespace ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<RepairRequest> RepairRequests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Value Object
            modelBuilder.Entity<RepairRequest>()
                .OwnsOne(r => r.ClientAddress);

            // 🔥 ВОТ ЭТО ТЫ ДОБАВЛЯЕШЬ
            modelBuilder.Entity<RepairRequest>()
                .HasOne(r => r.Client)
                .WithMany()
                .HasForeignKey(r => r.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RepairRequest>()
                .HasOne(r => r.Consultant)
                .WithMany()
                .HasForeignKey(r => r.ConsultantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RepairRequest>()
                .HasOne(r => r.Master)
                .WithMany()
                .HasForeignKey(r => r.MasterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}