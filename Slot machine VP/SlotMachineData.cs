using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_machine_VP
{
    [Serializable]
    public class SlotMachineData
    {
        public long Credits { get; set; }
        public long Total { get; set; }
        public int Bet { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }
        public int P4 { get; set; }
        public int P5 { get; set; }
        public int P6 { get; set; }
        public int P7 { get; set; }
        public int P8 { get; set; }
        public int P9 { get; set; }
    }

}
