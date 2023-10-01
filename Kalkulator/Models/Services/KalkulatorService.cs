using Kalkulator.Enums;
using Kalkulator.Models.Exceptions;

namespace Kalkulator.Models.Services;

public class KalkulatorService : IKalkulatorService
{
    public double Calculate(double firstNumber, double secondNumber, TypeOfEquation typeOfEquation)
    {
        return typeOfEquation switch
        {
            TypeOfEquation.Addition => firstNumber + secondNumber,
            TypeOfEquation.Subtraction => firstNumber - secondNumber,
            TypeOfEquation.Multiplication => firstNumber * secondNumber,
            TypeOfEquation.Division => firstNumber / secondNumber,
            _ => throw new NotImplementedOperationException()
        };
    }
}