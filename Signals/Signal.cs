namespace SignalCircuitLib.Signals
{
    public class Signal
    {
        public static Signal High = new Signal(true);
        public static Signal Low = new Signal(false);

        private bool _value = false;

        private Signal(bool high)
        {
            _value = high;
        }

        public Signal(Signal signal)
        {
            _value = signal._value;
        }

        public static implicit operator Signal(bool value) { return new Signal(value); }
        public static implicit operator bool(Signal signal) { return signal.Equals(High); }

        protected bool Equals(Signal other)
        {
            return _value == other._value;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Signal)obj);
        }

        public override string ToString()
        {
            return _value ? "High" : "Low";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class SignalGenerator
    {
        private Signal _signal = Signal.Low;

        public SignalGenerator() { }

        public Signal Signal
        {
            get
            {
                return _signal;
            }

            set
            {
                _signal = value;
                SignalChanged.Invoke(this, new SignalChangedEventArgs(_signal));
            }
        }

        public event EventHandler<SignalChangedEventArgs> SignalChanged = delegate { };
    }

    public class SignalReceiver
    {
        private Signal _signal = Signal.Low;

        public SignalReceiver() { }

        public Signal Signal { get { return _signal; } }

        public void Input(object? sender, SignalChangedEventArgs e)
        {
            _signal = e.Signal;
        }


    }

    public class SignalChangedEventArgs : EventArgs
    {
        public Signal Signal { get; set; }

        public SignalChangedEventArgs(Signal signal)
        {
            Signal = signal;
        }
    }
}
