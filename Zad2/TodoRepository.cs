using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            _inMemoryTodoDatabase = initialDbState ?? new GenericList<TodoItem>();
            
        }

        public TodoItem Get(Guid todoId)
        {
            var item = _inMemoryTodoDatabase.FirstOrDefault(i => i.Id == todoId);
            return item;
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (Get(todoItem.Id) != null)
            {
                throw new DuplicateTodoItemException("duplicate id: { id }");
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(Get(todoId));
        }

        public TodoItem Update(TodoItem todoItem)
        {
            try
            {
                return Add(todoItem);
            }
            catch (DuplicateTodoItemException)
            {
                Remove(todoItem.Id);
                return Add(todoItem);
            }
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem i = Get(todoId);
            if (i != null)
                return i.MarkAsCompleted();
            return false;
        }

        public List<TodoItem> GetAll()
        {
            List<TodoItem> newList = _inMemoryTodoDatabase.OrderBy(i => i.DateCreated).ToList();
            return newList;
        }

        public List<TodoItem> GetCompleted()
        {
            List<TodoItem> newList = _inMemoryTodoDatabase.Where(i => i.DateCompleted.HasValue).ToList();
            return newList;
        }

        public List<TodoItem> GetActive()
        {
            List<TodoItem> newList = GetAll().Except(GetCompleted()).ToList();
            return newList;
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            IEnumerable<TodoItem> newList = GetAll().Where(filterFunction);
            return newList.ToList();
        }

    }
}
