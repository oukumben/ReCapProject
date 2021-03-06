﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.DataAccess
{
    public interface IEntityRepo<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Func<T,bool> filter = null);
        T Get(Func<T, bool> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Func<T, bool> filter);

    }
}
