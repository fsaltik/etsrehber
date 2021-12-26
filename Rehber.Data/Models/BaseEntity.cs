using System.ComponentModel.DataAnnotations;

namespace Rehber.Infrastructure.Models;

public class BaseEntity
{
    [Key]
    public Guid UUID { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; } = DateTime.Now;
}