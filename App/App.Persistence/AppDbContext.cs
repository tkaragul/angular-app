using App.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Dinamik DbSet ekle
            RegisterDbSets(modelBuilder);           
        }

        // Dinamik DbSetleri tanımlar
        private void RegisterDbSets(ModelBuilder modelBuilder)
        {
            // Domain katmanındaki tüm entity türlerini bulur.
            var entityTypes = Assembly.GetAssembly(typeof(IEntity)) // IEntity'den assembly referansı
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(IEntity)
                .IsAssignableFrom(t));

            foreach (var entityType in entityTypes)
            {
                modelBuilder.Entity(entityType); // Her bir entity için model ekler.
            }
        }

        // Dinamik DbSet'e erişim sağlar
        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>(); // DbSet<TEntity>'i döndürür
        }
    }
}