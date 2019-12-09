using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackit.Models
{
    public class MOperator
    {
        public int MOperatorId { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public ICollection<MachineOperator> MachineOperators { get; }
    }
}
