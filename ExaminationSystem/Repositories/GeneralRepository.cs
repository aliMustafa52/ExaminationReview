using ExaminationSystem.Entities;
using ExaminationSystem.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace ExaminationSystem.Repositories
{
    public class GeneralRepository<T> where T : BaseModel
    {
        ApplicationDbContext _dbContext;
        public GeneralRepository()
        {
            _dbContext = new ApplicationDbContext();
        }


        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>()
                .Where(c => c.IsActive);
        }

        public IQueryable<T> Get(Expression<Func<T,bool>> predicate)
        {
            return _dbContext.Set<T>()
                .Where(c => c.IsActive)
                .Where(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>()
                .SingleOrDefaultAsync(c =>c.Id == id &&c.IsActive);
        }


        public void Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task Delete(T entity)
        {
            var en = await GetByIdAsync(entity.Id);
            en.IsActive = false;

            await _dbContext.SaveChangesAsync();
        }

        public void UpdateInclude(T entity, params string[] modifiedProperties)
        {
            if (!_dbContext.Set<T>().Any(x => x.Id == entity.Id))
                return;

            var local = _dbContext.Set<T>()
                            .Local.FirstOrDefault(x => x.Id == entity.Id);
            EntityEntry entityEntry;

            if(local is null)
                entityEntry = _dbContext.Entry(entity);
            else
                entityEntry = _dbContext.ChangeTracker.Entries<T>()
                                .FirstOrDefault(x => x.Entity.Id == entity.Id);


            foreach(var property in entityEntry.Properties)
            {
                if(modifiedProperties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType()
                                .GetProperty(property.Metadata.Name)
                                .GetValue(entity);
                    property.IsModified = true;
                }
            }

            _dbContext.SaveChanges();
        }
    }
}
