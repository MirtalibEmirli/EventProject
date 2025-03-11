using EventProject.Application.Repositories.Medias;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Persistence.Repository.Medias;

public class MediaRepository : IMediaRepository
{
    private readonly AppDbContext _context;

    public MediaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Media media)
    {
        await _context.Medias.AddAsync(media);
    }

    public async Task<List<Media>> GetMediasByEventIdAsync(Guid eventId)
    {
        return await _context.Medias.Where(m => m.EventId == eventId).ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

}
