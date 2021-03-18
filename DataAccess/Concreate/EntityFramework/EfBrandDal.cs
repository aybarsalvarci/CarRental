﻿using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand Entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var EntityToAdd = context.Entry(Entity);
                EntityToAdd.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand Entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var EntityToDelete = context.Entry(Entity);
                EntityToDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<Brand>().ToList() : context.Set<Brand>().Where(filter).ToList();
            }
        }

        public void Update(Brand Entity)
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
