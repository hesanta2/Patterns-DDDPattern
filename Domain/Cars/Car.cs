using System;
using System.Drawing;

namespace Domain.Cars
{
    public class Car : IAggregateRoot
    {
        public string Id { get; protected set; }
        public CarType CarType { get; protected set; }

        public Car(string id, CarClass carClass, string name, int maxSpeed, int doors)
        {
            this.Id = id;
            this.CarType = new CarType(carClass, name, maxSpeed, doors);
        }

        public override string ToString()
        {
            return $"{this.CarType.Name}: [Class]{CarType.Class}, [Doors]{CarType.Doors}, [MaxVelocity]{CarType.MaxSpeed}";
        }

    }
}