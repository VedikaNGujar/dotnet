using BubberDinner.Domain.MenuAggregator;
using BubberDinner.Domain.Models;
using BubberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace BubberDinner.Infrastructure.Persistence
{
    public class BubberDinnerDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptors _publishDomainEventsInterceptors;

        public BubberDinnerDbContext(DbContextOptions<BubberDinnerDbContext> options, PublishDomainEventsInterceptors publishDomainEventsInterceptors)
            : base(options)
        {
            _publishDomainEventsInterceptors = publishDomainEventsInterceptors;
        }

        public DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<List<IDomainEvent>>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BubberDinnerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptors);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
