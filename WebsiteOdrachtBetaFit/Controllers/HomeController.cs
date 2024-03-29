﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebsiteOdrachtBetaFit.Models;
using MySql.Data;

namespace WebsiteOdrachtBetaFit.Controllers

{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from locaties");

            // lijst maken om alle namen in te stoppen
            List<string> names = new List<string>();

            foreach (var row in rows)
            {
                // elke naam toevoegen aan de lijst met namen
                names.Add(row["name"].ToString());
            }

            // de lijst met namen in de html stoppen
            return View(names);
        }
        [Route("Locatie")]
        public IActionResult Locatie()
        {
            return View();
        }

        [Route("Trainers")]
        public IActionResult Trainers()
        {
            return View();
        }

        [Route("show-all")]

        public IActionResult ShowAll()
        {

            return View();

        }
        [Route("Price")]
        public IActionResult Price()
        {
            return View();
        }



        [Route("Shop")]
        public IActionResult Shop()
        {
            return View();
        }


        [Route("Contact")]
        public IActionResult Contact()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
                return Redirect("/succes");

            return View(person);
        }

        public IActionResult PageNotFound(string searchTerm)
        {
            // Gebruik de searchTerm om eventuele logica uit te voeren of geef deze door aan de weergave (View)
            Response.StatusCode = 404;
            return View();
        }

       /* public IActionResult QRcode()
        {
            return RedirectToAction("qrcode-page", "Home");
        }
*/



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new TheBios.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}