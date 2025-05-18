using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.CategoryCase
{
    public class GetAllCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDto>> ExecuteAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            return category.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Description = c.Description
            });
        }
    }
}
