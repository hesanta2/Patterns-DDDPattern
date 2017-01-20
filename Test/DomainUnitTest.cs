using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Models.Cars;
using System.Drawing;
using Domain;

namespace Test
{
    [TestClass]
    public class DomainUnitTest
    {
        private Car car;

        [TestInitialize]
        public void Setup()
        {
            this.car = new Car("1", CarClass.Normal, "Car", Color.White, 200, 5);
        }

        [TestMethod, TestCategory("Unit")]
        public void CarAggregate_Id_Is_Not_Null()
        {
            Assert.IsNotNull(car.Id);
        }

        [TestMethod, TestCategory("Unit")]
        public void CarAggregate_Is_Typeof_AggregateRoot()
        {
            Assert.IsInstanceOfType(car, typeof(IAggregateRoot));
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarAggregate_Name_Is_Null_ThrowsException()
        {
            Car nullNameCar = new Car("1", CarClass.Normal, null, Color.Gray, 240, 5);
            Assert.IsNotNull(nullNameCar);
        }

        [TestMethod, TestCategory("Unit")]
        public void CarAggregate_CarType_Is_Typeof_ValueObject()
        {
            Assert.IsInstanceOfType(car.CarType, typeof(ValueObject<CarType>));
        }
    }
}
