﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zad1.Models;

namespace zad1.Interfaces
{
    interface ITodoRepository
    {
        /// <summary >
        /// Gets TodoItem for a given id. Throw TodoAccessDeniedException 
        /// with appropriate message if user is not the owner of the Todo item
        /// </ summary >
        /// <param name =" todoId " > Todo Id </ param >
        /// <param name =" userId " >Id of the user that is trying to fetch the
        /// data</ param >
        /// <returns > TodoItem if found , null otherwise </ returns >
        Task<TodoItem> Get (Guid todoId, Guid userId) ;

        /// <summary >
        /// Adds new TodoItem object in database .
        /// If object with the same id already exists ,
        /// method should throw DuplicateTodoItemException with the message
        ///" duplicate id: {id }".
        /// </ summary >
        void Add(TodoItem todoItem);
        
        /// <summary >
        /// Tries to remove a TodoItem with given id from the database . Throw
        /// TodoAccessDeniedException with appropriate message if user is not
        /// the owner of the Todo item
        /// </ summary >
        /// <param name =" todoId " > Todo Id </ param >
        /// <param name =" userId " >Id of the user that is trying to remove the
        ///data</ param >
        /// <returns > True if success , false otherwise </ returns >
        Task<bool> Remove (Guid todoId, Guid userId) ;

        /// <summary >
        /// Updates given TodoItem in database .
        /// If TodoItem does not exist , method will add one . Throw
        /// TodoAccessDeniedException with appropriate message if user is not
        /// the owner of the Todo item
        /// </ summary >
        /// <param name =" todoItem " > Todo item </ param >
        /// <param name =" userId " >Id of the user that is trying to update the¸data</ param>
        void Update(TodoItem todoItem, Guid userId);

        /// <summary >
        /// Tries to mark a TodoItem as completed in database . Throw
        /// TodoAccessDeniedException with appropriate message if user is not
        /// the owner of the Todo item
        /// </ summary >
        /// <param name =" todoId " > Todo Id </ param >
        /// <param name =" userId " >Id of the user that is trying to mark as
        /// completed</ param >
        /// <returns > True if success , false otherwise </ returns >
        Task<bool> MarkAsCompleted (Guid todoId, Guid userId) ;

        /// <summary >
        /// Gets all TodoItem objects in database for user , sorted by date
        ///created(descending )
        /// </ summary >
        Task<List<TodoItem>> GetAll(Guid userId);

        /// <summary >
        /// Gets all incomplete TodoItem objects in database for user
        /// </ summary >
        Task<List<TodoItem>> GetActive(Guid userId);

        /// <summary >
        /// Gets all completed TodoItem objects in database for user
        /// </ summary >
        Task<List<TodoItem>> GetCompleted(Guid userId);

        /// <summary >
        /// Gets all TodoItem objects in database for user that apply to the
        /// filter
        /// </ summary >
        Task<List<TodoItem>> GetFiltered (Func<TodoItem, bool> filterFunction, Guid userId) ;

    }
}
