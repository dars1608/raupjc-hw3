using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad1.Models;

namespace zad1.Database
{
    public class TodoDbContext : DbContext
    {
        public IDbSet<TodoItem> TodoItems { get; set; }
        public IDbSet<TodoItemLabel> TodoItemLabels { get; set; }

        public TodoDbContext(string cnnstr) : base(cnnstr)
        {

        }


    }
}
