using JsonTableDemo.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JsonTableDemo.Services;

public class DataService
{
    private readonly IWebHostEnvironment _env;

    public DataService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<List<Person>> GetPeopleAsync()
    {
        var filePath = Path.Combine(_env.WebRootPath, "data.json");
        var json = await System.IO.File.ReadAllTextAsync(filePath);
        var people = JsonSerializer.Deserialize<List<Person>>(json);
        return people;
    }
}