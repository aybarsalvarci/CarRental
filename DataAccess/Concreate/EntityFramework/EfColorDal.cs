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
    public class EfColorDal : IColorDal
    {
        public void Add(Color Entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var EntityToAdd = context.Entry(Entity);
                EntityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color Entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var EntityToDelete = context.Entry(Entity);
                EntityToDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color Entity)
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
