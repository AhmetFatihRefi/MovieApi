using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(RemoveCategoryCommandHandler deleteCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _removeCategoryCommandHandler = deleteCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var value = await _getCategoryQueryHandler.Handle();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Kategori ekleme işlemi başarıyla tamamlandı.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Kategori silme işlemi başarıyla tamamlandı.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarılı");

        }

        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }
    }
}
