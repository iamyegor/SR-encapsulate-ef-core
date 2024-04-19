namespace EFCoreEncapsulation.Api;

public abstract class Repository<T> where T: class
{
    protected readonly SchoolContext Context;

    protected Repository(SchoolContext context)
    {
        Context = context;
    }

    public virtual T GetById(long id)
    {
        return Context.Set<T>().Find(id);
    }

    public virtual void Save(T entity)
    {
        Context.Set<T>().Add(entity);
    }
}