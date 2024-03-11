using Microsoft.EntityFrameworkCore;
using trainingcommandside.Events;
using trainingcommandside.Infrastructure.Persistance.Configurations;

namespace trainingcommandside.Infrastructure.Persistance
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.ApplyConfiguration(new BaseEventConfigurations());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<InvitationSent, InvitationSentData>());
 
        }
    }
}
