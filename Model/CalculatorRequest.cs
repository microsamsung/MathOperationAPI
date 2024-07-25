using System.ComponentModel.DataAnnotations;

namespace MathOperationAPI.Model
{
    public class CalculatorRequest
    {
        [Required]
        [EnumDataType(typeof(OperationType))]
        public OperationType OperationType { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "First operand must be greater than 0.")]
        public decimal FirstOperand { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Second operand must be greater than 0.")]
        public decimal SecondOperand { get; set; }
    }
}
