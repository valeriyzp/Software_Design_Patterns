using System;

namespace PP_Lab2.Patterns
{
    public interface ICar
    {
        public bool isEngineStarted();
        public void startEngine();
        public void stopEngine();
        public void blinkHeadlights();
    }

    public class Ford : ICar
    {
        private bool isStarted { get; set; } = false;

        public Ford () { ;}

        public bool isEngineStarted()
        {
            return isStarted;
        }

        public void startEngine()
        {
            if (isEngineStarted())
                Console.WriteLine("Ford engine is already started");
            else
            {
                Console.WriteLine("Ford start engine");
                isStarted = true;
            }
        }

        public void stopEngine()
        {
            if (!isEngineStarted())
                Console.WriteLine("Ford engine is already stopped");
            else
            {
                Console.WriteLine("Ford stop engine");
                isStarted = false;
            }
        }

        public void blinkHeadlights()
        {
            Console.WriteLine("Ford blinked headlights");
        }
    }

    public class CarKey
    {
        protected ICar _Car { get; set; }

        public CarKey(ICar car)
        {
            _Car = car;
        }

        public void startEngine()
        {
            Console.Write("Try to start engine: ");
            _Car.startEngine();
        }

        public void stopEngine()
        {
            Console.Write("Try to stop engine: ");
            _Car.stopEngine();
        }
    }

    public class AdvancedCarKey : CarKey
    {
        public AdvancedCarKey(ICar car) : base(car) { ;}

        public void blinkHeadlights()
        {
            Console.Write("Try to blink headlights: ");
            _Car.blinkHeadlights();
        }
    }
}
