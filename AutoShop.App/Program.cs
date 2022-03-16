using System;
using AutoShop.Models;
using AutoShop.Repositories;

namespace AutoShop.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Car auto = new Car() {ModelID = 3, ABS = true,PowerWindows=true,Bluetooth=true,Signalling=true, NavigationSystem=true, Price=27.50};
            Car auto1 = new Car() { ID=2,ModelID = 3,ABS=true, PowerWindows = true, Bluetooth = true, Signalling = true, NavigationSystem = true, Price = 27.50 };
            Console.WriteLine("Hello World!");
            CarRepository carRepository = new CarRepository();
            carRepository.Insert(auto);
            //carRepository.Delete(4);
            //carRepository.Update(auto4);
        }
    }
}
