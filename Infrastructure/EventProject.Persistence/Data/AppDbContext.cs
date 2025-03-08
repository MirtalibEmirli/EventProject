using EventProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventProject.Persistence.Data;
public class AppDbContext : DbContext
{


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Event> Events { get; set; }

    public DbSet<EventCategory> Categories { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<Payment> Payments { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<Notification> Notifications { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany(u => u.Comments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.NoAction); 
        modelBuilder.Entity<Event>().Property(e=>e.Price).HasPrecision(18,2);
        modelBuilder.Entity<Ticket>().Property(t => t.Price).HasPrecision(18, 2);
        modelBuilder.Entity<Payment>().Property(p=>p.Amount).HasPrecision(18, 2);   

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Event)
            .WithMany(e => e.Comments)
            .HasForeignKey(c => c.EventId)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<Payment>()
       .HasOne(p => p.User)
       .WithMany(u => u.Payments)
       .HasForeignKey(p => p.UserId)
       .OnDelete(DeleteBehavior.NoAction);  

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Event)
            .WithMany(e => e.Payments)
            .HasForeignKey(p => p.EventId)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Ticket>()
        .HasOne(t => t.User)
        .WithMany(u => u.Tickets)
        .HasForeignKey(t => t.UserId)
        .OnDelete(DeleteBehavior.NoAction);  

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Event)
            .WithMany(e => e.Tickets)
            .HasForeignKey(t => t.EventId)
            .OnDelete(DeleteBehavior.NoAction);
    }

}
