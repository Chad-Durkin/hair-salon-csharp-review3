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
                return View["client_add.cshtml"];
            };
            Post["/client/add"] = _ => {
                List<Stylist> allStylists = Stylist.GetAll();
                if(allStylists.Count == 0)
                {
                    Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
                    newStylist.Save();
                    Client newClient = new Client(Request.Form["client-name"], newStylist.GetId());
                    newClient.Save();
                }
                else if(Stylist.IsNewStylist(Request.Form["stylist-name"]) == -1)
                {
                    Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
                    newStylist.Save();
                    Client newClient = new Client(Request.Form["client-name"], newStylist.GetId());
                    newClient.Save();
                }
                else
                {
                    Stylist theStylist = Stylist.FindByName(Request.Form["stylist-name"]);
                    Client newClient = new Client(Request.Form["client-name"], theStylist.GetId());
                    newClient.Save();
                }

                List<Stylist> updatedStylists = Stylist.GetAll();

                return View["index.cshtml", updatedStylists];
            };
            Get["/stylist/add"] = _ => {
                return View["stylist_add.cshtml"];
            };
            Post["/stylist/add"] = _ => {
                Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
                newStylist.Save();
                List<Stylist> allStylists = Stylist.GetAll();
                return View["index.cshtml", allStylists];
            };
            Get["/stylist/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object> {};
                var theStylist = Stylist.Find(parameters.id);
                List<Client> allClients = theStylist.GetClients();
                model.Add("stylist", theStylist);
                model.Add("clients", allClients);
                return View["stylist.cshtml", model];
            };
            Get["/stylist/client/edit/{id}"] = parameters => {
                Client editClient = Client.Find(parameters.id);
                return View["edit_client.cshtml", editClient];
            };
            Patch["/stylist/client/edit/{id}"] = parameters => {
                Client editClient = Client.Find(parameters.id);
                editClient.Update(Request.Form["client-name"]);
                Dictionary<string, object> model = new Dictionary<string, object> {};
                var theStylist = Stylist.Find(editClient.GetStylistId());
                List<Client> allClients = theStylist.GetClients();
                model.Add("stylist", theStylist);
                model.Add("clients", allClients);
                return View["stylist.cshtml", model];
            };
            Get["/stylist/client/delete/{id}"] = parameters => {
                Client editClient = Client.Find(parameters.id);
                return View["delete_client.cshtml", editClient];
            };
            Delete["/stylist/client/delete/{id}"] = parameters => {
                Client editClient = Client.Find(parameters.id);
                editClient.Delete();
                List<Stylist> allStylists = Stylist.GetAll();
                return View["index.cshtml", allStylists];
            };
        }
    }
}
