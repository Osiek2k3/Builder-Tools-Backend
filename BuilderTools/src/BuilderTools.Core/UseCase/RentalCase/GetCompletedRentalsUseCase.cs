using BuilderTools.Core.DTO;
using BuilderTools.Core.Services;

namespace BuilderTools.Core.UseCase.RentalCase
{
    public class GetCompletedRentalsUseCase
    {
        private readonly IRentalRepository _repository;

        public GetCompletedRentalsUseCase(IRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RentalDto>> ExecuteAsync(Guid userId)
        {
            var result = await _repository.GetCompletedRentalsAsync(userId);
            return result.Select(r => r.ToModel());
        }
    }

}
