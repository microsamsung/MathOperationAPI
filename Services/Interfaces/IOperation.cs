namespace MathOperationAPI.Services.Interfaces
{
    public interface IOperation
    {
        decimal Execute(decimal firstOperand, decimal secondOperand);
    }
}
