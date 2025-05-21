using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class EditBuilderToolUseCase
    {
        private readonly IBuilderToolRepository _builderToolRepository;

        public EditBuilderToolUseCase(IBuilderToolRepository builderToolRepository)
        {
            _builderToolRepository = builderToolRepository;
        }

        public async Task ExecuteAsync(BuilderToolDto builderToolDto)
        {
            await _builderToolRepository.UpdateAsync(builderToolDto.ToModel());
        }
    }
}
