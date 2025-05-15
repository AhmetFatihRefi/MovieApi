using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MoviewContext _context;
        public GetCategoryByIdQueryHandler(MoviewContext context)
        {
            _context = context;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery command)
        {
            var category = await _context.Categories.FindAsync(command);
            if (category == null)
            {
                return new();
            }
            return new GetCategoryByIdQueryResult
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
    }
}
