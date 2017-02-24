using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace HairSalon
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                List<Stylist> allStylists = Stylist.GetAll();
                return View["index.cshtml", allStylists];
            };
            Get["/client/add"] = _ => {
                List<Stylist> allStylists = Stylist.GetAll();
                return View["client_add.cshtml", allStylists];
            };
            // Post["/client/add"] = _ => {
            //     List<Stylist> allStylists = Stylist.GetAll();
            //     if(allStyles.Count == 0)
            //     {
            //         Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
            //         newStylist.Save();
            //         Client newClient = new Client(Request.Form["client-name"], newStylist.GetId());
            //         newClient.Save();
            //     }
            //     else
            //     {
            //         Stylist theStylist = Stylist.Find()
            //     }
            //     return View["index.cshtml", allStylists];
            // };
        }
    }
}
