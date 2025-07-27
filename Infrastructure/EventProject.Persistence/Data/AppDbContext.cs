using Microsoft.EntityFrameworkCore;
using EventProject.Domain.Entities;
using EventProject.Domain.Enums;
using File = EventProject.Domain.Entities.File;

namespace EventProject.Persistence.Data;

public class AppDbContext : DbContext
{
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<UserMediaFile> UserMediaFiles { get; set; }
    public DbSet<EventMediaFile> EventMediaFiles { get; set; }
    public DbSet<VenueMediaFile> VenueMediaFiles { get; set; }
    public DbSet<UserRwEvent> UserRwEvents { get; set; }
    public DbSet<RefreshToken> UserRefreshTokens { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        

        modelBuilder.Entity<UserRwEvent>().HasKey(ur => new { ur.UserId, ur.EventId });

        modelBuilder.Entity<UserRwEvent>().HasOne(ur => ur.User).WithMany(u => u.UserRwEvents).HasForeignKey(ur => ur.UserId);
        modelBuilder.Entity<UserRwEvent>().HasOne(ur => ur.Event).WithMany(e => e.UserRwEvents).HasForeignKey(e => e.EventId);

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = Guid.NewGuid(), // or a fixed GUID if you want repeatable seed
            Fistname = "Emil",
            Lastname = "Abdullayev",
            Email = "emil@gmail.com",
            PasswordHash = "cf581ba3c0e3ce147b7250868997039215bf6533896975f50427645cedbed79a", // already hashed
            Role = Role.Admin,
            ProfilePictureId = null
        });

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Category)
            .WithMany(c => c.Events)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.Location)
            .WithMany(v => v.Events)
            .HasForeignKey(e => e.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Event>()
            .HasMany(e => e.Tickets)
            .WithOne(t => t.Event)
            .HasForeignKey(t => t.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Event>()
            .HasMany(e => e.Comments)
            .WithOne(c => c.Event)
            .HasForeignKey(c => c.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Event>()
            .HasMany(e => e.MediaFiles)
            .WithOne(m => m.Event)
            .HasForeignKey(m => m.EventId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Tickets)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Payments)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .HasOne(u => u.ProfilePicture)
            .WithOne()
            .HasForeignKey<User>(u => u.ProfilePictureId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany()
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<File>()
            .Property(x => x.StorageType)
            .HasConversion<string>()
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<UserMediaFile>()
            .HasOne(umf => umf.User)
            .WithMany()
            .HasForeignKey(umf => umf.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.State == EntityState.Added);

        var entriesUpdate = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);

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
