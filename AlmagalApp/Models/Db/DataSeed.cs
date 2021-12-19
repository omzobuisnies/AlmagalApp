using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AlmagalApp.Models.Entities.Db
{
    public static class DataSeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            IServiceScopeFactory scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();


         
            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var _configuration = scope.ServiceProvider.GetService<IConfiguration>();

                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                context.Database.EnsureCreated();
                string customer0 = "osman moner", customer1 = "ahmed mohammes"
                    , customer2 = "khalid moder", aAddress= "Khartoum";
                #region customers
                var checkcustomer0 = context.Customers.Count(x => x.FullName.Contains(customer0)) > 0;
                if (!checkcustomer0)
                { 
                    var customer = new Customer
                    {
                        FullName=customer0,Address=aAddress,
                        
                    };
                    context.Customers.Add(customer);
                }

                var checkcustomer1 = context.Customers.Count(x => x.FullName.Contains(customer1)) > 0;
                if (!checkcustomer1)
                { 
                    var customer = new Customer
                    {
                        FullName=customer1,Address=aAddress,
                        
                    };
                    context.Customers.Add(customer);
                }

                var checkcustomer2 = context.Customers.Count(x => x.FullName.Contains(customer2)) > 0;
                if (!checkcustomer2)
                { 
                    var customer = new Customer
                    {
                        FullName=customer2,Address=aAddress,
                        
                    };
                    context.Customers.Add(customer);
                }
                #endregion
                #region Product
                string product0="زيت",
                     product1="بصل",
                     product2="سكر",
                     product3 = "لبن";
                var checkproduct0 = 
                    context.Products.Count(x => x.Name.Contains(product0)) > 0;
                if (!checkproduct0)
                {
                    var product = new Product
                    {
                        Name = product0,
                        Description=product0,
                    };
                    context.Products.Add(product);
                }

                var checkproduct1 = 
                    context.Products.Count(x => x.Name.Contains(product1)) > 0;
                if (!checkproduct1)
                {
                    var product = new Product
                    {
                        Name = product1,
                        Description=product1,
                    };
                    context.Products.Add(product);
                }

                var checkproduct2 = 
                    context.Products.Count(x => x.Name.Contains(product2)) > 0;
                if (!checkproduct2)
                {
                    var product = new Product
                    {
                        Name = product2,
                        Description=product2,
                    };
                    context.Products.Add(product);
                }

                var checkproduct3 = 
                    context.Products.Count(x => x.Name.Contains(product3)) > 0;
                if (!checkproduct3)
                {
                    var product = new Product
                    {
                        Name = product3,
                        Description=product3,
                    };
                    context.Products.Add(product);
                }


                #endregion

                await context.SaveChangesAsync();
            }
        }

    }

}

