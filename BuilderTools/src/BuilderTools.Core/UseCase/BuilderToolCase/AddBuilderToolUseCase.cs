using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class AddBuilderToolUseCase
    {
        private readonly IBuilderToolRepository _builderToolRepository;

        public AddBuilderToolUseCase(IBuilderToolRepository builderToolRepository)
        {
            _builderToolRepository = builderToolRepository;
        }

        public async Task ExecuteAsync(BuilderToolInputDto builderToolInputDto)
        {
            await _builderToolRepository.AddAsync(builderToolInputDto.ToModel());
        }
    }
}
