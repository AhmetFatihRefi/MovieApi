using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly MoviewContext _context;

        public GetCategoryQueryHandler(MoviewContext context)
        {
            _context = context;
        }

        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories.Select(c => new GetCategoryQueryResult
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            }).ToList();
        }
    }
}
