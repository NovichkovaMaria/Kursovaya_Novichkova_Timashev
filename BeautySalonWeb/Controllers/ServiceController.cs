using BeautySalonBusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautySalonWeb.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceLogic _service;
        public ServiceController(IServiceLogic service)
        {
            _service = service;
        }
        public IActionResult Service()
        {
            ViewBag.Services = _service.Read(null);
            return View();
        }
    }
}
