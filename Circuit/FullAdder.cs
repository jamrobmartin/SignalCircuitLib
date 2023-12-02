using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalCircuitLib.Signals;

namespace SignalCircuitLib.Circuit
{
    public class FullAdder
    {
        // Input 1
        protected Signal sigInput1 { get; set; } = Signal.Low;
        public void Input1(object? sender, SignalChangedEventArgs e)
        {
            sigInput1 = e.Signal;
            UpdateState();
        }
        // Input 2
        protected Signal sigInput2 { get; set; } = Signal.Low;
        public void Input2(object? sender, SignalChangedEventArgs e)
        {
            sigInput2 = e.Signal;
            UpdateState();
        }
        // Input 3
        protected Signal sigInput3 { get; set; } = Signal.Low;
        public void Input3(object? sender, SignalChangedEventArgs e)
        {
            sigInput3 = e.Signal;
            UpdateState();
        }

        // Output 1
        public Signal Output1 { get; protected set; } = Signal.Low;
        public event EventHandler<SignalChangedEventArgs> Output1Changed = delegate { };
        public Signal Sum { get { return Output1; } }

        // Output 2
        public Signal Output2 { get; protected set; } = Signal.Low;
        public event EventHandler<SignalChangedEventArgs> Output2Changed = delegate { };
        public Signal Carry { get { return Output2; } }

        private void UpdateState()
        {
            Output1 = (sigInput1 != sigInput2) != sigInput3;
            Output2 = (sigInput1 && sigInput2) || (sigInput1 && sigInput3) || (sigInput2 && sigInput3);

            Output1Changed.Invoke(this, new SignalChangedEventArgs(Output1));
            Output2Changed.Invoke(this, new SignalChangedEventArgs(Output2));
        }
    }
}
