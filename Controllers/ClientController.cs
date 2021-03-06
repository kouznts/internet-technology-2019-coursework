﻿using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using HotelWebApp.Dal;
using HotelWebApp.Models;

namespace HotelWebApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly HotelContext _db = new HotelContext();

        [Authorize]
        public ActionResult Index()
        {
            return RedirectToAction("All", "Client");
        }

        [Authorize]
        public ActionResult All()
        {
            IEnumerable<Client> clients = _db.Clients;
            ViewBag.Clients = clients;

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Search(string search)
        {
            IEnumerable<Client> clients = _db.Clients.Where(
                c => c.FullName.Contains(search)).ToList();

            ViewBag.Clients = clients;

            return View("All");
        }
    }
}