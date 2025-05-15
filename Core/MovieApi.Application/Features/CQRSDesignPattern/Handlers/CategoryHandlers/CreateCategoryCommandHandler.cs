using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly MoviewContext _context;

        public CreateCategoryCommandHandler(MoviewContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCategoryCommand request)
        {
            _context.Categories.Add(new Category
            {
                CategoryName = request.CategoryName
            });
            await _context.SaveChangesAsync();
        }
    }
}
