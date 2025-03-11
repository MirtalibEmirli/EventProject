using EventProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventProject.Application.Features.Queries.EventCategoryQueries.GetAllEventCategories;

public class GetAllEventCategoriesResponse
{
    //public IEnumerable<GetAllCategories> NamesCategories { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}
