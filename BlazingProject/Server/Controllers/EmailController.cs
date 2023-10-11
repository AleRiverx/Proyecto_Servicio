using BlazingProject.Client.Helpers;
using BlazingProject.Shared.Models;
using Microsoft.AspNetCore.Mvc;


namespace BlazingProject.Server.Controllers
{
    public class EmailController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private HelperMail helpermail;
        public EmailController(HelperMail helpermail)
        {
            this.helpermail = helpermail;
        }
        [HttpPost]
        public IActionResult Index(string receptor,string asunto,string texto)
        {
            string mensajeFinal = $"<h1> FROC CONLABOR PUEBLA <h1/><h4>{texto}</4>";
            this.helpermail.SendMail(receptor, asunto, mensajeFinal);
            ViewData["MENSAJE"] = $"Mensaje enviado {receptor}";
            return View();
        }
    }
}
