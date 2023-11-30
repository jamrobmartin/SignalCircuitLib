using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalCircuitLib.Component
{
    public abstract class OneInputLogicGate
    {
        // Input 1
        protected Signal sigInput1 { get; set; } = Signal.Low;
        public void Input1(object? sender, SignalChangedEventArgs e)
        {
            sigInput1 = e.Signal;
            UpdateState();
        }

        // Output
        public Signal Output { get; protected set; } = Signal.Low;
        public event EventHandler<SignalChangedEventArgs> OutputChanged = delegate { };

        public virtual void UpdateState()
        {
            OutputChanged.Invoke(this, new SignalChangedEventArgs(Output));
        }

        public sealed override bool Equals(object? obj)
        {
            return obj is OneInputLogicGate gate &&
                   EqualityComparer<Signal>.Default.Equals(sigInput1, gate.sigInput1) &&
                   EqualityComparer<Signal>.Default.Equals(Output, gate.Output);
        }

        public sealed override int GetHashCode()
        {
            return HashCode.Combine(sigInput1, Output);
        }

        public sealed override string? ToString()
        {
            return this.GetType().Name + "-" + 
                "Input1:" + sigInput1.ToString() + 
                ",Output:" + Output.ToString();
        }
    }

    public abstract class TwoInputLogicGate
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

        // Output
        public Signal Output { get; protected set; } = Signal.Low;
        public event EventHandler<SignalChangedEventArgs> OutputChanged = delegate { };

        public virtual void UpdateState()
        {
            OutputChanged.Invoke(this, new SignalChangedEventArgs(Output));
        }

        public sealed override bool Equals(object? obj)
        {
            return obj is TwoInputLogicGate gate &&
                   EqualityComparer<Signal>.Default.Equals(sigInput1, gate.sigInput1) &&
                   EqualityComparer<Signal>.Default.Equals(sigInput2, gate.sigInput2) &&
                   EqualityComparer<Signal>.Default.Equals(Output, gate.Output);
        }

        public sealed override int GetHashCode()
        {
            return HashCode.Combine(sigInput1, sigInput2, Output);
        }

        public sealed override string? ToString()
        {
            return this.GetType().Name + "-" + 
                "Input1:" + sigInput1.ToString() + 
                ",Input2:" + sigInput2.ToString() + 
                ",Output:" + Output.ToString();
        }
    }

    public abstract class ThreeInputLogicGate
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

        // Output
        public Signal Output { get; protected set; } = Signal.Low;
        public event EventHandler<SignalChangedEventArgs> OutputChanged = delegate { };

        public virtual void UpdateState()
        {
            OutputChanged.Invoke(this, new SignalChangedEventArgs(Output));
        }

        public sealed override bool Equals(object? obj)
        {
            return obj is ThreeInputLogicGate gate &&
                   EqualityComparer<Signal>.Default.Equals(sigInput1, gate.sigInput1) &&
                   EqualityComparer<Signal>.Default.Equals(sigInput2, gate.sigInput2) &&
                   EqualityComparer<Signal>.Default.Equals(sigInput3, gate.sigInput3) &&
                   EqualityComparer<Signal>.Default.Equals(Output, gate.Output);
        }

        public sealed override int GetHashCode()
        {
            return HashCode.Combine(sigInput1, sigInput2, sigInput3, Output);
        }

        public sealed override string? ToString()
        {
            return this.GetType().Name + "-" + 
                "Input1:" + sigInput1.ToString() + 
                ",Input2:" + sigInput2.ToString() + 
                ",Output:" + Output.ToString();
        }
    }
}
