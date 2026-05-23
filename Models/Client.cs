using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visavault_g43.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string CnicNo { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }

        public Client(int ClientId, string ClientName, string CnicNo, string Email, string ContactNo, string Address, int CountryId, DateTime CreatedAt, DateTime UpdatedAt, string Status)
        {
            this.ClientId = ClientId;
            this.ClientName = ClientName;
            this.CnicNo = CnicNo;
            this.Email = Email;
            this.ContactNo = ContactNo;
            this.Address = Address;
            this.CountryId = CountryId;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.Status = Status;
        }
    }
    
}
