using Kalkulator.Enums;

namespace Kalkulator.Models.Services;

public interface IKalkulatorService
{
    public double Calculate(double firstNumber, double secondNumber, TypeOfEquation typeOfEquation);
}