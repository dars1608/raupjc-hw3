using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace zad2.Core
{
    public class TodoItem
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted
        {
            get
            {
                return DateCompleted.HasValue;
            }
        }

        public DateTime? DateCompleted { get; set; }
        public DateTime DateCreated { get; set; }

        public TodoItem(string text)
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.UtcNow;
            Text = text;
        }

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj.GetType() == typeof(TodoItem)))
            {
                return false;
            }

            var todoItem = obj as TodoItem;

            return this.Id.Equals(todoItem.Id);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public bool MarkAsCompleted()
        {
            if (!IsCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        /// <summary >
        /// User id that owns this TodoItem
        /// </ summary >
        public Guid UserId { get; set; }

        /// <summary>
        /// List of labels associated with TodoItem
        /// </ summary >
        public List<TodoItemLabel> Labels { get; set; }

        /// <summary >
        /// Date due . If null , no date was set by the user
        /// </ summary >
        public DateTime? DateDue { get; set; }

        public TodoItem(string text, Guid userId)
        {
            Id = Guid.NewGuid();
            Text = text;
            DateCreated = DateTime.UtcNow;
            UserId = userId;
            Labels = new List<TodoItemLabel>();
        }
        public TodoItem()
        {
            // entity framework needs this one
            // not for use :)
        }
    }
}