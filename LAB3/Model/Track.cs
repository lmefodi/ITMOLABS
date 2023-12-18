using System.ComponentModel.DataAnnotations;

namespace LizaLab3.Model;

public class Track
{
    [Key]
    public int Id { get; set; }
    public string Author { get; set; }
    public string Name { get; set; }
}
