using System;
using System.Text;

namespace FactoryMethodExample
{
    abstract class Transport
    {
        public abstract void Deliver(string cargo);
    }

    class Truck : Transport
    {
        public override void Deliver(string cargo)
        {
            Console.WriteLine("Вантажівка везе \"" + cargo + "\" по дорозі");
        }
    }

    class Ship : Transport
    {
        public override void Deliver(string cargo)
        {
            Console.WriteLine("Корабель везе \"" + cargo + "\" морем");
        }
    }

    class Plane : Transport
    {
        public override void Deliver(string cargo)
        {
            Console.WriteLine("Літак везе \"" + cargo + "\" повітрям");
        }
    }

    abstract class Logistics
    {
        public abstract Transport CreateTransport();

        public void PlanDelivery(string cargo)
        {
            Transport transport = CreateTransport();
            Console.Write(GetType().Name + ": ");
            transport.Deliver(cargo);
        }
    }

    class RoadLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Truck();
        }
    }

    class SeaLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Ship();
        }
    }

    class AirLogistics : Logistics
    {
        public override Transport CreateTransport()
        {
            return new Plane();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Logistics logistics = new RoadLogistics();
            logistics.PlanDelivery("меблі");

            logistics = new SeaLogistics();
            logistics.PlanDelivery("контейнери");

            logistics = new AirLogistics();
            logistics.PlanDelivery("ліки");

            Console.ReadKey();
        }
    }
}