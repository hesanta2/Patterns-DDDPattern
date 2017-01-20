using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Cars;
using System.Drawing;
using Domain;

namespace Test
{
    [TestClass]
    public class DomainUnitTests
    {

        [TestMethod, TestCategory("Unit")]
        public void CarAggregate_Is_Typeof_AggregateRoot()
        {
            Car result = new Car(CarClass.Normal, "Car", Color.White, 200, 5);

            Assert.IsInstanceOfType(result, typeof(IAggregateRoot));
        }

        [TestMethod, TestCategory("Unit")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarAggregate_Name_Is_Null_ThrowsException()
        {
            new Car(CarClass.Normal, null, Color.Gray, 240, 5);
        }

        [TestMethod, TestCategory("Unit")]
        public void CarAggregate_CarType_Is_Typeof_ValueObject()
        {
            Car result = new Car(CarClass.Normal, "Car", Color.White, 200, 5);

            Assert.IsInstanceOfType(result.CarType, typeof(ValueObject<CarType>));
        }
    }
}
