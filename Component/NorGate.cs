using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalCircuitLib.Component
{
    public class TwoInputNorGate : TwoInputLogicGate
    {
        public override void UpdateState()
        {
            Output = !(sigInput1 || sigInput2);
            base.UpdateState();
        }
    }
}
