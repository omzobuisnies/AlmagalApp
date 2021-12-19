using AlmagalApp.Models;
using AlmagalApp.Models.DTO;
using AlmagalApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlmagalApp.Services
{
    public interface IInvoiceServices
    {
        Task<InvoiceVModelsResponse> Get();
        Task<InvoiceVModelResponse> Get(string id);
        Task<InvoiceVModelResponse> Get(int InvoiceCode);
        Task<ResponseVModel> Create(CreateInvoiceVModel create);
    }
    public class InvoiceServices:IInvoiceServices
    {
        private readonly ApplicationDbContext _db;

        public InvoiceServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ResponseVModel> Create(CreateInvoiceVModel model)
        {
            var customr = await _db.Customers.FindAsync(model.CustomerId);
            if (customr == null)
                return new ResponseVModel
                {
                    Message = "Check CustomerId",
                    Errors = new List<string> { "Customer Not Found" }
                };
            int successitem = 0;
            int faileditem = 0;
            var Error = new List<string>();
            var invoice = new Invoice
            {
                CustomerId = model.CustomerId,
            };
            await _db.Invoices.AddAsync(invoice);
            int InvoiceCode = GenerateRandomCode();

            if (_db.Invoices.Count(x => x.InvoiceCode == InvoiceCode) > 0)
                InvoiceCode = GenerateRandomCode();

            foreach (var item in model.Details)
            {
                var product = await _db.Products.FindAsync(item.ProductId);

                if (product != null)
                {
                    var details = new InvoiceDetails
                    {
                        Amount = item.Amount,
                        InvoiceId = invoice.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                    };
                    await _db.InvoiceDetails.AddAsync(details);
                    successitem += 1;
                }
                else
                {
                    Error.Add(item.ProductId + "rong id");
                    faileditem += 1;
                }
            }
            if (successitem > 0)
            {
                invoice.InvoiceCode = InvoiceCode;
                await _db.SaveChangesAsync();
                return new ResponseVModel
                {
                    Errors = Error,
                    Message = "Success",
                    Status = true,
                };
            }
            return new ResponseVModel
            {
                Errors = Error,
            };
        }
        // Generates a random number within a range.      
        public int GenerateRandomCode()
        {

            Random rnd = new Random();
            var value = rnd.Next(100000, 999999);
            return value;
        }
        public async Task<InvoiceVModelsResponse> Get()
        {
            try
            {
                var query = await _db.Invoices.Select(x => new InvoiceVModel
                {
                    CreatedAt = x.CreatedAt,
                    DeletedDate = x.DeletedDate,
                    Id = x.Id,CustomerId=x.CustomerId,
                     CustomerName=x.Customer.FullName,
                     InvoiceCode=x.InvoiceCode,
                    LastModified = x.LastModified,
                    Details=x.Details.Select(d=> new InvoiceDetailsVModel
                    {
                        Amount=d.Amount,CreatedAt=d.CreatedAt,DeletedDate=d.DeletedDate,
                        Id=d.Id,InvoiceId=d.InvoiceId,LastModified=d.LastModified,Product=d.Product.Name,
                        ProductId=d.ProductId,Quantity=d.Quantity
                    }).ToList(),TotalAmount=x.Details.Sum(s=> s.Amount)
                }).ToListAsync();
                if (query != null)
                    return new InvoiceVModelsResponse
                    {
                        invoice = query,
                        response = new ResponseVModel
                        {
                            Message = "Successfull",
                            Status = true,
                        }
                    };
                return new InvoiceVModelsResponse
                {
                    invoice = query,
                    response = new ResponseVModel
                    {
                        Message = "NotFound",
                        Status = true,
                    }
                };

            }
            catch (Exception ex)
            {

                return new InvoiceVModelsResponse
                {
                    response = new ResponseVModel
                    {
                        Errors = new List<string>
                        {ex.Message},
                        Message = "Exception Faild",

                    }
                };
            }
        }

        public async Task<InvoiceVModelResponse> Get(int InvoiceCode)
        {
            try
            {
                var query = await _db.Invoices
                    .Where(x=> x.InvoiceCode== InvoiceCode)
                    .Select(x => new InvoiceVModel
                {
                    CreatedAt = x.CreatedAt,
                    DeletedDate = x.DeletedDate,
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.FullName,
                    InvoiceCode = x.InvoiceCode,
                    LastModified = x.LastModified,
                    Details = x.Details.Select(d => new InvoiceDetailsVModel
                    {
                        Amount = d.Amount,
                        CreatedAt = d.CreatedAt,
                        DeletedDate = d.DeletedDate,
                        Id = d.Id,
                        InvoiceId = d.InvoiceId,
                        LastModified = d.LastModified,
                        Product = d.Product.Name,
                        ProductId = d.ProductId,
                        Quantity = d.Quantity
                    }).ToList(),
                    TotalAmount = x.Details.Sum(s => s.Amount)
                }).FirstOrDefaultAsync();
                if (query != null)
                    return new InvoiceVModelResponse
                    {
                        Invoice = query,
                        response = new ResponseVModel
                        {
                            Message = "Successfull",
                            Status = true,
                        }
                    };
                return new InvoiceVModelResponse
                {
                    Invoice = query,
                    response = new ResponseVModel
                    {
                        Message = "NotFound",
                        Status = true,
                    }
                };

            }
            catch (Exception ex)
            {

                return new InvoiceVModelResponse
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
        public async Task<InvoiceVModelResponse> Get(string id)
        {
            try
            {
                var query = await _db.Invoices
                    .Where(x=> x.Id==id)
                    .Select(x => new InvoiceVModel
                {
                    CreatedAt = x.CreatedAt,
                    DeletedDate = x.DeletedDate,
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.FullName,
                    InvoiceCode = x.InvoiceCode,
                    LastModified = x.LastModified,
                    Details = x.Details.Select(d => new InvoiceDetailsVModel
                    {
                        Amount = d.Amount,
                        CreatedAt = d.CreatedAt,
                        DeletedDate = d.DeletedDate,
                        Id = d.Id,
                        InvoiceId = d.InvoiceId,
                        LastModified = d.LastModified,
                        Product = d.Product.Name,
                        ProductId = d.ProductId,
                        Quantity = d.Quantity
                    }).ToList(),
                    TotalAmount = x.Details.Sum(s => s.Amount)
                }).FirstOrDefaultAsync();
                if (query != null)
                    return new InvoiceVModelResponse
                    {
                        Invoice = query,
                        response = new ResponseVModel
                        {
                            Message = "Successfull",
                            Status = true,
                        }
                    };
                return new InvoiceVModelResponse
                {
                    Invoice = query,
                    response = new ResponseVModel
                    {
                        Message = "NotFound",
                        Status = true,
                    }
                };

            }
            catch (Exception ex)
            {

                return new InvoiceVModelResponse
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
