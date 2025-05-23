using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class AddBuilderToolUseCase
    {
        private readonly IBuilderToolRepository _builderToolRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AddBuilderToolUseCase(IBuilderToolRepository builderToolRepository,
            ICategoryRepository categoryRepository)
        {
            _builderToolRepository = builderToolRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(BuilderToolInputDto builderToolInputDto)
        {
            var res = await _categoryRepository.CheckIdCategoryAsync(builderToolInputDto.CategoryId);
            if (!res)
            {
                throw new InvalidException($"kategoria o tym Id nie istnieje {builderToolInputDto.CategoryId}");
            }
            await _builderToolRepository.AddAsync(builderToolInputDto.ToModel());
        }
    }
}
