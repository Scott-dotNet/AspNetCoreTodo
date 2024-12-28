using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Controllers;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;

        public TodoItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = newItem.DueAt == null ? DateTimeOffset.Now.AddDays(new Random().Next(2) + 1) : newItem.DueAt;

            _context.Items.Add(newItem);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            // get unfinished todos from DB
            var items = await _context.Items
                .Where(x => x.IsDone == false)
                .ToArrayAsync();
            return items;
        }

        // 根据ID查询Item，标记完成
        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = await _context.Items
                .Where(x => x.id == id)
                .SingleOrDefaultAsync();

            if (item == null) { return false; } 
            item.IsDone = true;

            var saveResult = await _context.SaveChangesAsync(); 
            return saveResult == 1;
        }
    }
}
