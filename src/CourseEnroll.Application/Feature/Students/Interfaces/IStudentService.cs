using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseEnroll.Application.Feature.Students.DTOs;

namespace CourseEnroll.Application.Feature.Students.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentSummaryDto>> GetStudentsAsync(CancellationToken ct);
        Task<StudentDetailDto?> GetStudentProfileAsync(Guid id, CancellationToken ct);
        Task<Guid> RegisterStudentAsync(StudentCreateDto request, CancellationToken ct);
        Task<bool> UpdateStudentAsync(Guid id, StudentUpdateDto request, CancellationToken ct);
        Task<bool> DeleteStudentAsync(Guid id, CancellationToken ct);
    }
}