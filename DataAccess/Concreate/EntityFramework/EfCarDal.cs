using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car Entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var EntityToAdd = context.Entry(Entity);
                EntityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car Entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var EntityToDelete = context.Entry(Entity);
                EntityToDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car Entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var EntityToUpdate = context.Entry(Entity);
                EntityToUpdate.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
