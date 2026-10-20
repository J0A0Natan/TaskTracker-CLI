using System.Text.Json;
using TaskTracker.Repository;

var path = "tasks.json";
var options = new JsonSerializerOptions{ WriteIndented = true };

var tasks = new List<TaskTracker.Models.Task>();
var lastId = 0;

if (File.Exists(path))
{
    string tasksJson = File.ReadAllText(path);
    tasks = JsonSerializer.Deserialize<List<TaskTracker.Models.Task>>(tasksJson, options);
    lastId = tasks.Last().Id;
}

Console.WriteLine("--- Task Tracker ---");
Console.WriteLine("Add");
Console.WriteLine("Update");
Console.WriteLine("Delete");
Console.WriteLine("Mark");
Console.WriteLine("List");

while (true)
{
    string? comand = Console.ReadLine();

    string c = comand.ToLower().Split()[0];

    if (c == "add")
    {
        int taskId = TaskRepository.AddTask(path, lastId, comand.Split()[1], tasks, options);
        Console.WriteLine($"Task added successfully (ID: {taskId})");
    }
    else if (c == "update")
    {

    }
    else if (c == "delete")
    {

    }
    else if (c == "mark")
    {

    }
    else if (c == "list")
    {

    }
    else
    {
        Console.WriteLine("Invalid command, try again.");
    }
}
