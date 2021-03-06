﻿using ProAngularJs.Api.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace ProAngularJs {
    public class Global : System.Web.HttpApplication {

        protected void Application_Start(object sender, EventArgs e) {
            Database.SetInitializer(new SportsStoreDbInitializer());

            GlobalConfiguration.Configure(cfg => {
                cfg.Formatters.Clear();
                cfg.Formatters.Add(new JsonMediaTypeFormatter());

                cfg.MapHttpAttributeRoutes();

                cfg.Routes.MapHttpRoute(
                    name: "DefaultApi", 
                    routeTemplate: "{controller}/{id}", 
                    defaults: new { id = RouteParameter.Optional });
            });
        }

        protected void Session_Start(object sender, EventArgs e) {

        }

        protected void Application_BeginRequest(object sender, EventArgs e) {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e) {

        }

        protected void Application_Error(object sender, EventArgs e) {

        }

        protected void Session_End(object sender, EventArgs e) {

        }

        protected void Application_End(object sender, EventArgs e) {

        }
    }
}