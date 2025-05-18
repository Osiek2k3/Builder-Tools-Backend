using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.CategoryCase
{
    public class AddCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(CategoryInputDto categoryInputDto)
        {
            await _categoryRepository.AddAsync(categoryInputDto.ToModel());
        }
    }
}
