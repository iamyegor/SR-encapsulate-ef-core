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
        Student student = _context.Students.Find(id);

        if (student == null)
        {
            return null;
        }

        _context.Entry(student).Collection(x => x.Enrollments).Load();
        _context.Entry(student).Collection(x => x.SportsEnrollments).Load();

        return student;
    }
}
