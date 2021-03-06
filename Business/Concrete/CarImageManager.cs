﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _dal;

        public CarImageManager(ICarImageDal dal)
        {
            _dal = dal;
        }


        public IDataResult<List<CarImage>> GetAll(Func<CarImage, bool> filter = null)
        {

            return new SuccessDataResult<List<CarImage>>(Messages.Success, _dal.GetAll(filter));

        }

        public IDataResult<CarImage> Get(Func<CarImage, bool> filter)
        {

            return new SuccessDataResult<CarImage>(Messages.Success, _dal.Get(filter));

        }

        public IDataResult<CarImage> GetById(int id)
        {
            return Get(ci => ci.Id == id);
        }

        public IResult Delete(CarImage entity)
        {

            string path = Get(ci => ci.Id == entity.Id).Data.ImagePath;
            FileHelper.Delete(path);
            _dal.Delete(entity);
            return new SuccessResult(Messages.Deleted);

        }

        public IResult AddOrEdit(IFormFile file, CarImage entity, string type)
        {

            IResult result = BusinessRules.Run(CheckCarImageLimit(entity));
            if (result != null) return result;

            if (entity.Id == 0)
            {
                string path = FileHelper.Save(file, type).Data;

                entity.ImagePath = path;
                _dal.Add(entity);
                return new SuccessResult(Messages.Added);

            }
            else
            {
                string path = Get(ci => ci.Id == entity.Id).Data.ImagePath;
                FileHelper.Delete(path);
                string updatedPath = FileHelper.Save(file, type).Data;
                entity.ImagePath = updatedPath;
                _dal.Update(entity);
                return new SuccessResult(Messages.Updated);
            }

        }

        public IDataResult<List<string>> GetImagesByCarId(int carId)
        {

            IResult result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new SuccessDataResult<List<string>>(Messages.Success,
                    new List<string> { Path.Combine(Environment.CurrentDirectory, @"wwwroot\Image\default.png").ToString() });
            }

            List<string> Images = new List<string>();

            _dal.GetAll(ci => ci.CarId == carId).ForEach(x =>
            {
                Images.Add(x.ImagePath);
            });
            return new SuccessDataResult<List<string>>(Messages.Success, Images);

        }

        private IResult CheckCarImage(int carId)
        {
            if (_dal.GetAll(ci => ci.CarId == carId).Count <= 0)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckCarImageLimit(CarImage entity)
        {
            if (_dal.GetAll(ci => ci.CarId == entity.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitError);
            }

            return new SuccessResult();
        }
    }
}