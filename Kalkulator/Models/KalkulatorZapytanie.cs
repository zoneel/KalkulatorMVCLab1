using Kalkulator.Enums;

namespace Kalkulator.Models;

public class KalkulatorZapytanie
{
    public Guid OperationId { get; set; }
    public double? Number1 { get; set; }
    public double? Number2 { get; set; }
    public TypeOfEquation EquationType { get; set; }
}