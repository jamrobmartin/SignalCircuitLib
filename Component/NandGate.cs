using SignalCircuitLib.Signals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalCircuitLib.Component
{
    public class TwoInputNandGate : TwoInputLogicGate
    {
        public override void UpdateState()
        {
            Signal sigOutput = !(Input1.sigInput && Input2.sigInput);
            Output.ChangeOutput(sigOutput);
        }
    }
}
