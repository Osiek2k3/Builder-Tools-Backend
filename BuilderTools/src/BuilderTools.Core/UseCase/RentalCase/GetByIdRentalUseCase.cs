using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.RentalCase
{
    public class GetByIdRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository;

        public GetByIdRentalUseCase(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task<RentalDto> ExecuteAsync(Guid rentalId)
        {
            var rental = await _rentalRepository.GetByIdAsync(rentalId);
            return rental.ToModel();
        }
    }
}
