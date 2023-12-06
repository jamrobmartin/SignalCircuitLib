using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalCircuitLib.Component;
using SignalCircuitLib.Signals;

namespace SignalCircuitLib.Circuit
{
    public class FullAdder
    {
        public InputPin InputA = new InputPin();
        public InputPin InputB = new InputPin();
        public InputPin InputC = new InputPin();

        public OutputPin OutputSum = new OutputPin();
        public OutputPin OutputCarry = new OutputPin();

        public FullAdder()
        {
            //TwoInputXorGate gate1 = new TwoInputXorGate();
            //TwoInputAndGate gate2 = new TwoInputAndGate();
            //TwoInputXorGate gate3 = new TwoInputXorGate();
            //TwoInputAndGate gate4 = new TwoInputAndGate();
            //TwoInputOrGate  gate5 = new TwoInputOrGate();

            //// Outputs
            //gate3.Output.OutputChanged += OutputSum.sigOutputChanged;
            //gate5.Output.OutputChanged += OutputCarry.sigOutputChanged;

            //// Inputs
            //// gate 1
            //InputA.sigInputChanged += gate1.Input1.InputChanged;
            //InputB.sigInputChanged += gate1.Input2.InputChanged;
            //// gate 2
            //InputA.sigInputChanged += gate2.Input1.InputChanged;
            //InputB.sigInputChanged += gate2.Input2.InputChanged;
            //// gate 3
            //gate1.Output.OutputChanged += gate3.Input1.InputChanged;
            //InputC.sigInputChanged += gate3.Input2.InputChanged;
            //// gate 4
            //gate1.Output.OutputChanged += gate4.Input1.InputChanged;
            //InputC.sigInputChanged += gate4.Input2.InputChanged;
            //// gate 5
            //gate2.Output.OutputChanged += gate5.Input1.InputChanged;
            //gate4.Output.OutputChanged += gate5.Input2.InputChanged;

            TwoInputOrGate orGate = new TwoInputOrGate();
            HalfAdder halfAdder1 = new HalfAdder();
            HalfAdder halfAdder2 = new HalfAdder();

            // Half Adder 1
            InputA.sigInputChanged += halfAdder1.InputA.InputChanged;
            InputB.sigInputChanged += halfAdder1.InputB.InputChanged;

            // Half Adder 2
            halfAdder1.OutputSum.OutputChanged += halfAdder2.InputA.InputChanged;
            InputC.sigInputChanged += halfAdder2.InputB.InputChanged;

            // Or
            halfAdder1.OutputCarry.OutputChanged += orGate.Input1.InputChanged;
            halfAdder2.OutputCarry.OutputChanged += orGate.Input2.InputChanged;

            // Sum
            halfAdder2.OutputSum.OutputChanged += OutputSum.sigOutputChanged;

            // Carry
            orGate.Output.OutputChanged += OutputCarry.sigOutputChanged;

        }
    }

    public class FourBitFullAdder
    {
        public InputPin InputA1 = new InputPin();
        public InputPin InputA2 = new InputPin();
        public InputPin InputA3 = new InputPin();
        public InputPin InputA4 = new InputPin();
        public InputPin InputB1 = new InputPin();
        public InputPin InputB2 = new InputPin();
        public InputPin InputB3 = new InputPin();
        public InputPin InputB4 = new InputPin();
        public InputPin InputC = new InputPin();

        public OutputPin OutputSum1 = new OutputPin();
        public OutputPin OutputSum2 = new OutputPin();
        public OutputPin OutputSum3 = new OutputPin();
        public OutputPin OutputSum4 = new OutputPin();
        public OutputPin OutputCarry = new OutputPin();

        public FourBitFullAdder()
        {
            FullAdder FullAdder1 = new FullAdder();
            FullAdder FullAdder2 = new FullAdder();
            FullAdder FullAdder3 = new FullAdder();
            FullAdder FullAdder4 = new FullAdder();

            // Full Adder 1
            InputA1.sigInputChanged += FullAdder1.InputA.InputChanged;
            InputB1.sigInputChanged += FullAdder1.InputB.InputChanged;
            InputC.sigInputChanged += FullAdder1.InputC.InputChanged;
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
