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
            _context.SaveChanges();
        }

        public TodoItem Get(Guid todoId, Guid userId)
        {
            TodoItem ret = _context.TodoItems.Include().FirstOrDefault(i => i.Id.Equals(todoId));
            if (!ret.UserId.Equals(userId)) throw new TodoAccessDeniedException("User is not owner of that todo item");
            return ret;
        }

        public List<TodoItem> GetActive(Guid userId)
        {
            return _context.TodoItems.Where(t => t.IsCompleted == false && t.UserId.Equals(userId)).ToList();
        }

        public List<TodoItem> GetAll(Guid userId)
        {
            return _context.TodoItems.Where(t => t.UserId.Equals(userId)).OrderBy(t => t.DateCreated).ToList();
        }

        public List<TodoItem> GetCompleted(Guid userId)
        {
            return _context.TodoItems.Where(t => t.IsCompleted == true && t.UserId.Equals(userId)).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction, Guid userId)
        {
            if (_context.TodoItems.ToList().Count == 0) return null;
            return _context.TodoItems.Where(t => filterFunction(t) && t.UserId.Equals(userId)).ToList();
        }

        public bool MarkAsCompleted(Guid todoId, Guid userId)
        {
            TodoItem ret = Get(todoId, userId);
            if (ret != null)
            {
                ret.MarkAsCompleted();
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Remove(Guid todoId, Guid userId)
        {
            TodoItem ret = Get(todoId, userId);
            if (ret != null)
            {
                _context.TodoItems.Remove(ret);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(TodoItem todoItem, Guid userId)
        {
            TodoItem ret = Get(todoItem.Id, userId);
            if (ret != null)
            {
                _context.TodoItems.Remove(todoItem);
                Add(todoItem);
            }
            else
            {
                Add(todoItem);
            }
            _context.SaveChanges();
        }
    }
}
