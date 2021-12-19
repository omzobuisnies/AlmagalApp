using AlmagalApp.Models;
using AlmagalApp.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Services
{
    public interface IProductServices
    {
        Task <ProductViewModelsResponse> Get();
        Task<ProductViewModelResponse> Get(string id);
    }
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _db;
        public ProductServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<ProductViewModelsResponse> Get()
        {
            try
            {
                var query = await _db.Products.Select(x => new ProductViewModel
                {
                    CreatedAt = x.CreatedAt,
                    DeletedDate = x.DeletedDate,
                    Description = x.Description,
                    Id = x.Id,
                    LastModified = x.LastModified,
                    Name = x.Name
                }).ToListAsync();
                if (query!=null)
                    return new ProductViewModelsResponse
                    {
                        Products = query,
                        response = new ResponseVModel
                        {
                            Message = "Successfull",
                            Status = true,
                        }
                    };
                return new ProductViewModelsResponse
                {
                    Products = query,
                    response = new ResponseVModel
                    {
                        Message = "NotFound",
                        Status = true,
                    }
                };

            }
            catch (Exception ex)
            {

                return new ProductViewModelsResponse
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

        public async Task<ProductViewModelResponse> Get(string id)
        {
            try
            {
                var query = await _db.Products
                    .Where(x=> x.Id==id).Select(x => new ProductViewModel
                {
                    CreatedAt = x.CreatedAt,
                    DeletedDate = x.DeletedDate,
                    Description = x.Description,
                    Id = x.Id,
                    LastModified = x.LastModified,
                    Name = x.Name
                }).FirstOrDefaultAsync();
                if (query != null)
                    return new ProductViewModelResponse
                    {
                        Product = query,
                        response = new ResponseVModel
                        {
                            Message = "Successfull",
                            Status = true,
                        }
                    };
                return new ProductViewModelResponse
                {
                    Product = query,
                    response = new ResponseVModel
                    {
                        Message = "NotFound",
                        Status = true,
                    }
                };

            }
            catch (Exception ex)
            {
                return new ProductViewModelResponse
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
