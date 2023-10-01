using Kalkulator.Enums;

namespace Kalkulator.Models.Services;

public class KalkulatorService : IKalkulatorService
{
    public int Calculate(int firstNumber, int secondNumber, TypeOfEquation typeOfEquation)
    {
        return typeOfEquation switch
        {
            TypeOfEquation.Addition => firstNumber + secondNumber,
            TypeOfEquation.Subtraction => firstNumber - secondNumber,
            TypeOfEquation.Multiplication => firstNumber * secondNumber,
            TypeOfEquation.Division => firstNumber / secondNumber,
            _ => throw new ArgumentOutOfRangeException(nameof(typeOfEquation), typeOfEquation, null)
        };
    }
}