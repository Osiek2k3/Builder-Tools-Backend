using BuilderTools.Core.Exceptions;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;
using BuilderTools.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace BuilderTools.Infrastructure.Repositories
{
    public class BuilderToolRepository : IBuilderToolRepository
    {
        private readonly MyDbContext _dbContext;

        public BuilderToolRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(BuilderTool BuilderTool)
        {
            try
            {
                await _dbContext.BuilderTools.AddAsync(BuilderTool);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas pobierania danych", ex);
            }
        }

        public async Task UpdateAsync(BuilderTool builderTool)
        {
            try
            {
                var existingBuilderTool = await _dbContext.BuilderTools.FindAsync(builderTool.BuilderToolId);
                if (existingBuilderTool == null)
                {
                    throw new NotFoundException($"Kategoria o ID '{builderTool.BuilderToolId}' nie została znaleziona.");
                }

                existingBuilderTool.Name = builderTool.Name;
                existingBuilderTool.Permission = builderTool.Permission;
                existingBuilderTool.PricePerDay = builderTool.PricePerDay;
                existingBuilderTool.CategoryId = builderTool.CategoryId;
                existingBuilderTool.Image = builderTool.Image;


                _dbContext.BuilderTools.Update(existingBuilderTool);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas edytowania kategorii.", ex);
            }
        }


        public async Task<BuilderTool> GetByIdAsync(Guid BuilderToolId)
        {
            try
            {
                var builderTool = await _dbContext.BuilderTools
                    .FirstOrDefaultAsync(u => u.BuilderToolId == BuilderToolId);

                return builderTool;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas próby polaczenia z baza.", ex);
            }
        }

        public async Task<IEnumerable<BuilderTool>> GetAllAsync()
        {
            try
            {
                var builderTool = await _dbContext.BuilderTools
                    .ToListAsync();

                return builderTool;
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas próby polaczenia z baza.", ex);
            }
        }

        public async Task<bool> CheckIdBuilderToolAsync(Guid builderToolId)
        {
            return await _dbContext.BuilderTools
                .AnyAsync(x => x.BuilderToolId == builderToolId);
        }

        public async Task<IEnumerable<BuilderTool>> GetFilteredAsync(string? search, string? sortBy, string? order, int page, int pageSize)
        {
            try
            {
                var query = _dbContext.BuilderTools.AsQueryable();

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(t => t.Name.ToLower().Contains(search.ToLower()));
                }

                query = (sortBy?.ToLower(), order?.ToLower()) switch
                {
                    ("price", "desc") => query.OrderByDescending(t => t.PricePerDay),
                    ("price", _) => query.OrderBy(t => t.PricePerDay),
                    ("name", "desc") => query.OrderByDescending(t => t.Name),
                    _ => query.OrderBy(t => t.Name)
                };

                return await query
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas filtrowania i sortowania narzędzi", ex);
            }
        }

        public async Task<int> GetCountAsync(string? search)
        {
            try
            {
                var query = _dbContext.BuilderTools.AsQueryable();

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(t => t.Name.ToLower().Contains(search.ToLower()));
                }

                return await query.CountAsync();
            }
            catch (Exception ex)
            {
                throw new DatabaseException("Błąd podczas liczenia BuilderTooli", ex);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var tool = await _dbContext.BuilderTools.FindAsync(id);
            if (tool != null)
            {
                _dbContext.BuilderTools.Remove(tool);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
