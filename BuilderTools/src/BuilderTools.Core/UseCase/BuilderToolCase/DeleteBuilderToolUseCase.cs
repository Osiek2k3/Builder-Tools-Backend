using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.BuilderToolCase
{
    public class DeleteBuilderToolUseCase
    {
        private readonly IBuilderToolRepository _repository;

        public DeleteBuilderToolUseCase(IBuilderToolRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id)
        { 
            var res = await _repository.CheckIdBuilderToolAsync(id);
            if (!res)
            {
                throw new InvalidException($"Maszyna o tym Id nie istnieje {id}");
            }

            await _repository.DeleteAsync(id);
        }
    }

}
