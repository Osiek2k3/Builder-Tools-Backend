using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class GetBuilderToolCountUseCase
    {
        private readonly IBuilderToolRepository _repository;

        public GetBuilderToolCountUseCase(IBuilderToolRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> ExecuteAsync(string? search)
        {
            return await _repository.GetCountAsync(search);
        }
    }

}
