using Dapper;
using Domein.Models;
using Infrastruction.DataDapper;

namespace Infrastruction.Services;

public class EmployeesService : IProjectService<Employees>
{
    readonly DapperContext _context;
    public EmployeesService()
    {
        _context = new DapperContext();
    }

    public void Add(Employees project)
    {
        var sql = "insert into employees(name,department)values(@name,@department)";
        _context.Connection().Execute(sql, project);
    }

    public void Delete(int id)
    {
        var sql = "delete from employees as em where em.id=@id";
        _context.Connection().Execute(sql, new { Id = id });
    }

    public List<Employees> Get()
    {
        var sql = "select * from employees";
        var res = _context.Connection().Query<Employees>(sql).ToList();
        return res;
    }

    public void Update(Employees project)
    {
        var sql = "update employees as em set name=@name,departname=@departname where em.id=@id";
        _context.Connection().Execute(sql, project);
    }
     public List<Tasks> GetTaskByEmployee(int id)//task1
    {
        var sql = @"select * 
                    from tasks as t
                    join employees as em on t.assignedto=em.id
                    where em.id=@id";
        var res = _context.Connection().Query<Tasks>(sql, new { Id = id }).ToList();
        return res;
    }
      public List<string> GetProjectsTask()//2-task
    {
        var sql = @"select p.name ||' '|| count(t.id)||' '|| p.satus
                    from tasks as t
                    join projects as p on t.projectid=p.id
                    heving t.status='sacceciful'
                    group by p.id;";
        var res = _context.Connection().Query<string>(sql).ToList();
        return res;
    }
    public List<Employees> GetEmployeesOfProjets(int id)//3-task
    {
        var sql = @"select em.Id as id,em.Name as name,em.Department as department
                    tasks as t
                    join employees as em on t.assigned=emp.id
                    join projects as p on t.projects=@id";
        var res = _context.Connection().Query<Employees>(sql, new { Id = id }).ToList();
        return res;
    }
    
    public List<Tasks> GetTasksProject(int id) //4-task
    {
        var sql = @"select *
                    tasks as t 
                    join projects as p on t.projectid=@id";
        var res = _context.Connection().Query<Tasks>(sql, new { Id = id }).ToList();
        return res;
    }

}
