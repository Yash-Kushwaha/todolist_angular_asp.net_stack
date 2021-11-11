using System.Collections.Generic;
using System.Linq;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly DatabaseContext db;

        public ToDoListRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void AddItem(ToDoItems toDoItems)
        {
            db.ToDoLists.Add(toDoItems);
            db.SaveChanges();
        }

        public void DeleteItem(string id)
        {
            var toDoItems = db.ToDoLists.Where(x => x.Id == id).FirstOrDefault();
            db.ToDoLists.Remove(toDoItems);
            db.SaveChanges();
        }

        public List<ToDoItems> GetAllItems()
        {
            return db.ToDoLists.Where(x => true).ToList();
        }

        public void UpdateItem(string id, ToDoItems toDoItem)
        {
            var res = db.ToDoLists.Where(x => x.Id == id).FirstOrDefault();
            res.Id = toDoItem.Id;
            res.Text = toDoItem.Text;
            res.IsCompleted = toDoItem.IsCompleted;
            db.Entry<ToDoItems>(res).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
