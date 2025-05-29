using BuilderTools.Core.Model;

namespace BuilderTools.Core.Services
{
    public interface IBuilderToolRepository
    {
        Task AddAsync(BuilderTool BuilderTool);
        Task UpdateAsync(BuilderTool builder);
        Task<BuilderTool> GetByIdAsync(Guid BuilderToolId);
        Task<bool> CheckIdBuilderToolAsync(Guid BbuilderToolId);
        Task<IEnumerable<BuilderTool>> GetAllAsync();
        Task<IEnumerable<BuilderTool>> GetFilteredAsync(string? search, string? sortBy, string? order, int page, int pageSize);
        Task<int> GetCountAsync(string? search);
        Task DeleteAsync(Guid id);

    }
}
