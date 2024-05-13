using System.ComponentModel.DataAnnotations;
public class Coordinator
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Phone Number is required")]
    public int PhoneNumber { get; set; }

    [Required(ErrorMessage = "Mail is required")]
    public string Mail { get; set; }

    public List<Package>? Packages { get; set; } = [];


    public Coordinator()
    {
        Id = Guid.NewGuid();
    }
}
