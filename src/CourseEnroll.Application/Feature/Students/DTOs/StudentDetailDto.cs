using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseEnroll.Application.Feature.Students.DTOs
{
    public class StudentDetailDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}