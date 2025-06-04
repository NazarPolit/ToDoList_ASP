using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace ToDoList.Models
{
    // Клас, що представляє контекст бази даних
    public class TodoContext : DbContext
    {
        // Назва з'єднання з Web.config
        public TodoContext() : base("TodoConnection") { }

        // Таблиця задач
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
