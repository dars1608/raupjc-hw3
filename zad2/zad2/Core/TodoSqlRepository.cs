using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2.Core
{
    public class TodoSqlRepository : ITodoRepository
    {
        private readonly TodoDbContext _context;

        public TodoSqlRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async void Add(TodoItem todoItem)
        {
            TodoItem ret = await _context.TodoItems.FirstOrDefaultAsync(i => i.Id.Equals(todoItem.Id));
            if (ret != null) throw new DuplicateTodoItemException("duplicate id: { " + todoItem.Id + "}");
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
        }

        public async Task<TodoItem> Get(Guid todoId, Guid userId)
        {
            var ret = await _context.TodoItems.Include(t => t.Labels).FirstOrDefaultAsync(i => i.Id.Equals(todoId));
            if (!ret.UserId.Equals(userId)) throw new TodoAccessDeniedException("User is not owner of that todo item");
            return ret;
        }

        public async Task<List<TodoItem>> GetActive(Guid userId)
        {
            return await _context.TodoItems.Where(t => t.IsCompleted == false && t.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<List<TodoItem>> GetAll(Guid userId)
        {
            return await _context.TodoItems.Where(t => t.UserId.Equals(userId)).OrderBy(t => t.DateCreated).ToListAsync();
        }

        public async Task<List<TodoItem>> GetCompleted(Guid userId)
        {
            return await _context.TodoItems.Where(t => t.IsCompleted == true && t.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<List<TodoItem>> GetFiltered(Func<TodoItem, bool> filterFunction, Guid userId)
        {
            return await _context.TodoItems.Where(t => filterFunction(t) && t.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<bool> MarkAsCompleted(Guid todoId, Guid userId)
        {
            TodoItem ret = await Get(todoId, userId);
            if (ret != null)
            {
                _context.Entry(ret).State = EntityState.Modified;
                ret.MarkAsCompleted();
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> Remove(Guid todoId, Guid userId)
        {
            TodoItem ret = await Get(todoId, userId);
            if (ret != null)
            {
                _context.TodoItems.Remove(ret);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async void Update(TodoItem todoItem, Guid userId)
        {
            TodoItem ret = await Get(todoItem.Id, userId);
            if (ret != null)
            {
                _context.Entry(ret).State = EntityState.Modified;
                ret = todoItem;
            }
            else
            {
                Add(todoItem);
            }
            _context.SaveChanges();
        }
    }
}
