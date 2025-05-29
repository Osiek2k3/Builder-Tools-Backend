using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;
using BuilderTools.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _dbContext;

        public CategoryRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Category category)
        {
            try
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas pobierania braków produktów.", ex);
            }
        }

        public async Task UpdateAsync(Category category)
        {
            try
            {
                var existingCategory = await _dbContext.Categories.FindAsync(category.CategoryId);
                if (existingCategory == null)
                {
                    throw new NotFoundException($"Kategoria o ID '{category.CategoryId}' nie została znaleziona.");
                }

                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;

                _dbContext.Categories.Update(existingCategory);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas edytowania kategorii.", ex);
            }
        }


        public async Task<Category> GetByIdAsync(Guid categoryId)
        {
            try
            {
                var category = await _dbContext.Categories
                    .FirstOrDefaultAsync(u => u.CategoryId == categoryId);

                return category;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas próby polaczenia z baza.", ex);
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            try
            {
                var category = await _dbContext.Categories
                    .ToListAsync();

                return category;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas próby polaczenia z baza.", ex);
            }
        }

        public async Task<bool> CheckIdCategoryAsync(Guid categoryId)
        {
            return await _dbContext.Categories
                .AnyAsync(x => x.CategoryId == categoryId);
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
