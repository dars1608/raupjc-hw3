using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad1.Database;
using zad1.Interfaces;

namespace zad1.Models
{
    public class TodoSqlRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoSqlRepository(TodoDbContext context)
        {
            _context = context;
        }
        public void Add(TodoItem todoItem)
        {
            if (_context.TodoItems.FirstOrDefault(i => i.Id.Equals(todoItem.Id)) != null) throw new DuplicateTodoItemException("duplicate id: { " + todoItem.Id + "}");
            _context.TodoItems.Add(todoItem);
        }

        public TodoItem Get(Guid todoId, Guid userId)
        {
            TodoItem ret = _context.TodoItems.FirstOrDefault(i => i.Id.Equals(todoId));
            if (!ret.UserId.Equals(userId)) throw new TodoAccessDeniedException("User is not owner of that todo item");
            return ret;
        }

        public List<TodoItem> GetActive(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetAll(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetCompleted(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction, Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool MarkAsCompleted(Guid todoId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid todoId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todoItem, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
