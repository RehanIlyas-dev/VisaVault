using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class DependencyCheckResult
    {
        public string RequiredDocumentType { get; set; }
        public bool Exists { get; set; }
        public bool IsValid { get; set; }
        public string Status { get; set; } // "OK", "Missing", "Expired"

        public DependencyCheckResult(string requiredDocumentType, bool exists, bool isValid, string status)
        {
            RequiredDocumentType = requiredDocumentType;
            Exists = exists;
            IsValid = isValid;
            Status = status;
        }
    }
}
