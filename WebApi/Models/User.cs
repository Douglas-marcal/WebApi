using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

[Table("Users")]
public class User
{
    public User()
    {
        Posts = new Collection<Post>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string? Name { get; set; }

    [Required]
    [StringLength(80)]
    public string? Email { get; set; }

    [Required]
    [StringLength(80)]
    public string? Password { get; set; }

    public ICollection<Post>? Posts { get; set; }
}
