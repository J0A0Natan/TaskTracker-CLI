using System.Text.Json;

namespace TaskTracker.Repository;

internal class TaskRepository
{
    public static int AddTask(string path, int lastId, string desc, List<Models.Task> tasks, JsonSerializerOptions options)
    {
        lastId++;
        Models.Task task = new(lastId, desc, "in-progress", DateTime.Now);
        tasks.Add(task);
        string jsonSerialized = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(path, jsonSerialized);

        return(task.Id);
    }
}
