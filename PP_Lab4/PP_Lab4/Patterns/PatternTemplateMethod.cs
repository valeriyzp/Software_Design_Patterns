using System;

namespace PP_Lab4.Patterns
{
    public abstract class CarMaker
    {
        public CarMaker() { ;}

        public void MakeBody()
        {
            Console.WriteLine("Car body is made");
        }

        public void Paint()
        {
            Console.WriteLine("Car is painted");
        }
        public abstract void StickLogo();
    }

    public class FordCar : CarMaker
    {
        public FordCar() { ;}

        public override void StickLogo()
        {
            Console.WriteLine("Ford logo is stiked");
        }
    }

    public class ZAZCar : CarMaker
    {
        public ZAZCar() {; }

        public override void StickLogo()
        {
            Console.WriteLine("ZAZ logo is stiked");
        }
    }
}
