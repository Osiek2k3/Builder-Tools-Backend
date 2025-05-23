
using BuilderTools.Core.Model;

namespace BuilderTools.Core.Services
{
    public interface IRentalRepository
    {
        Task AddAsync(Rental rental);
        Task UpdateAsync(Rental rental);
        Task<Rental> GetByIdAsync(Guid rentalId);
        Task<bool> CheckIdRentalAsync(Guid rentalId);
        Task<bool> IsToolAvailableAsync(Guid builderToolId, DateTime newStart, DateTime newEnd);
        Task<IEnumerable<Rental>> GetAllAsync();
    }
}
