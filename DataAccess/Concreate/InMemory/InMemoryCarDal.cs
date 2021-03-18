using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concreate.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 5, DailyPrice = 200, Description = "ddjfs", ModelYear = DateTime.Now, Name = "araba1"},
                new Car{Id = 2, BrandId = 3, ColorId = 1, DailyPrice = 200, Description = "djfds", ModelYear = DateTime.Now, Name = "araba2"},
                new Car{Id = 3, BrandId = 3, ColorId = 4, DailyPrice = 200, Description = "djrfs", ModelYear = DateTime.Now, Name = "araba3"},
                new Car{Id = 4, BrandId = 1, ColorId = 4, DailyPrice = 200, Description = "djhfs", ModelYear = DateTime.Now, Name = "araba4"},
                new Car{Id = 5, BrandId = 2, ColorId = 2, DailyPrice = 200, Description = "djffs", ModelYear = DateTime.Now, Name = "araba5"},
                new Car{Id = 6, BrandId = 1, ColorId = 1, DailyPrice = 200, Description = "djhhfds", ModelYear = DateTime.Now, Name = "araba6"},
                new Car{Id = 7, BrandId = 2, ColorId = 3, DailyPrice = 200, Description = "djfas", ModelYear = DateTime.Now, Name = "araba7"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Name = car.Name;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
