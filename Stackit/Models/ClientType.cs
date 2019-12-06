using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackit.Models
{
    public class ClientType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Client> Clients { get; set; }
    }
}
