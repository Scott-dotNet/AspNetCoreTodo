using System;
using AspNetCoreTodo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        /// <summary>
        /// 异步获取未完成任务
        /// </summary>
        /// <returns> Task<TodoItem[]> </returns>
        Task<TodoItem[]> GetIncompleteItemsAsync();
    }
}
