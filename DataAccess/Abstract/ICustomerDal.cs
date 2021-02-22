﻿using Core.DataAccess;
using Entities.Concrete;
using Core.Utilities.Results.Abstract;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepo<Customer>
    {
        IDataResult<bool?> CheckRentalsForCustomers(Customer customer);
    }
}