using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseEnroll.Domain.Entities;
using CourseEnroll.Domain.Interfaces;
using CourseEnroll.Infrastructure.Persistence;

namespace CourseEnroll.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IGenericRepository<Student> _studentRepo;
        public UnitOfWork(
            AppDbContext context,
            IGenericRepository<Student> studentRepo
        )
        {
            _context = context;
            _studentRepo = studentRepo;
        }

        public IGenericRepository<Student> Students => _studentRepo;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}