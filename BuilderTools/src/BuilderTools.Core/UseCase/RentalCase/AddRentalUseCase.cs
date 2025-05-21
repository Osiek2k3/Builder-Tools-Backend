using BuilderTools.Core.DTO;
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
            await _rentalRepository.AddAsync(rentalInputDto.ToModel());
        }
    }
}
