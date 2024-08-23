using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace PortfolioProject.Controllers
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
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Project()
        {
            return View();
        }


        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var fromAddress = new MailAddress("pedrogomesskeell@gmail.com", "pedro gomes skeell");
                    var toAddress = new MailAddress("pedrogomesskeell@gmail.com", "pedro gomes skeell");
                    const string fromPassword = "bwidpifolhiggcfo";
                    const string subject = "Contact from Site";
                    string body = $"Company Name: {model.CompanyName}\nEmail: {model.Email}\nMessage: {model.Message}";

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        Timeout = 30000,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };

                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }

                    
                    ViewBag.Message = "Sucess!";
                    ModelState.Clear(); // clear

                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"Message Error: {ex.Message}";
                }
            }

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
