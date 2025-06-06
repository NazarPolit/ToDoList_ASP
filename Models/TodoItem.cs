﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}