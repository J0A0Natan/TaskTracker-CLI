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
    string? comand = Console.ReadLine();
    Console.Clear();

    string firstCmd = comand.ToLower().Split()[0];
    var cl = comand.Split().Length;

    if (firstCmd == "add" && cl > 1)
    {
        int taskId = TaskRepository.AddTask(path, lastId, GetDesc(comand), tasks, options);
        Console.WriteLine($"Task added successfully (ID: {taskId})");
    }
    else if (firstCmd == "update" && cl > 2)
    {
        int id = Convert.ToInt32(comand.Split()[1]);

        TaskRepository.UpdateTask(path, tasks, id, GetDesc(comand), options);
        Console.WriteLine($"Task updated successfully (ID: {id})");
    }
    else if (firstCmd == "delete" && cl > 1)
    {

    }
    else if (firstCmd == "mark" && cl > 1)
    {

    }
    else if (firstCmd == "list")
    {
        List<TaskTracker.Models.Task> result;
        if (cl > 1)
            result = TaskRepository.ListTasks(comand.Split()[1], tasks);
        else
            result = TaskRepository.ListTasks("", tasks);

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
    else
    {
        Console.WriteLine("Invalid command, try again.");
    }
}

static void ShowOptions()
{
    Console.WriteLine("--------- Task Tracker ---------");
    Console.WriteLine("Add");
    Console.WriteLine("Update");
    Console.WriteLine("Delete");
    Console.WriteLine("Mark");
    Console.WriteLine("List");
    Console.WriteLine("Choose an option: ");
}

static string GetDesc(string comand)
{
    var descStart = comand.IndexOf('"');
    var descEnd = comand.IndexOf('"', descStart + 1);

    var desc = comand.Substring(descStart + 1, descEnd - descStart - 1);
    return desc;
}
