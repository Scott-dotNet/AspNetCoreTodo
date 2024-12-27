using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreTodo.Models
{
    public class TodoItem
    {
        //全局(globally) 唯一(unique) 标识符(identifier).
        public Guid id { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 保存一个 日期/时间 的戳记和一个与 UTC 偏移量表示的时区
        /// ? 表示 DueAt 属性 可空(nullable)，或者说是可选的
        /// </summary>
        public DateTimeOffset? DueAt { get; set; }

    }
}
