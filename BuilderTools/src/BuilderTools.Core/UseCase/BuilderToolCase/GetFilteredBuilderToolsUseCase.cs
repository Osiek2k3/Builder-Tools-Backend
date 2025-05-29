using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class GetFilteredBuilderToolsUseCase
    {
        private readonly IBuilderToolRepository _repository;

        public GetFilteredBuilderToolsUseCase(IBuilderToolRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BuilderToolDto>> ExecuteAsync(string? search, string? sortBy, string? order, int page, int pageSize)
        {
            var tools = await _repository.GetFilteredAsync(search, sortBy, order, page, pageSize);
            return tools.Select(t => t.ToModel());
        }
    }
}
