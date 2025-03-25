using Microsoft.EntityFrameworkCore;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using File = EventProject.Domain.Entities.File;

namespace EventProject.Persistence.Data;
public class AppDbContext : DbContext
{
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<EventSeatPrice> EventSeatPrices { get; set; }
    public DbSet<SectionWeight> SectionWeights { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<StandingZone> StandingZones { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<UserMediaFile> UserMediaFiles { get; set; }
    public DbSet<EventMediaFile> EventMediaFiles { get; set; }
    public DbSet<VenueImageFile> VenueImageFiles { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // BaseEntity üçün əsas konfiqurasiya
        
        // Event və Category əlaqəsi (Many-to-One)
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Category)
            .WithMany(c => c.Events)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Event və Venue əlaqəsi (Many-to-One)
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Location)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);

        // Event və Ticket əlaqəsi (One-to-Many)
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Tickets)
            .WithOne(t => t.Event)
            .HasForeignKey(t => t.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // Event və Comment əlaqəsi (One-to-Many)
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Comments)
            .WithOne(c => c.Event)
            .HasForeignKey(c => c.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // Event və Payment əlaqəsi (One-to-Many)
        modelBuilder.Entity<Event>()
            .HasMany(e => e.Payments)
            .WithOne(p => p.Event)
            .HasForeignKey(p => p.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // Event və MediaFile əlaqəsi (One-to-Many)
        modelBuilder.Entity<Event>()
            .HasMany(e => e.MediaFiles)
            .WithOne(m => m.Event)
            .HasForeignKey(m => m.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        // User və Ticket əlaqəsi (One-to-Many)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Tickets)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User və Payment əlaqəsi (One-to-Many)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Payments)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User və Comment əlaqəsi (One-to-Many)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User və Notification əlaqəsi (One-to-Many)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Payments)
            .WithOne(n => n.User)
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // User və ProfilePicture əlaqəsi (One-to-One)
        modelBuilder.Entity<User>()
       .HasOne(u => u.ProfilePicture)
       .WithOne()
       .HasForeignKey<User>(u => u.ProfilePictureId)
       .OnDelete(DeleteBehavior.SetNull);

        // Seat və Venue əlaqəsi (Many-to-One)
        modelBuilder.Entity<Seat>()
            .HasOne(s => s.Venue)
            .WithMany()
            .HasForeignKey(s => s.VenueId)
            .OnDelete(DeleteBehavior.Cascade);

        // Venue və VenueImageFile əlaqəsi (One-to-Many)
        modelBuilder.Entity<Venue>()
            .HasMany(v => v.VenueImages)
            .WithOne(vi => vi.Venue)
            .HasForeignKey(vi => vi.VenueId)
            .OnDelete(DeleteBehavior.Cascade);

        // Ticket və Seat əlaqəsi (One-to-One)
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Seat)
            .WithOne(s => s.Ticket)
            .HasForeignKey<Ticket>(t => t.SeatId)
            .OnDelete(DeleteBehavior.SetNull);

        // Ticket və StandingZone əlaqəsi (One-to-One)
        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.StandingZone)
            .WithMany()
            .HasForeignKey(t => t.StandingZoneId)
            .OnDelete(DeleteBehavior.SetNull);

       
        modelBuilder.Entity<File>()
                    .Property(x=>x.StorageType)
                    .HasConversion<string>()
                    .HasMaxLength(100)
                    .IsRequired();

    }
  
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Added);

        var entriesUpdate =ChangeTracker.Entries().Where(e=>e.State == EntityState.Modified);

        foreach (var entry in entries)
        {
            if (entry.Entity is BaseEntity baseEntity)
            {
                baseEntity.CreatedDate = DateTime.Now;
            }
        }

        foreach (var entry in entriesUpdate)
        {
            if (entry.Entity is BaseEntity baseEntity)
            {
                baseEntity.UpdatedDate = DateTime.Now;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
