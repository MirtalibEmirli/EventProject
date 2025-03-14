﻿using EventProject.Domain.Entities;

public class Event:BaseEntity
{

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public int AgeLimit { get; set; }
    public DateTime EndTime { get; set; }

    public string Location { get; set; } = string.Empty;

    public decimal Price { get; set; } = 0;

    public string Status { get; set; } = "Active"; // Active, Canceled, Past

    //// Foreign Keys
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public Guid OrganizerId { get; set; }= Guid.Parse("6d4b5992-47d4-4a33-9470-57556a455f58");
    public User Organizer { get; set; } = null!;
     

    //// Relations
    public List<Ticket> Tickets { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();
    public List<Media> MediaFiles { get; set; } = new(); //sekil ve videolar ile elaqelendirek
}
