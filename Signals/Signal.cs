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

        public static bool operator ==(Signal a, Signal b)
        {
            return a._value == b._value;
        }

        public static bool operator !=(Signal a, Signal b)
        {
            return a._value != b._value;
        }

        public override string ToString()
        {
            return _value ? "High" : "Low";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Helper methods
        public static Signal GetSignal(byte data, int index)
        {
            if(!((index >= 0) && (index <= 7)))
                throw new ArgumentException("GetSignal(byte,int) called with index: " + index);

            bool bitValue = ((data >> index) & 0b1) > 0;

            if (bitValue)
                return Signal.High;
            else
                return Signal.Low;
        }
    }

    public class Oscillator
    {
        private Signal _signal = Signal.Low;
        private Thread _thread = null;
        private bool _running = false;
        private UInt64 _cycleCount = 0;

        public Oscillator() { }

        public Signal Signal
        {
            get
            {
                return _signal;
            }

            private set
            {
                _signal = value;
                SignalChanged.Invoke(this, new SignalChangedEventArgs(_signal));
            }
        }

        public UInt64 CycleCount
        {
            get { return _cycleCount; }
        }

        public event EventHandler<SignalChangedEventArgs> SignalChanged = delegate { };

        public void Start()
        {
            _cycleCount = 0;
            _running = true;
            _thread = new Thread(ThreadLoop);
            _thread.Start();

        }

        public void Stop()
        {
            _running = false;
        }

        public void Restart()
        {
            _running = false;
            while (_thread.IsAlive)
            {

            }
            Start();
        }

        private void ThreadLoop()
        {
            while(_running)
            {
                Signal = Signal.High;
                Signal = Signal.Low;
                _cycleCount++;
            }
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
