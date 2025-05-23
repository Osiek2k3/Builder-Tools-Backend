using BuilderTools.Core.DTO;
using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.RentalCase
{
    public class AddRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository;

        public AddRentalUseCase(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task ExecuteAsync(RentalInputDto rentalInputDto)
        {
            var res = await _rentalRepository.IsToolAvailableAsync(rentalInputDto.BuilderToolId, rentalInputDto.DataStart, rentalInputDto.DataEnd);
            if (!res)
            {
                throw new InvalidException($"W tym okresie maszyna jest zajeta!");
            }
            await _rentalRepository.AddAsync(rentalInputDto.ToModel());
        }
    }
}
