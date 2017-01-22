using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Cars;
using Epreselec.Ats.API.Domain;
using Microsoft.Practices.Unity;
using ICarService = Application.Cars.ICarService;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Application.Cars.ICarService carService = 
                UnityConfigurator.UnityContainer.Resolve<ICarService>();

            string readerLine = "";
            while (readerLine.ToLower() != "exit")
            {
                System.Console.Write("\nWrite the car name to find (exit to leave): ");
                readerLine = System.Console.ReadLine();
                System.Console.Clear();

                IQueryable<Car> cars = carService.GetByName(readerLine);

                System.Console.WriteLine();
                foreach (var car in cars)
                {
                    System.Console.WriteLine($"Car ({car.Id}): {car}");
                }
                System.Console.WriteLine();
            }
        }
    }
}
