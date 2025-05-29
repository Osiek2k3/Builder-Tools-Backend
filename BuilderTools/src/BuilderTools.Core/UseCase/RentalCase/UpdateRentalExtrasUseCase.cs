using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.RentalCase
{
    public class UpdateRentalExtrasUseCase
    {
        private readonly IRentalRepository _repository;

        public UpdateRentalExtrasUseCase(IRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(UpdateRentalExtrasDto dto)
        {
            if (dto.ExtraCost is not null && dto.ExtraCost < 0)
                throw new InvalidException($"Extra cost musi być większy lub równy 0. Podano: {dto.ExtraCost}");

            var res = await _repository.CheckIdRentalAsync(dto.RentalId);
            if (!res)
            {
                throw new InvalidException($"Wypozyczenia o tym Id nie istnieje {dto.RentalId}");
            }

            var rental = await _repository.GetByIdAsync(dto.RentalId);

            rental.ExtraCost = dto.ExtraCost;
            rental.Notes = dto.Notes;

            await _repository.UpdateAsync(rental);
        }
    }

}
