using ATH.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccessToHomes.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ATHContext)).As(typeof(IContext)).InstancePerLifetimeScope();
        }


    }
}
