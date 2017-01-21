using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Domain.Models;
using Domain.Models.Cars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Services;
using Infraesctructure.Repositories;
using Rhino.Mocks;

namespace Test
{
    [TestClass]
    public class CarServiceUnitTest
    {
        private ICarRepository carRepository;

        [TestInitialize]
        public void Setup()
        {
            this.carRepository = MockRepository.GenerateMock<ICarRepository>();
        }

        [TestMethod]
        public void CarService_Is_IDomainService()
        {
            IDomainService<Car> carService = new CarService(carRepository);

            Assert.IsInstanceOfType(carService, typeof(ICarService));
        }

        [TestMethod]
        public void CarService_Search_By_Name_Returns_Any()
        {
            IQueryable<Car> returns = new List<Car>
            {
                new Car("1", CarClass.Normal, "Car", Color.White, 200, 5),
                new Car("2", CarClass.Normal, "Car2", Color.Red, 200, 5),
                new Car("3", CarClass.Normal, "Car3", Color.Blue, 200, 5)
            }.AsQueryable();

            this.carRepository.Expect(r => r.Get(null)).IgnoreArguments().Return(returns);

            IQueryable<Car> result = new CarService(carRepository).GetByName("Car");

            Assert.IsTrue(result.Any());
            this.carRepository.VerifyAllExpectations();
        }
    }
}
