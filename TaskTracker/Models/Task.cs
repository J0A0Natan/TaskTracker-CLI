namespace TaskTracker.Models;

internal class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }

    public Task(int id, string? description, string? status, DateTime createdAt)
    {
        Id = id;
        Description = description;
        Status = status;
        CreatedAt = createdAt;
    }
}
