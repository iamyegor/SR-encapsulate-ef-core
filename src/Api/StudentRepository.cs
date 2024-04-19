using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulation.Api;

public class StudentRepository
{
    private readonly SchoolContext _context;

    public StudentRepository(SchoolContext context)
    {
        _context = context;
    }

    public Student GetById(long id)
    {
        return _context
            .Students.Include(x => x.Enrollments)
            .ThenInclude(x => x.Course)
            .Include(x => x.SportsEnrollments)
            .ThenInclude(x => x.Sports)
            .SingleOrDefault(x => x.Id == id);
    }
}
