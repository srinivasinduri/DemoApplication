using DemoApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp.Repository
{
    public class GenericRepository<T> where T:class
    {
        protected MyDemoDbContext context;

        protected DbSet<T> ds;
        public GenericRepository(DbContext db,bool isMoc=false)
        {
            context =(MyDemoDbContext)db;
            ds = context.Set<T>();
            if (!isMoc)
            {
                context.ChangeTracker.LazyLoadingEnabled = false;
            }
        }
        public void Add(T entity)
        {
            ds.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = ds.Find(id);
            ds.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return ds.ToList();
        }

        public T GetById(int id)
        {
            return ds.Find(id);
        }
        public T GetById(int id, string str = "")
        {
            return ds.Find(id);
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
