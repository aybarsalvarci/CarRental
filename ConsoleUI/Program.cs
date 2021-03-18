using Business.Concreate;
using DataAccess.Concreate.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarId + "/" + item.CarName + "/" + item.BrandName + "/" + item.ColorName + "/" + item.DailyPrice);
            }
        }
    }
}
