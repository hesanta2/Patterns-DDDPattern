﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Cars;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CarAggregateUnitTest
    {
        private Car car;

        [TestInitialize]
        public void Setup()
        {
            this.car = new Car(1, CarClass.Normal, "Car", 200, 5);
        }

        [TestMethod]
        public void CarAggregate_Id_Is_Not_Null()
        {
            Assert.IsNotNull(car.Id);
        }

        [TestMethod]
        public void CarAggregate_Is_Typeof_AggregateRoot()
        {
            Assert.IsInstanceOfType(car, typeof(IAggregateRoot));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarAggregate_Name_Is_Null_ThrowsException()
        {
            Car nullNameCar = new Car(1, CarClass.Normal, null, 240, 5);               
        }

        /*[TestMethod]
        public void CarAggregate_CarType_Is_Typeof_ValueObject()
        {
            Assert.IsInstanceOfType(car.CarType, typeof(ValueObject<CarType>));
        }*/

        [TestMethod]
        public void CarAggregate_ToString_IsNotNull()
        {
            Assert.IsNotNull(car.ToString());
        }
    }
}
