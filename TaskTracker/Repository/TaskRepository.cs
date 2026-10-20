using System.Text.Json;

namespace TaskTracker.Repository;

internal class TaskRepository
{
    public static int AddTask(string path, int lastId, string desc, List<Models.Task> tasks, JsonSerializerOptions options)
    {
        lastId++;
        Models.Task task = new(lastId, desc, "todo", DateTime.Now);
        tasks.Add(task);
        string jsonSerialized = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(path, jsonSerialized);

        return(task.Id);
    }

    public static void UpdateTask(string path, List<Models.Task> tasks, int id, string desc, JsonSerializerOptions options)
    {
        var taskToUpdate = tasks.FirstOrDefault(t => t.Id == id);
        if (taskToUpdate != null)
        {
            taskToUpdate.Description = desc;
            taskToUpdate.UpdateAt = DateTime.Now;
        }
        string jsonSerialized = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(path, jsonSerialized);
    }

    public static void MarkTask(string path, List<Models.Task> tasks, JsonSerializerOptions options, Models.Task task)
    {

    }

    public static void DeleteTask(string path, List<Models.Task> tasks, JsonSerializerOptions options, Models.Task task)
    {

    }

    public static List<Models.Task> ListTasks(string command, List<Models.Task> tasks)
    {
        if (command == "done")
            return tasks.Where(t => t.Status == "done").ToList();
        if (command == "todo")
            return tasks.Where(t => t.Status == "todo").ToList();
        if (command == "in-progress")
            return tasks.Where(t => t.Status == "in-progress").ToList();
        else
            return tasks;
    }
}
