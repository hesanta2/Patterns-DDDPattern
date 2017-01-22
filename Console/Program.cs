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
            Random random = new Random((int)DateTime.Now.Ticks);
            Application.Cars.ICarService carService =
                UnityConfigurator.UnityContainer.Resolve<ICarService>();

            ConsoleKey consoleKey = ConsoleKey.A;
            while (consoleKey != ConsoleKey.Escape)
            {
                System.Console.Write(@"
- Car Searcher -
    1. Search
    2. Add (random)
    3. Remove
    Esc to exit

  Write number option: ");
                consoleKey = System.Console.ReadKey().Key;
                System.Console.Clear();
                string readerLine = null;
                while (true)
                {
                    IQueryable<Car> cars = null;

                    switch (consoleKey)
                    {
                        case ConsoleKey.D1:
                            System.Console.Write("\nWrite the car name to find (blank to show all, exit to leave): ");
                            readerLine = System.Console.ReadLine();
                            cars = carService.GetByName(readerLine);
                            break;
                        case ConsoleKey.D2:
                            System.Console.Write("\nWrite the car name to create random one (blank to show all, exit to leave): ");
                            readerLine = System.Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(readerLine)
                                && readerLine.ToLower() != "exit")
                                carService.Insert(
                                                    new Car(null,
                                                    (CarClass)random.Next(2),
                                                    readerLine,
                                                    random.Next(150, 370),
                                                    random.Next(0, 5))
                                                );
                            cars = carService.GetByName("");
                            break;
                        case ConsoleKey.D3:
                            System.Console.Write("\nWrite the car Id to remove (blank to show all, exit to leave): ");
                            readerLine = System.Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(readerLine)
                                && readerLine.ToLower() != "exit")
                                carService.Delete(readerLine);
                            cars = carService.GetByName("");
                            break;
                    }

                    if (readerLine == null
                        || readerLine.ToLower() == "exit")
                        break;

                    System.Console.WriteLine();
                    foreach (var car in cars)
                        System.Console.WriteLine($"Car ({car.Id}): {car}");
                    System.Console.WriteLine();

                }

                System.Console.Clear();

            }
        }
    }
}
