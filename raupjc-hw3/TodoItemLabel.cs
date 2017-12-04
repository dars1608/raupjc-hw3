using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    class TodoItemLabel
    {
        private Guid Id { get; set; }
        private string Value { get; set; }

        /// <summary >
        /// All TodoItems that are associated with this label
        /// </ summary >
        private List<TodoItem> LabelTodoItems { get; set; }

        public TodoItemLabel(string value)
        {
            Id = Guid.NewGuid();
            Value = value;
            LabelTodoItems = new List<TodoItem>();
        }
    }
}
