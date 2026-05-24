using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }

        public DocumentType()
        {
        }

        public DocumentType(int documentTypeId, string documentTypeName)
        {
            DocumentTypeId = documentTypeId;
            DocumentTypeName = documentTypeName;
        }
    }
}
