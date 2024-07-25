using MathOperationAPI.Model;
using MathOperationAPI.Services.Interfaces;
using System.Collections.Concurrent;

namespace MathOperationAPI.Services.Implementation
{
    public class CalculateServices : ICalculatorService
    {
        private readonly IDictionary<OperationType, IOperation> _operations;
        private readonly object _lock = new object();

        public CalculateServices()
        {
            _operations = new ConcurrentDictionary<OperationType, IOperation>
            {
                [OperationType.Add] = new AddOperation(),
                [OperationType.Subtract] = new SubtractOperation(),
                [OperationType.Multiply] = new MultiplyOperation()
            };
        }

        /// <summary>
        /// PerformOperationAsync
        /// </summary>
        /// <param name="operationType"></param>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Task<decimal> PerformOperationAsync(OperationType operationType, decimal firstOperand, decimal secondOperand)
        {
            return Task.Run(() =>
            {
                lock (_lock) // Lock only during critical section
                {
                    if (_operations.TryGetValue(operationType, out var operation))
                    {
                        return operation.Execute(firstOperand, secondOperand);
                    }

                    throw new InvalidOperationException("Invalid operation type");
                }
            });
        }
    }

    public class AddOperation : IOperation
    {
        public decimal Execute(decimal firstOperand, decimal secondOperand) => firstOperand + secondOperand;
    }

    public class SubtractOperation : IOperation
    {
        public decimal Execute(decimal firstOperand, decimal secondOperand) => firstOperand - secondOperand;
    }

    public class MultiplyOperation : IOperation
    {
        public decimal Execute(decimal firstOperand, decimal secondOperand) => firstOperand * secondOperand;
    }
}
