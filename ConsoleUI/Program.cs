using Business.Concreate;
using DataAccess.Concreate.EntityFramework;
using Entities.Concreate;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental rental = new Rental {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now
            };

            var result = rentalManager.Add(rental);

            Console.WriteLine(result.Message);

            
        }
    }
}
