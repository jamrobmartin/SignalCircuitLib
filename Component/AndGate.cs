using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SignalCircuitLib;
using SignalCircuitLib.Signals;

namespace SignalCircuitLib.Component
{
    public class TwoInputAndGate: TwoInputLogicGate
    {
        public override void UpdateState()
        {
            Signal sigOutput = Input1.sigInput && Input2.sigInput;
            Output.ChangeOutput(sigOutput);
        }
    }
}
