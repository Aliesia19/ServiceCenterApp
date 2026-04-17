using ServiceCenterApp.Domain.Entities;
using ServiceCenterApp.Infrastructure.DataAccess.MsSql.Context;
using System.Linq;

namespace ServiceCenterApp.Infrastructure.DataAccess.MsSql
{
    public class DatabaseInitializer
    {
        private readonly AppDbContext _context;

        public DatabaseInitializer(AppDbContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();

            if (!_context.Services.Any())
            {
                _context.Services.AddRange(
                    new Service
                    {
                        Id = Guid.NewGuid(),
                        Name = "Repair",
                        BasePrice = 500
                    },
                    new Service
                    {
                        Id = Guid.NewGuid(),
                        Name = "Diagnostics",
                        BasePrice = 200
                    }
                );
            }

            if (!_context.EquipmentTypes.Any())
            {
                _context.EquipmentTypes.AddRange(
                    new EquipmentType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Laptop"
                    },
                    new EquipmentType
                    {
                        Id = Guid.NewGuid(),
                        Name = "Phone"
                    }
                );
            }

            _context.SaveChanges();
        }
    }
}