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
            var result = carManager.GetAll();
            Console.WriteLine(result.Message);
            Console.WriteLine(result.Success);
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
