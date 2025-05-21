using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.RentalCase
{
    public class GetAllRentalUseCase
    {
        private readonly IRentalRepository _rentalRepository;

        public GetAllRentalUseCase(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }
        public async Task<IEnumerable<RentalDto>> ExecuteAsync()
        {
            var builderTools = await _rentalRepository.GetAllAsync();
            return builderTools.Select(c => new RentalDto(c.RentalId, c.UserId, c.BuilderToolId,
                c.DataStart, c.DataEnd, c.Amount, c.Deposit, c.ExtraCost, c.Notes));
        }
    }
}
