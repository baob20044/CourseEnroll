using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Student> Students { get; }
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}