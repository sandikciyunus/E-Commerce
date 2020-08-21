using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<ProductService>().As<IProductService>();

            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();

            builder.RegisterType<EfOrderDal>().As<IOrderDal>();
            builder.RegisterType<OrderService>().As<IOrderService>();

            builder.RegisterType<EfOrderLineDal>().As<IOrderLineDal>();
            builder.RegisterType<OrderLineService>().As<IOrderLineService>();

            builder.RegisterType<EfCommentDal>().As<ICommentDal>();
            builder.RegisterType<CommentService>().As<ICommentService>();


            builder.RegisterType<CartService>().As<ICartService>();
           // builder.RegisterType<CartSessionService>().As<ICartService>();
        }
    }
}
