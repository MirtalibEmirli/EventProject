using EventProject.Application.Repositories.VenueMediaFiles;
using EventProject.Domain.Entities;
using EventProject.Persistence.Data;
using EventProject.Persistence.Repository.Generics;

namespace EventProject.Persistence.Repository.VenueMediaFiles;

public class VenueMediaFileWriteRepository:WriteRepository<VenueMediaFile>,IVenueMediaFileWriteRepository
{
    public VenueMediaFileWriteRepository(AppDbContext appContext):base(appContext)
    {
        
    }
}
