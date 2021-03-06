﻿using Domain.Cars;
using Infraesctructure.Persistence;
using Microsoft.Practices.Unity;

namespace Console
{
    public static class UnityConfigurator
    {
        private static UnityContainer unityContainer = null;

        public static UnityContainer UnityContainer
        {
            get
            {
                if (unityContainer == null) init();
                return unityContainer;
            }
        }

        private static void init()
        {
            unityContainer = new UnityContainer();

            unityContainer.RegisterType<Application.Cars.ICarService, Application.Cars.CarService>();
            unityContainer.RegisterType<ICarService, CarService>();
            unityContainer.RegisterType<ICarRepository, CarMemoryRepository>();
        }
    }
}
