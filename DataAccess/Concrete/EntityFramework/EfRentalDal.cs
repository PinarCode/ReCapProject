using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public List<CarRentalDetailDto> GetCarRentalDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join cr in context.Customers on r.CustomerId equals cr.UserId
                             join clr in context.Colors on c.ColorId equals clr.ColorId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             select new CarRentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 RentDate = r.RentDate,
                                 IsReturned = r.ReturnDate != null
                             };
                return result.ToList();
            }
        }
    }
}
