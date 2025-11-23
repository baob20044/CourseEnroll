using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CourseEnroll.Domain.Interfaces;
using CourseEnroll.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseEnroll.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<int> CountAsync(CancellationToken ct)
        {
            return await _dbSet.CountAsync(ct);
        }

        public async Task CreateAsync(T entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken ct)
        {
            return await _dbSet.AnyAsync(predicate, ct);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken ct)
        {
            return await _dbSet.ToListAsync(ct);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            return await _dbSet.FindAsync(id, ct);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}