﻿
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IEntityService<T> where T: IEntity
    {
        IDataResult<List<T>> GetAll(Func<T,bool> filter = null);
        IDataResult<T> Get(Func<T,bool> filter);
        IResult AddOrEdit(T entity);
        IResult Delete(T entity);
    }
}