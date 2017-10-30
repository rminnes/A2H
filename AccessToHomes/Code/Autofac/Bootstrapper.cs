﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AccessToHomes.Code.Autofac
{
    public class Bootstrapper
    {

        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }

    }
}