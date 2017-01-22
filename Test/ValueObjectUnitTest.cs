using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Cars;

namespace Test
{
    [TestClass]
    public class ValueObjectUnitTest
    {
        private Car car;
        private Car carCopy;
        private Car car2;

        [TestInitialize]
        public void Setup()
        {
            this.car = new Car("1", CarClass.Normal, "Car", 200, 5);
            this.carCopy = new Car("1", CarClass.Normal, "Car", 200, 5);
            this.car2 = new Car("2", CarClass.Normal, "Car2", 200, 5);
        }

        [TestMethod]
        public void ValueObject_Equals_Is_True()
        {
            Assert.IsTrue(car.CarType.Equals(carCopy.CarType));
        }

        [TestMethod]
        public void ValueObject_Equals_Null_Is_False()
        {
            Assert.IsFalse(car.CarType.Equals(null));
        }

        [TestMethod]
        public void ValueObject_Equal_Operator_Is_True()
        {
            Car carObject = car;

            Assert.IsTrue(car.CarType == carObject.CarType);
        }

        [TestMethod]
        public void ValueObject_Equal_Operator_First_Is_Null_Is_False()
        {
            Assert.IsFalse(null == car.CarType);
        }

        [TestMethod]
        public void ValueObject_Equal_Operator_Second_Is_Null_Is_False()
        {
            Assert.IsFalse(car.CarType == null);
        }

        [TestMethod]
        public void ValueObject_Equal_Operator_Frist_And_Second_Is_Null_Is_True()
        {
            CarType carType1 = null;
            CarType carType2 = null;

            Assert.IsTrue(carType1 == carType2);
        }

        [TestMethod]
        public void ValueObject_Inequal_Operator_Is_True()
        {
            Assert.IsTrue(car.CarType != car2.CarType);
        }

        [TestMethod]
        public void ValueObject_GetHasCode_Is_GreatherThanZero()
        {
            Assert.IsTrue(car.CarType.GetHashCode() > 0);
            //Test cached hashCode Value
            Assert.IsTrue(car.CarType.GetHashCode() > 0);
        }

    }
}
