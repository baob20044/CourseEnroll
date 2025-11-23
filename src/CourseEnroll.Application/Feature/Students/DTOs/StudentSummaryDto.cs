using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseEnroll.Application.Feature.Students.DTOs
{
    public class StudentSummaryDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
    }
}