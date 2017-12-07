using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zad2.Core;
using zad2.Data;

namespace zad2.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;


        public TodoController(ITodoRepository repository, UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;

        }
    public IActionResult Index()
        {
            return View();
        }
    }
}