using ArriendoDeAutosASP.Models;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArriendoDeAutosASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public  IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }

        //public async Task<IActionResult> Contact()
        //{
        //    var sender = new SmtpSender(() => new System.Net.Mail.SmtpClient("smtp.gmail.com")
        //    {
        //        UseDefaultCredentials = false,
        //        Port = 587,
        //        Credentials = new NetworkCredential("mail@gmail.com", "Password"),
        //        EnableSsl = true,
        //    });
        //    Email.DefaultSender = sender;

        //    var email = Email
        //        .From("mail@gmail.com", "Tay Rent a Car")
        //        .To("mail@gmail.com", "Tay")
        //        .Subject("Questions")
        //        .Body("This is the Mail Body");

        //    await email.SendAsync();
        //    return view();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
