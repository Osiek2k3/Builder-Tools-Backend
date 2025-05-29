using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.RentalCase
{
    public class DeleteRentalUseCase
    {
        private readonly IRentalRepository _repository;

        public DeleteRentalUseCase(IRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Guid id)
        {
            var res = await _repository.CheckIdRentalAsync(id);
            if (!res)
            {
                throw new InvalidException($"Wypozyczenia o tym Id nie istnieje {id}");
            }
            
            await _repository.DeleteAsync(id);
        }
    }

}
