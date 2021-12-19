using AlmagalApp.Models;
using AlmagalApp.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Services
{
    public interface ICustomerServices
    {
        Task <CustomerViewModelsResponse> Get();
        Task<CustomerViewModelResponse> Get(string id);
    }
    public class CustomerServices : ICustomerServices
    {
        private readonly ApplicationDbContext _db;
        public CustomerServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<CustomerViewModelsResponse> Get()
        {
            try
            {
                var query = await _db.Customers.Select(x => new CustomerViewModel
                {
                    CreatedAt = x.CreatedAt,
                    DeletedDate = x.DeletedDate,
                    Id = x.Id,Address=x.Address,FullName=x.FullName,
                    LastModified = x.LastModified,
                }).ToListAsync();
                if (query!=null)
                    return new CustomerViewModelsResponse
                    {
                        Customers = query,
                        response = new ResponseVModel
                        {
                            Message = "Successfull",
                            Status = true,
                        }
                    };
                return new CustomerViewModelsResponse
                {
                    Customers = query,
                    response = new ResponseVModel
                    {
                        Message = "NotFound",
                        Status = true,
                    }
                };

            }
            catch (Exception ex)
            {

                return new CustomerViewModelsResponse
                {
                    response = new ResponseVModel
                    {
                        Errors = new List<string>
                        {ex.InnerException.Message},
                        Message = "Exception Faild",

                    }
                };
            }
        }

        public async Task<CustomerViewModelResponse> Get(string id)
        {
            try
            {
                var query = await _db.Customers
                    .Where(x=> x.Id==id).Select(x => new CustomerViewModel
                    {
                    CreatedAt = x.CreatedAt,
                    DeletedDate = x.DeletedDate,
                    Id = x.Id,FullName=x.FullName,Address=x.Address,
                    LastModified = x.LastModified,
                }).FirstOrDefaultAsync();
                if (query != null)
                    return new CustomerViewModelResponse
                    {
                        Customer = query,
                        response = new ResponseVModel
                        {
                            Message = "Successfull",
                            Status = true,
                        }
                    };
                return new CustomerViewModelResponse
                {
                    Customer = query,
                    response = new ResponseVModel
                    {
                        Message = "NotFound",
                        Status = true,
                    }
                };

            }
            catch (Exception ex)
            {
                return new CustomerViewModelResponse
                {
                    response = new ResponseVModel
                    {
                        Errors = new List<string>
                        {ex.InnerException.Message},
                        Message = "Exception Faild",

                    }
                };
            }
        }
    }
}
