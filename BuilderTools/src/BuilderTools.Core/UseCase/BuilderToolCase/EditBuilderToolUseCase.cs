using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class EditBuilderToolUseCase
    {
        private readonly IBuilderToolRepository _builderToolRepository;
        private readonly ICategoryRepository _categoryRepository;

        public EditBuilderToolUseCase(IBuilderToolRepository builderToolRepository,
            ICategoryRepository categoryRepository)
        {
            _builderToolRepository = builderToolRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(BuilderToolDto builderToolDto)
        {
            var res = await _categoryRepository.CheckIdCategoryAsync(builderToolDto.CategoryId);
            if (!res)
            {
                throw new InvalidException($"kategoria o tym Id nie istnieje {builderToolDto.CategoryId}");
            }
            await _builderToolRepository.UpdateAsync(builderToolDto.ToModel());
        }
    }
}
