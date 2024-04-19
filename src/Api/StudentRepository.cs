namespace EFCoreEncapsulation.Api;

public class StudentRepository : Repository<Student>
{
    public StudentRepository(SchoolContext context)
        : base(context) { }

    public override Student GetById(long id)
    {
        Student student = Context.Students.Find(id);

        if (student == null)
            return null;

        Context.Entry(student).Collection(x => x.Enrollments).Load();
        Context.Entry(student).Collection(x => x.SportsEnrollments).Load();

        return student;
    }

    public override void Save(Student student)
    {
        // Use one of:

        Context.Students.Add(student);
        Context.Students.Update(student);
        Context.Students.Attach(student);
    }
}

public class CourseRepository : Repository<Course>
{
    public CourseRepository(SchoolContext context)
        : base(context) { }
}
