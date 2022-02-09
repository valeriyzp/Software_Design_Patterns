using System;

namespace PP_Lab2.Patterns
{
    class Mechanic
    {
        public Mechanic() { ;}

        public void RepairCar()
        {
            Console.WriteLine("Mechanic fixed a malfunction in a car");
        }
    }

    class Painter
    {
        public Painter() {; }

        public void PaintCar()
        {
            Console.WriteLine("Painter primed and painted the car");
        }
    }

    public class ServiceStation
    {
        private Mechanic _Mechanic { get; set; }
        private Painter _Painter { get; set; }

        public ServiceStation()
        {
            _Mechanic = new Mechanic();
            _Painter = new Painter();
        }

        public void ServiceCar()
        {
            Console.WriteLine("Service work:");
            _Mechanic.RepairCar();
            _Painter.PaintCar();
        }
    }
}
