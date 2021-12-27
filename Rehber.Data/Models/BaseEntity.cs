using System.ComponentModel.DataAnnotations;

namespace Rehber.Infrastructure.Models;

public class BaseEntity
{
    [Key]
    public Guid UUID { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now.ToUniversalTime();
}