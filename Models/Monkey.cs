namespace MyMonkeyApp.Models;

/// <summary>
/// Monkey Model
/// </summary>
public class Monkey
{
    public required string Name { get; set; }
    public required string Location { get; set; }
    public required string Details { get; set; }
    public string? AsciiArt { get; set; }
}