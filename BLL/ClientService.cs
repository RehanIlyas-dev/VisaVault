using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using visavault_g43.Models;

namespace visavault_g43.BLL
{
    public static class ClientService // Replaces SearchFilter class
    {
        public static List<Client> GetClients() // Returns a list of clients
        {
            return new List<Client>();
        }

        public static List<Client> SearchClient(string Keyword, string StatusFilter)
        {
            var clients = GetClients();

            if (!string.IsNullOrWhiteSpace(Keyword))
            {
                var lowerKeyword = Keyword.ToLower();
                clients = clients.Where(c => 
                    (c.ClientName != null && c.ClientName.ToLower().Contains(lowerKeyword)) ||
                    (c.Email != null && c.Email.ToLower().Contains(lowerKeyword)) ||
                    (c.CnicNo != null && c.CnicNo.ToLower().Contains(lowerKeyword)) ||
                    (c.ContactNo != null && c.ContactNo.ToLower().Contains(lowerKeyword))
                ).ToList();
            }

            if (!string.IsNullOrWhiteSpace(StatusFilter) && StatusFilter != "All")
            {
                clients = clients.Where(c => c.Status != null && c.Status.Equals(StatusFilter, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return clients;
        }
    }
}
