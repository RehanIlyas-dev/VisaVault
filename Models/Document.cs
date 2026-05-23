using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string DocumentNo { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int TypeID { get; set; }
        public int ClientId { get; set; }

        public Document(int DocumentId, string DocumentNo, DateTime IssueDate, DateTime ExpiryDate, int TypeID, int ClientId)
        {
            this.DocumentId = DocumentId;
            this.DocumentNo = DocumentNo;
            this.IssueDate = IssueDate;
            this.ExpiryDate = ExpiryDate;
            this.TypeID = TypeID;
            this.ClientId = ClientId;
        }
    }
   
}
