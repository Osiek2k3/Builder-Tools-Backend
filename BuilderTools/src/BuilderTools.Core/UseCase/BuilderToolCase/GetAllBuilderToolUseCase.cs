using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class GetAllBuilderToolUseCase
    {
        private readonly IBuilderToolRepository _builderToolRepository;

        public GetAllBuilderToolUseCase(IBuilderToolRepository builderToolRepository)
        {
            _builderToolRepository = builderToolRepository;
        }

        public async Task<IEnumerable<BuilderToolDto>> ExecuteAsync()
        {
            var builderTools = await _builderToolRepository.GetAllAsync();
            return builderTools.Select(c => new BuilderToolDto(c.BuilderToolId, c.CategoryId, c.Name, c.Permission, c.PricePerDay, c.Image));
        }
    }
}
