using BuilderTools.Core.Model;

namespace BuilderTools.Core.Services
{
    public interface IBuilderToolRepository
    {
        Task AddAsync(BuilderTool BuilderTool);
        Task UpdateAsync(BuilderTool builder);
        Task<BuilderTool> GetByIdAsync(Guid BuilderToolId);
        Task<IEnumerable<BuilderTool>> GetAllAsync();
    }
}
