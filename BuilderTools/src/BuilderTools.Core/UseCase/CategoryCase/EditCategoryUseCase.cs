using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.CategoryCase
{
    public class EditCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(CategoryDto categoryDto)
        {
            await _categoryRepository.UpdateAsync(categoryDto.ToModel());
        }
    }
}
