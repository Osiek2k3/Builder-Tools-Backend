using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
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
            var res = await _rentalRepository.IsToolAvailableAsync(rentalDto.BuilderToolId, rentalDto.DataStart, rentalDto.DataEnd);
            if (!res)
            {
                throw new InvalidException($"W tym okresie maszyna jest zajeta!");
            }
            await _rentalRepository.UpdateAsync(rentalDto.ToModel());
        }
    }
}
