﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();

        T Get(string key, string countryTag);
    }
}
