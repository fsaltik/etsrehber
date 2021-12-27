using Rehber.Infrastructure.Enums;

namespace Rehber.Infrastructure.Models;

public class ReportQueu :BaseEntity
{
    public TypeEnums.ReportState State { get; set; }
}