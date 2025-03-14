using EventProject.Domain.Enums;

namespace EventProject.Domain.Entities;

public class StandingZone:  BaseEntity
{
    public SZoneType ZoneName { get; set; } 
    public int Capacity { get; set; }
    public int TicketSold { get; set; } = 0;

}
