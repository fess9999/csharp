using System;

namespace Classes
{
    public abstract class Car
    {
        public readonly Brand brand;
        private int currentSpeed;
        private bool engineStarted;
        protected int axisCount = 2;
        private Radio radio = new Radio();

        static Car()
        {
            RussiaSpeedLimit = 91;
        }

        protected Car()
        {
            engineStarted = true;
        }

        protected Car(Brand brand) : this()
        {
            this.brand = brand;
        }

        public void TuneRadio(double frequency)
        {
            if (!radio.Enabled) radio.Enabled = true;
            radio.Frequency = frequency;
        }

        public static int RussiaSpeedLimit { get; } = 90;

        protected Car(Brand brand, int speed) : this(brand)
        {
            Speed = speed;
        }

        public void PrintState()
        {
            Console.WriteLine($"Engine started {engineStarted}, {brand} is going {Speed} kmh");
        }

        public abstract int MaxSpeed { get; }

        public int Speed
        {
            get { return currentSpeed; }
            set { currentSpeed = value > MaxSpeed ? MaxSpeed : value; }
        }

        public virtual void SpeedUp()
        {
            Speed+=10;
        }

        public enum Brand
        {
            BMW,
            Honda,
            Toyota,
            Lada,
            MercedesBenz
        }
    }
}