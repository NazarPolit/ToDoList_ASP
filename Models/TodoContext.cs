using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class TodoContext: DbContext
    {
        public TodoContext(): base("TodoConnection") { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}