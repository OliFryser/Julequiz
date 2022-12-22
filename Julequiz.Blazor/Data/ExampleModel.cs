using System.ComponentModel.DataAnnotations;

public class ExampleModel
{
    [Required]
    [MaxLength(20)]
    public string? Name {get; set;}
}