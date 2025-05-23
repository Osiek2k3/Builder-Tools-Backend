using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;
using BuilderTools.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.Repositories
{
    internal class RentalRepository : IRentalRepository
    {
        private readonly MyDbContext _dbContext;

        public RentalRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Rental rental)
        {
            try
            {
                await _dbContext.Rentals.AddAsync(rental);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas pobierania danych", ex);
            }
        }

        public async Task<bool> CheckIdRentalAsync(Guid rentalId)
        {
            return await _dbContext.Rentals
                .AnyAsync(x => x.RentalId == rentalId);
        }

        public async Task<IEnumerable<Rental>> GetAllAsync()
        {
            try
            {
                var rentals = await _dbContext.Rentals
                    .ToListAsync();

                return rentals;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas próby polaczenia z baza.", ex);
            }
        }

        public async Task<Rental> GetByIdAsync(Guid rentalId)
        {
            try
            {
                var category = await _dbContext.Rentals
                    .FirstOrDefaultAsync(u => u.RentalId == rentalId);

                return category;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas próby polaczenia z baza.", ex);
            }
        }

        public async Task UpdateAsync(Rental rental)
        {
            try
            {
                var existingRental = await _dbContext.Rentals.FindAsync(rental.RentalId);
                if (existingRental == null)
                {
                    throw new NotFoundException($"Kategoria o ID '{rental.RentalId}' nie została znaleziona.");
                }

                existingRental.UserId = rental.UserId; 
                existingRental.BuilderToolId = rental.BuilderToolId;
                existingRental.DataStart = rental.DataStart;
                existingRental.DataEnd = rental.DataEnd;
                existingRental.Amount = rental.Amount;
                existingRental.Deposit = rental.Deposit;
                existingRental.ExtraCost = rental.ExtraCost;
                existingRental.Notes = rental.Notes;

                _dbContext.Rentals.Update(existingRental);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas edytowania kategorii.", ex);
            }
        }

        public async Task<bool> IsToolAvailableAsync(Guid builderToolId, DateTime newStart, DateTime newEnd)
        {
            return !await _dbContext.Rentals
                .AnyAsync(r =>
                    r.BuilderToolId == builderToolId &&
                    r.DataStart < newEnd &&
                    r.DataEnd > newStart);
        }
    }
}
