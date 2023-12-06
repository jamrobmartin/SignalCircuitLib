using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalCircuitLib.Signals;

namespace SignalCircuitLib.Component
{
    public class OneInputNotGate : OneInputLogicGate
    {
        public override void UpdateState()
        {
            Signal sigOutput = !Input.sigInput;
            Output.ChangeOutput(sigOutput);
        }
    }
}
