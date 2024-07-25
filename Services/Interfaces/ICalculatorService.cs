using MathOperationAPI.Model;

namespace MathOperationAPI.Services.Interfaces
{
    public interface ICalculatorService
    {
        Task<decimal> PerformOperationAsync(OperationType operationType, decimal firstOperand, decimal secondOperand);
    }
}
