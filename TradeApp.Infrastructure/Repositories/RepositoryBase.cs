using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TradeApp.Domain.Interfaces.InterfacesRepository;

namespace TradeApp.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly TradingDbContext _dbContext;

        public RepositoryBase(TradingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> FindAll()
        {
            var result = _dbContext.Set<T>()
                .AsNoTracking();

            return result;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var result = _dbContext.Set<T>()
                .Where(expression).
                AsNoTracking();

            return result;
        }

        public void Create(T input)
        {
            _dbContext.Set<T>()
                .Add(input);
        }

        public void Update(T input)
        {
            _dbContext.Set<T>()
                .Update(input);
        }
        
        public void Delete(T input)
        {
            _dbContext.Set<T>()
                .Remove(input);
        }
    }
}