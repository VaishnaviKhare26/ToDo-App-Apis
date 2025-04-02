﻿using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Model
{
    public class ToDoItemResponceModel
    {

        
        public int Id { get; set; }
       
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsDone { get; set; }
       
        public String Priority { get; set; } = string.Empty;

        public DateTime Duedate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now.ToUniversalTime();
    }
}