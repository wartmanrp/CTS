using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using FancyRestaurant_dotNet.Models;

namespace FancyRestaurant_dotNet
{
   public class DependencyResolver : IDependencyResolver
   {
      private IKernel kernel;

      //public DependencyResolver(IKernel kernel)
      //{
      //   this.kernel = kernel;
      //}

      public DependencyResolver(IKernel kernelParam)
      {
         kernel = kernelParam;
         AddBindings();
      }

      public object GetService(Type serviceType)
      {
         return kernel.TryGet(serviceType);
      }

      public IEnumerable<object> GetServices(Type serviceType)
      {
         return kernel.GetAll(serviceType);
      }

      private void AddBindings()
      {
         //Mock<IReservationRepository> mock = new Mock<IReservationRepository>();

         kernel.Bind<IReservationRepository>().To<ReservationRepository>();

      }

      
   }
}