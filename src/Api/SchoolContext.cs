using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulation.Api;

public sealed class SchoolContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options) { }

    // Use one of these loggers basedo on the current environment
    private static ILoggerFactory CreateLoggerFactory()
    {
        return LoggerFactory.Create(builder =>
            builder
                .AddFilter(
                    (category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information
                )
                .AddConsole()
        );
    }
    
    private static ILoggerFactory CreateEmptyLoggerFactory()
    {
        return LoggerFactory.Create(builder => builder.AddFilter((_, _) => false));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(x =>
        {
            x.ToTable("Student").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("StudentID");
            x.Property(p => p.Email);
            x.Property(p => p.Name);
            x.HasMany(p => p.Enrollments).WithOne(p => p.Student);
        });
        modelBuilder.Entity<Course>(x =>
        {
            x.ToTable("Course").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("CourseID");
            x.Property(p => p.Name);
        });
        modelBuilder.Entity<Enrollment>(x =>
        {
            x.ToTable("Enrollment").HasKey(k => k.Id);
            x.Property(p => p.Id).HasColumnName("EnrollmentID");
            x.HasOne(p => p.Student).WithMany(p => p.Enrollments);
            x.HasOne(p => p.Course).WithMany();
            x.Property(p => p.Grade);
        });
    }
}
