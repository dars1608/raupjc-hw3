using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using zad2.Core;
using zad2.Data;
using Serilog;

namespace zad2.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoRepository _repository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;


        public TodoController(ITodoRepository repository, UserManager<ApplicationUser> userManager, ILogger logger)
        {
            _repository = repository;
            _userManager = userManager;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var user = await _userManager.GetUserAsync(null);
            var allActive = await _repository.GetActive(new Guid(user.Id));
            List<TodoViewModel> tvm = new List<TodoViewModel>();
            foreach(TodoItem todo in allActive){
                tvm.Add(new TodoViewModel(todo.Text, todo.DateCreated)); 
            }
            return View(new IndexViewModel(tvm));
        }
    }
}