using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalCircuitLib.Signals
{
    interface ReadablePin
    {
        public Signal Read();
    }

    interface WriteablePin
    {
        public void Write(Signal signal);
        public void WrittenTo(object? sender, SignalChangedEventArgs e);
    }

    public abstract class Pin
    {
        // SignalInput
        protected Signal sigInput { get; set; } = Signal.Low;
        public event EventHandler<SignalChangedEventArgs> InputChanged = delegate { };
        protected void RaiseInputChanged()
        {
            InputChanged.Invoke(this, new SignalChangedEventArgs(sigInput));
        }

        // SignalOutput
        protected Signal sigOutput { get; set; } = Signal.Low;
        public event EventHandler<SignalChangedEventArgs> OutputChanged = delegate { };
        protected void RaiseOutputChanged()
        {
            OutputChanged.Invoke(this, new SignalChangedEventArgs(sigOutput));
        }

    }

    public class InputPin
    {
        // SignalInput
        public Signal sigInput { get; private set; } = Signal.Low;
        protected internal event EventHandler<SignalChangedEventArgs> sigInputChanged = delegate { };
        private void RaiseInputChanged()
        {
            sigInputChanged.Invoke(this, new SignalChangedEventArgs(sigInput));
        }

        public void InputChanged(object? sender, SignalChangedEventArgs e)
        {
            sigInput = e.Signal;
            RaiseInputChanged();
        }

        public void ChangeInput(Signal signal)
        {
            sigInput = signal;
            RaiseInputChanged();
        }
    }

    public class OutputPin
    {
        // SignalOutput
        public Signal sigOutput { get; private set; } = Signal.Low;
        public event EventHandler<SignalChangedEventArgs> OutputChanged = delegate { };
        private void RaiseOutputChanged()
        {
            OutputChanged.Invoke(this, new SignalChangedEventArgs(sigOutput));
        }

        protected internal void sigOutputChanged(object? sender, SignalChangedEventArgs e)
        {
            sigOutput = e.Signal;
            RaiseOutputChanged();
        }

        protected internal void ChangeOutput(Signal signal)
        {
            sigOutput = signal;
            RaiseOutputChanged();
        }

        //public event EventHandler<SignalChangedEventArgs> Write = delegate { };
        //public void ConnectTo(EventHandler<SignalChangedEventArgs> read)
        //{
        //    Write += read;
        //}
    }

    public class InputOutputPin : Pin
    {
        public void Read(object? sender, SignalChangedEventArgs e)
        {
            sigInput = e.Signal;
            RaiseInputChanged();
        }
    }
}
