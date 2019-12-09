using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackit.Models
{
    public class MachineOperator
    {
        public int ID { get; set; }
        public int MachineId { get; set; }
        public Machine Machine { get; set; }
        public int MOperatorId { get; set; }
        public MOperator Operator { get; set; }
    }
}
