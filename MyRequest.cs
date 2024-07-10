namespace PocApi;

public class MyRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IFormFile File { get; set; }
}
