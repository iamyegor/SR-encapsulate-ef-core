using Microsoft.AspNetCore.Mvc;

namespace EFCoreEncapsulation.Api;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly StudentRepository _repository;

    public StudentController(StudentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public StudentDto Get(long id)
    {
        Student student = _repository.GetById(id);

        return new StudentDto
        {
            StudentId = student.Id,
            Name = student.Name,
            Email = student.Email
        };
    }
}
