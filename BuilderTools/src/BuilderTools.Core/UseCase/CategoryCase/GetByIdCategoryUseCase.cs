using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.CategoryCase
{
    public class GetByIdCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetByIdCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> ExecuteAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            return category.ToModel();
        }
    }
}
