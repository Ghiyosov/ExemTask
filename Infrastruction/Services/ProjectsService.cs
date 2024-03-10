using Dapper;
using Domein.Models;
using Infrastruction.DataDapper;

namespace Infrastruction.Services;

public class ProjectsService : IProjectService<Projects>
{
    readonly DapperContext _context;
    public ProjectsService()
    {
        _context = new DapperContext();
    }

    public void Add(Projects project)
    {
        var sql = "insert into employees(name,description,startdate,enddate)values(@name,@description,@startdate,@enddate)";
        _context.Connection().Execute(sql, project);
    }

    public void Delete(int id)
    {
        var sql = "delete from projects as em where em.id=@id";
        _context.Connection().Execute(sql, new { Id = id });
    }

    public List<Projects> Get()
    {
        var sql = "select * from projects";
        var res = _context.Connection().Query<Projects>(sql).ToList();
        return res;
    }

    public void Update(Projects project)
    {
        var sql = "update employee as em set name=@name,description=@description,startdate=@startdate,enddate=@enddate where em.id=@id";
        _context.Connection().Execute(sql, project);
    }
  
}
