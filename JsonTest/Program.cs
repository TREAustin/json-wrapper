using JsonDLL;
using System.Text.Json.Serialization;
using System.Text.Json;

public class TestObject 
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("events")] public List<Event>? Events { get; set; }

    public TestObject(List<Event> events) {
        Id = 0;
        Name = "Test";
        Events = events;
    }

    public void PrintObject()
    {
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Name: " + Name);
        Events.ForEach(x => Console.WriteLine(x.Id));
    }
}

public class Event
{
    [JsonPropertyName("id")] public int Id { get; set; }

    public Event()
    {
        Id = 1;
    }
}

internal class Program
{


    private static void Main(string[] args)
    {
        List<Event> list = new List<Event>();
        Event even = new Event();

        for(int i = 0; i < 10; i++)
        {
            list.Add(even);
        }
        
        TestObject test = new TestObject(list);

        string b = JsonSerializer.Serialize(test);
        Console.WriteLine(b);
        TestObject c = JsonWrapper.FromJSON<TestObject>(b);
        c.PrintObject();
        Console.WriteLine("Hello, World!");
    }
}