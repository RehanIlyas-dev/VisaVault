using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class DocumentDependency
    {
        public int DependencyId { get; set; }
        public int DocumentTypeId { get; set; }
        public int RequiredDocumentTypeId { get; set; }

        public DocumentDependency(int DependencyId, int DocumentTypeId, int RequiredDocumentTypeId)
        {
            this.DependencyId = DependencyId;
            this.DocumentTypeId = DocumentTypeId;
            this.RequiredDocumentTypeId = RequiredDocumentTypeId;
        }
    }
   
    }
