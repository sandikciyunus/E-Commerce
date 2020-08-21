using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ShopContext>(opt=>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Remote"),conf=> {
                    conf.MigrationsAssembly("WebUI");
                });
            });

            //services.AddScoped(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<>));
            //services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDal, EfOrderDal>();

            services.AddScoped<IOrderLineService, OrderLineService>();
            services.AddScoped<IOrderLineDal, EfOrderLineDal>();

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICommentDal, EfCommentDal>();

            services.AddScoped<ICartService, CartService>();

           


        }
    }
}
