using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        // Service
        private readonly ITodoItemService _todoItemService;

        public TodoController (ITodoItemService todoItemService) 
        {
            _todoItemService = todoItemService;
        } 
        public async Task<IActionResult> Index()
        {
            // 从数据库获取 to-do items
            var items = await _todoItemService.GetIncompleteItemsAsync();
            // 把 items 置于 model 中
            var model = new TodoViewModel { Items = items };
            // Pass the view to a model and render
            return View(model);
        }
    }
}
