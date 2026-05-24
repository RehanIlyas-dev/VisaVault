using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public ValidationResult(bool IsValid, string Message)
        {
            this.IsValid = IsValid;
            this.Message = Message;
        }
        // Static factory methods for success and failure results
        public static ValidationResult Success(string message = "") 
        {
            return new ValidationResult(true, message);
        }

        public static ValidationResult Failure(string message)
        {
            return new ValidationResult(false, message);
        }
    } 
}
