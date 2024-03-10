namespace Domein.Models;

public class Tasks:IProject
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int AssignedTo { get; set; }
    public string Status { get; set; }
}
