﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Repository
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
