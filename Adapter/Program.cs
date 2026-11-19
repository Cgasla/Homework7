using System;
using System.Text;

namespace AdapterExample
{
    interface ITemperatureSensor
    {
        double GetCelsius();
    }

    class CelsiusSensor : ITemperatureSensor
    {
        public double GetCelsius()
        {
            return 21.5;
        }
    }

    class FahrenheitSensor
    {
        public double ReadFahrenheit()
        {
            return 77;
        }
    }

    class FahrenheitSensorAdapter : ITemperatureSensor
    {
        private FahrenheitSensor sensor;

        public FahrenheitSensorAdapter(FahrenheitSensor sensor)
        {
            this.sensor = sensor;
        }

        public double GetCelsius()
        {
            return Math.Round((sensor.ReadFahrenheit() - 32) * 5 / 9, 1);
        }
    }

    class KelvinSensor
    {
        public double ReadKelvin()
        {
            return 300.15;
        }
    }

    class KelvinSensorAdapter : ITemperatureSensor
    {
        private KelvinSensor sensor;

        public KelvinSensorAdapter(KelvinSensor sensor)
        {
            this.sensor = sensor;
        }

        public double GetCelsius()
        {
            return Math.Round(sensor.ReadKelvin() - 273.15, 1);
        }
    }

    class ThermostatDisplay
    {
        public void Show(string name, ITemperatureSensor sensor)
        {
            Console.WriteLine(name + ": " + sensor.GetCelsius() + " °C");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ThermostatDisplay display = new ThermostatDisplay();

            display.Show("Датчик Цельсія", new CelsiusSensor());
            display.Show("Датчик Фаренгейта (через адаптер)",
                         new FahrenheitSensorAdapter(new FahrenheitSensor()));

            display.Show("Датчик Кельвіна (через адаптер)",
                         new KelvinSensorAdapter(new KelvinSensor()));

            Console.ReadKey();
        }
    }
}