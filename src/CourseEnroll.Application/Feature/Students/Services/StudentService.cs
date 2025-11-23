using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseEnroll.Application.Feature.Students.DTOs;
using CourseEnroll.Application.Feature.Students.Interfaces;
using CourseEnroll.Domain.Entities;
using CourseEnroll.Domain.Interfaces;

namespace CourseEnroll.Application.Feature.Students.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public StudentService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<bool> DeleteStudentAsync(Guid id, CancellationToken ct)
        {
            var student = await _uow.Students.GetByIdAsync(id, ct);
            if (student == null) return false;

            _uow.Students.Delete(student);
            await _uow.SaveChangesAsync(ct);
            return true;
        }

        public async Task<StudentDetailDto?> GetStudentProfileAsync(Guid id, CancellationToken ct)
        {
            var student = await _uow.Students.GetByIdAsync(id, ct);
            if (student == null) return null;
            var res = _mapper.Map<StudentDetailDto>(student);
            return res;
        }

        public async Task<IEnumerable<StudentSummaryDto>> GetStudentsAsync(CancellationToken ct)
        {
            var student = await _uow.Students.GetAllAsync(ct);
            var res = _mapper.Map<IEnumerable<StudentSummaryDto>>(student);
            return res;
        }

        public async Task<Guid> RegisterStudentAsync(StudentCreateDto request, CancellationToken ct)
        {
            var student = _mapper.Map<Student>(request);
            await _uow.Students.CreateAsync(student, ct);
            await _uow.SaveChangesAsync(ct);
            return student.Id;
        }

        public async Task<bool> UpdateStudentAsync(Guid id, StudentUpdateDto request, CancellationToken ct)
        {
            var student = await _uow.Students.GetByIdAsync(id, ct);
            if (student == null) return false;

            _mapper.Map(request, student);
            _uow.Students.Update(student);

            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}