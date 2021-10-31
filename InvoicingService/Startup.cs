using InvoicingData.Core;
using InvoicingRepository.Interface;
using InvoicingRepository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InvoicingService
{
    public class Startup
    {
        private IConfiguration _IConfiguration { get; }

        public Startup(IConfiguration pIConfiguration)
        {
            _IConfiguration = pIConfiguration;
        }

        public void ConfigureServices(IServiceCollection pIServiceCollection)
        {
            pIServiceCollection.AddDbContext<Context>(Options => Options.UseSqlServer(_IConfiguration.GetConnectionString("DefaultConnection")));
            pIServiceCollection.Configure<ConnectionStrings>(_IConfiguration.GetSection("ConnectionStrings"));
            pIServiceCollection.AddControllers();

            // Injeciones
            pIServiceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            pIServiceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            pIServiceCollection.AddScoped<IInvoiceRepository, InvoiceRepository>();
            pIServiceCollection.AddScoped<IProductRepository, ProductRepository>();
            pIServiceCollection.AddScoped<ISellerRepository, SellerRepository>();
        }

        public void Configure(IApplicationBuilder pIApplicationBuilder, IWebHostEnvironment pIWebHostEnvironment)
        {
            if (pIWebHostEnvironment.IsDevelopment())
            {
                pIApplicationBuilder.UseDeveloperExceptionPage();
            }
            pIApplicationBuilder.UseHttpsRedirection();
            pIApplicationBuilder.UseRouting();
            pIApplicationBuilder.UseAuthorization();
            pIApplicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}