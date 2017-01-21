using System;
using System.Drawing;

namespace Domain.Cars
{
    public class CarType : ValueObject<CarType>
    {
        public CarClass Class { get; protected set; }
        public string Name { get; protected set; }
        public Color Color { get; protected set; }
        public int MaxSpeed { get; protected set; }
        public int Doors { get; protected set; }

        public CarType(CarClass carClass, String name, Color color, int maxSpeed, int doors)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");

            this.Class = carClass;
            this.Name = name;
            this.Color = Color;
            this.MaxSpeed = maxSpeed;
            this.Doors = doors;
        }

        protected override bool EqualsCore(CarType other)
        {
            return this.Class == other.Class
                    && this.Name == other.Name
                    && this.Color == other.Color
                    && this.MaxSpeed == other.MaxSpeed
                    && this.Doors == other.Doors;
        }

        protected override int GetHashCodeCore()
        {
            return Class.GetHashCode()
                    ^ Name.GetHashCode()
                    ^ Color.GetHashCode()
                    ^ MaxSpeed.GetHashCode()
                    ^ Doors.GetHashCode();
        }
    }
}