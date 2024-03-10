using Dapper;
using Domein.Models;
using Infrastruction.DataDapper;

namespace Infrastruction.Services;

public class TasksService : IProjectService<Task>
{
    readonly DapperContext _context;
    public TasksService()
    {
        _context = new DapperContext();
    }

    public async void Add(Task project)
    {
        var sql = "insert into tasks(projectid,name,description,assinedto,duedate,status)values(@projectid,@name,@description,@assinedto,@duedate,@status)";
        _context.Connection().ExecuteAsync(sql, project);
    }

    public async void Delete(int id)
    {
        var sql = "delete from tasks as em where em.id=@id";
        _context.Connection().ExecuteAsync(sql, new { Id = id });
    }

    public List<Task> Get()
    {
        var sql = "select * from tasks";
        var res = _context.Connection().Query<Task>(sql).ToList();
        return res;
    }

    public void Update(Task project)
    {
        var sql = "update employee as em set projectid=@projectid,name=@name,description=@description,assinedto=@assinedto,duedate=@duedate,status=@status where em.id=@id";
        _context.Connection().Execute(sql, project);
    }
   

}
