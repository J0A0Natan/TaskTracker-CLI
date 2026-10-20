using System.Text.Json;

namespace TaskTracker.Repository;

internal class TaskRepository
{
    public static string AddTask(string path, int lastId, string desc, List<Models.Task> tasks, JsonSerializerOptions options)
    {
        lastId++;
        Models.Task task = new(lastId, desc, "todo", DateTime.Now);
        tasks.Add(task);
        string jsonSerialized = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(path, jsonSerialized);

        return $"Task added successfully (ID: {task.Id})";
    }

    public static string UpdateTask(string path, List<Models.Task> tasks, int taskId, JsonSerializerOptions options, string desc = "", string status = "")
    {
        var taskToUpdate = tasks.FirstOrDefault(t => t.Id == taskId);
        if (taskToUpdate != null)
        {
            if (desc != "") taskToUpdate.Description = desc;
            if (status != "") taskToUpdate.Status = status;
            taskToUpdate.UpdateAt = DateTime.Now;

            string jsonSerialized = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(path, jsonSerialized);

            return $"Task updated successfully (ID: {taskId})";
        }
        else
        {
            return $"Task not found (ID: {taskId})";
        }
    }

    public static string DeleteTask(string path, List<Models.Task> tasks, JsonSerializerOptions options, int taskId)
    {
        var taskToDelete = tasks.FirstOrDefault(t => t.Id == taskId);
        if (taskToDelete != null)
        {
            tasks.Remove(taskToDelete);
            string jsonSerialized = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(path, jsonSerialized);

            return $"Task deleted successfully (ID: {taskId})";
        }
        else
        {
            return $"Task not found (ID: {taskId})";
        }
            
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
