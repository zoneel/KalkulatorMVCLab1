using Kalkulator.Enums;

namespace Kalkulator.Models.Services;

public interface IKalkulatorService
{
    public int Calculate(int firstNumber, int secondNumber, TypeOfEquation typeOfEquation);
}