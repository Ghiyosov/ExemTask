namespace Infrastruction.Services;

public interface IProjectService<T>
{
    public List<T> Get();
    public void Add(T project);
    public void Update(T project);
    public void Delete(int id); 
}
