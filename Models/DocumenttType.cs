using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class DocumentTypeModel
    {
        public int DocumenttypeId { get; set; }
        public string DocumenttypeName { get; set; }

        public DocumentTypeModel(int DocumenttypeId, string DocumenttypeName)
        {
            this.DocumenttypeId = DocumenttypeId;
            this.DocumenttypeName = DocumenttypeName;
        }
    }
   
    }
