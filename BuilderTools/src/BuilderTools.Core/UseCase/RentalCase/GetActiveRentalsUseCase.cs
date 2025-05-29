using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.RentalCase
{
    public class GetActiveRentalsUseCase
    {
        private readonly IRentalRepository _repository;

        public GetActiveRentalsUseCase(IRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RentalDto>> ExecuteAsync(Guid userId)
        {
            var result = await _repository.GetActiveRentalsAsync(userId);
            return result.Select(r => r.ToModel());
        }
    }

}
