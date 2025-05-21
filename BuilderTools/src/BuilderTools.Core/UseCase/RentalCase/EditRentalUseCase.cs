using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.RentalCase
{
    public class EditRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository;

        public EditRentalUseCase(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task ExecuteAsync(RentalDto rentalDto)
        {
            await _rentalRepository.UpdateAsync(rentalDto.ToModel());
        }
    }
}
