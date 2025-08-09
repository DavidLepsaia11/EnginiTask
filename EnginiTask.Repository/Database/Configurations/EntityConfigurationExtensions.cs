using EnginiTask.Repository.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EnginiTask.Repository.Database.Configurations
{
    internal static class EntityConfigurationExtensions
    {
        public static void ConfigureEntities(this ModelBuilder modelBuilder)
        {
            var configurationType = typeof(IEntityConfiguration);
            _ = (
              from t in typeof(IEntityConfiguration).Assembly.GetTypes()
              where configurationType.IsAssignableFrom(t) && !t.IsAbstract
              select (Activator.CreateInstance(t, modelBuilder) as IEntityConfiguration)?.Configure()
            ).ToArray();
        }
    }
}
