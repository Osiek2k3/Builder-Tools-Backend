using BuilderTools.Core.Model;

namespace BuilderTools.Core.Services
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task<Category> GetByIdAsync(Guid categoryId);
        Task<bool> CheckIdCategoryAsync(Guid categoryId);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
