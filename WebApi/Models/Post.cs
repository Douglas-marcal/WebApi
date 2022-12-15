﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models;

[Table("Posts")]
public class Post
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string? Title { get; set; }

    [Required]
    [StringLength(300)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int UserId { get; set; }

    [JsonIgnore]
    public User? User { get; set; }
}
