using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalCircuitLib.Component;
using SignalCircuitLib.Signals;

namespace SignalCircuitLib.Circuit
{
    public class HalfAdder
    {
        public InputPin InputA = new InputPin();
        public InputPin InputB = new InputPin();

        public OutputPin OutputSum = new OutputPin();
        public OutputPin OutputCarry = new OutputPin();

        public HalfAdder() 
        {
            TwoInputXorGate gate1 = new TwoInputXorGate();
            TwoInputAndGate gate2 = new TwoInputAndGate();

            InputA.sigInputChanged += gate1.Input1.InputChanged;
            InputB.sigInputChanged += gate1.Input2.InputChanged;
            gate1.Output.OutputChanged += OutputSum.sigOutputChanged;

            InputA.sigInputChanged += gate2.Input1.InputChanged;
            InputB.sigInputChanged += gate2.Input2.InputChanged;
            gate2.Output.OutputChanged += OutputCarry.sigOutputChanged;
        }
    }

    public class FourBitHalfAdder
    {
        public InputPin InputA1 = new InputPin();
        public InputPin InputA2 = new InputPin();
        public InputPin InputA3 = new InputPin();
        public InputPin InputA4 = new InputPin();
        public InputPin InputB1 = new InputPin();
        public InputPin InputB2 = new InputPin();
        public InputPin InputB3 = new InputPin();
        public InputPin InputB4 = new InputPin();

        public OutputPin OutputSum1 = new OutputPin();
        public OutputPin OutputSum2 = new OutputPin();
        public OutputPin OutputSum3 = new OutputPin();
        public OutputPin OutputSum4 = new OutputPin();
        public OutputPin OutputCarry = new OutputPin();

        public FourBitHalfAdder()
        {
            FullAdder FullAdder1 = new FullAdder();
            FullAdder FullAdder2 = new FullAdder();
            FullAdder FullAdder3 = new FullAdder();
            FullAdder FullAdder4 = new FullAdder();

            // Full Adder 1
            InputA1.sigInputChanged += FullAdder1.InputA.InputChanged;
            InputB1.sigInputChanged += FullAdder1.InputB.InputChanged;
            FullAdder1.OutputSum.OutputChanged += OutputSum1.sigOutputChanged;
            FullAdder1.OutputCarry.OutputChanged += FullAdder2.InputC.InputChanged;
            // Full Adder 2
            InputA2.sigInputChanged += FullAdder2.InputA.InputChanged;
            InputB2.sigInputChanged += FullAdder2.InputB.InputChanged;
            FullAdder2.OutputSum.OutputChanged += OutputSum2.sigOutputChanged;
            FullAdder2.OutputCarry.OutputChanged += FullAdder3.InputC.InputChanged;
            // Full Adder 3
            InputA3.sigInputChanged += FullAdder3.InputA.InputChanged;
            InputB3.sigInputChanged += FullAdder3.InputB.InputChanged;
            FullAdder3.OutputSum.OutputChanged += OutputSum3.sigOutputChanged;
            FullAdder3.OutputCarry.OutputChanged += FullAdder4.InputC.InputChanged;
            // Full Adder 4
            InputA4.sigInputChanged += FullAdder4.InputA.InputChanged;
            InputB4.sigInputChanged += FullAdder4.InputB.InputChanged;
            FullAdder4.OutputSum.OutputChanged += OutputSum4.sigOutputChanged;
            FullAdder4.OutputCarry.OutputChanged += OutputCarry.sigOutputChanged;
        }
    }
}
