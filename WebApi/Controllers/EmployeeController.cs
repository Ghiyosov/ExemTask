using Domein.Models;
using Infrastruction.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Properties;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase

{
    readonly EmployeesService _employee;


    [HttpGet("get-list-of-employee")]
    public List<Employees> GetEmployees()
    {
        return _employee.Get();
    }

    [HttpPost("add-employee")]
    public void AddEmployee(Employees employees)
    {
        _employee.Add(employees);
    }
    [HttpPut("udaete-employee")]
    public void UpdateEmployee(Employees employees)
    {
        _employee.Update(employees);
    }
    [HttpDelete("delete-employee")]
    public void DeleteEmployee(int id)
    {
        _employee.Delete(id);
    }
    [HttpGet("task1-get-employee-task")]
    public List<Tasks> GetEmployeesTask(int id)
    {
       return _employee.GetTaskByEmployee(id);
    }
    [HttpGet("2-task")]
    public List<str>
}
