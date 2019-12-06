using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackit.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        //ClientTypeId => tillader os at referere til ClientType
        public int ClientTypeId { get; set; }
        //reference til ClientType => nødvendigt for at referere til CLientType => navigation property
        public ClientType Type { get; set; }
    }
}
