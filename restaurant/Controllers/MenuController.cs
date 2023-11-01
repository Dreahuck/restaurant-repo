using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restaurant.Abstraction;
using restaurant.Metier;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace restaurant.Controllers
{
    [Route("/")]
    public class MenuController : Controller
    {
        private MenuRepository _service;

        public MenuController(MenuRepository service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public Menu Get()
        {
            return _service.GetMenuOfTheMonth();
        }
    }
}

