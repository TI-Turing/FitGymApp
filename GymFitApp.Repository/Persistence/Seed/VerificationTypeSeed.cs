using System;
using System.Linq;
using System.Threading.Tasks;
using FitGymApp.Domain.Models;

namespace FitGymApp.Repository.Persistence.Seed
{
    public static class VerificationTypeSeed
    {
        public static async Task SeedAsync(FitGymAppContext context)
        {
            if (!context.VerificationTypes.Any(x => x.Name == "Email"))
            {
                context.VerificationTypes.Add(new VerificationType
                {
                    Id = new Guid("DDA61A30-679D-4AFF-887C-69DF91E4D21E"),
                    Name = "Email",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                });
            }
            if (!context.VerificationTypes.Any(x => x.Name == "Phone"))
            {
                context.VerificationTypes.Add(new VerificationType
                {
                    Id = new Guid("2082D337-B3FD-4F9A-8C89-AF9C1038DA9C"),
                    Name = "Phone",
                    CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                    IsActive = true
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
