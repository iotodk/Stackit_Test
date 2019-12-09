using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackit.Models
{
    public class Machine
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<MachineOperator> MachineOperators { get; }
    }
}
