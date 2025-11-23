using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseEnroll.Application.Feature.Students.DTOs;
using CourseEnroll.Application.Feature.Students.Interfaces;
using CourseEnroll.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CourseEnroll.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentSvc;
        public StudentController(IStudentService studentSvc)
        {
            _studentSvc = studentSvc;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var res = await _studentSvc.GetStudentsAsync(ct);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken ct)
        {
            var res = await _studentSvc.GetStudentProfileAsync(id, ct);
            if (res == null) return NotFound("Student could not be found");
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateDto request, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest();

            var res = await _studentSvc.RegisterStudentAsync(request, ct);
            return CreatedAtAction(nameof(GetById), new { id = res }, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] StudentUpdateDto request, CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest();

            var exist = await _studentSvc.UpdateStudentAsync(id, request, ct);
            if (!exist) return NotFound("Student could not be found");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ct)
        {
            var exist = await _studentSvc.DeleteStudentAsync(id, ct);
            if (!exist) return NotFound("Student could not be found");
            return NoContent();
        }
    }
}