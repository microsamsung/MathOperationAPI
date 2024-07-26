namespace MathOperationAPI.Services.Interfaces
{
    public interface IOperation
    {
        decimal Execute(decimal firstOperand, decimal secondOperand);
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
