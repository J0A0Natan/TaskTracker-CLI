using System.Text.Json;
using TaskTracker.Repository;

var path = "tasks.json";
var options = new JsonSerializerOptions { WriteIndented = true };

var tasks = new List<TaskTracker.Models.Task>();
var lastId = 0;

if (File.Exists(path))
{
    string tasksJson = File.ReadAllText(path);
    tasks = JsonSerializer.Deserialize<List<TaskTracker.Models.Task>>(tasksJson, options);
    lastId = tasks.Last().Id;
}

while (true)
{
    ShowOptions();
    string? command = Console.ReadLine();
    Console.Clear();

    string firstCmd = command.ToLower().Split()[0];
    var cl = command.Split().Length;

    if (firstCmd == "add" && cl > 1)
    {
        int taskId = TaskRepository.AddTask(path, lastId, GetDesc(command), tasks, options);
        Console.WriteLine($"Task added successfully (ID: {taskId})");
    }
    else if (firstCmd == "update" && cl > 2)
    {
        TaskRepository.UpdateTask(path, tasks, GetId(command), options, desc: GetDesc(command));
        Console.WriteLine($"Task updated successfully (ID: {GetId(command)})");
    }
    else if (firstCmd == "delete" && cl > 1)
    {
        TaskRepository.DeleteTask(path, tasks, options, GetId(command));
        Console.WriteLine($"Task deleted successfully (ID: {GetId(command)})");
    }
    else if ((firstCmd == "mark-in-progress" || firstCmd == "mark-done") && cl > 1)
    {
        var newStatus = firstCmd == "mark-in-progress" ? "in-progress" : "done";
        TaskRepository.UpdateTask(path, tasks, GetId(command), options, status: newStatus);
    }
    else if (firstCmd == "list")
    {
        List<TaskTracker.Models.Task> result;
        result = TaskRepository.ListTasks(cl > 1 ? command.Split()[1] : "", tasks);

        foreach (var task in result)
        {
            Console.WriteLine
            (
                $"\nId: {task.Id}" +
                $"\nDescription: {task.Description}" +
                $"\nStatus: {task.Status}" +
                $"\nCreatedAt: {task.CreatedAt}" +
                $"\nUpdatedAt: {task.UpdateAt}" +
                "\n--------------------------------"
            );
        }
    }
    else if (firstCmd == "exit")
    {
        return;
    }
    else
    {
        Console.WriteLine("Invalid command, try again.");
    }
}

static void ShowOptions()
{
    Console.WriteLine("--------- Task Tracker ---------");
    Console.WriteLine("Add      - Add \"Description\"");
    Console.WriteLine("Update   - Update ID \"Description\"");
    Console.WriteLine("Delete   - Delete ID");
    Console.WriteLine("Mark     - Mark-in-progress/done ID");
    Console.WriteLine("List     - List todo/in-progress/done");
    Console.WriteLine("Exit     - Close the CLI");
    Console.WriteLine("Choose an option: ");
}

static string GetDesc(string command)
{
    var descStart = command.IndexOf('"');
    var descEnd = command.IndexOf('"', descStart + 1);

    var desc = command.Substring(descStart + 1, descEnd - descStart - 1);
    return desc;
}

static int GetId(string command)
{
    return Convert.ToInt32(command.Split()[1]);
}
