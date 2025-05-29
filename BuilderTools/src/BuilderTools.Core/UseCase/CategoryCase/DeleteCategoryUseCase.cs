using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.CategoryCase
{
    public class DeleteCategoryUseCase
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryUseCase(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var res = await _repository.CheckIdCategoryAsync(id);
            if (!res)
            {
                throw new InvalidException($"kategoria o tym Id nie istnieje {id}");
            }

            await _repository.DeleteAsync(id);
        }
    }

}
