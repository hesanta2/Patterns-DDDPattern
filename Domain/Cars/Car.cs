using System;
using System.Drawing;

namespace Domain.Cars
{
    public class Car : IAggregateRoot
    {
        public string Id { get; protected set; }
        public CarType CarType { get; protected set; }

        public Car(CarClass carClass, string name, Color color, int maxSpeed, int doors)
        {
            this.CarType = new CarType(carClass, name, color, maxSpeed, doors);
        }

    }
}