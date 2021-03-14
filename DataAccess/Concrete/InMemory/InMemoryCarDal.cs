using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>{
                new Car{CarId=1,BrandId=2,ColorId=4,ModelYear=2000,DailyPrice=200,Description="Günlük 200 TL"},
                new Car{CarId=2,BrandId=5,ColorId=1,ModelYear=2002,DailyPrice=240,Description="Günlük 240 TL"},
                new Car{CarId=3,BrandId=1,ColorId=2,ModelYear=2010,DailyPrice=300,Description="Günlük 300 TL"},
                new Car{CarId=4,BrandId=3,ColorId=6,ModelYear=2008,DailyPrice=280,Description="Günlük 280 TL"},
                new Car{CarId=5,BrandId=4,ColorId=1,ModelYear=2001,DailyPrice=220,Description="Günlük 220 TL"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId && c.BrandId == car.BrandId && c.ColorId == car.ColorId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId, int colorId)
        {
            return _cars.Where(c => c.BrandId == brandId && c.ColorId == colorId).ToList();
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId && c.BrandId == car.BrandId && c.ColorId == car.ColorId);
            carToUpdate.ColorId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
