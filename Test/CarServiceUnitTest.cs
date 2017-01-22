using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Cars;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                new Car("1", CarClass.Normal, "Car", 200, 5),
                new Car("2", CarClass.Normal, "Car2", 200, 5),
                new Car("3", CarClass.Normal, "Car3", 200, 5)
            }.AsQueryable();

            this.carRepository.Expect(r => r.Get(null)).Return(returns);

            IQueryable<Car> result = new CarService(carRepository).GetByName(null);

            Assert.IsTrue(result.Any());
            this.carRepository.VerifyAllExpectations();
        }
    }
}
