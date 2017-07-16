using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Cars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CarServiceUnitTest
    {
        private ICarRepository carRepository;
        private IQueryable<Car> repositoryReturns;

        [TestInitialize]
        public void Setup()
        {
            this.carRepository = MockRepository.GenerateMock<ICarRepository>();
            repositoryReturns = new List<Car>
            {
                new Car(1, CarClass.Normal, "Car", 200, 5),
                new Car(2, CarClass.Normal, "Car2", 200, 5),
                new Car(3, CarClass.Normal, "Car3", 200, 5)
            }.AsQueryable();
        }

        [TestMethod]
        public void CarService_Is_IDomainService()
        {
            IDomainService<Car> carService = new CarService(carRepository);

            Assert.IsInstanceOfType(carService, typeof(ICarService));
        }

        [TestMethod]
        public void CarService_GetByName_Returns_Any()
        {
            this.carRepository.Expect(r => r.Get(null)).IgnoreArguments().Return(repositoryReturns);

            IQueryable<Car> result = new CarService(carRepository).GetByName("Car");

            Assert.IsTrue(result.Any());
            this.carRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void CarService_GetAll_Returns_Any()
        {
            this.carRepository.Expect(r => r.GetAll()).Return(repositoryReturns);

            IQueryable<Car> result = new CarService(carRepository).GetAll();

            Assert.IsTrue(result.Any());
            this.carRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void CarService_Insert_Ok()
        {
            this.carRepository.Expect(r => r.Insert(null)).IgnoreArguments();

            new CarService(carRepository).Insert
            (
                new Car(4, CarClass.Normal, "Car4", 200, 5)
            );

            this.carRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void CarService_Delete_Ok()
        {
            this.carRepository.Expect(r => r.Delete(null)).IgnoreArguments();
            this.carRepository.Expect(r => r.Find(null)).IgnoreArguments()
                .Return(new Car(3, CarClass.Normal, "Car3", 200, 5));

            new CarService(carRepository).Delete("3");

            this.carRepository.VerifyAllExpectations();
        }

    }
}
