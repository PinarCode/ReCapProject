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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, DatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from cr in context.Customers
                             join u in context.Users
                             on cr.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 Id = cr.UserId,
                                 UserId = u.Id,
                                 UserName = u.FirstName,
                                 UserLastName = u.LastName,
                                 CompanyName = cr.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
