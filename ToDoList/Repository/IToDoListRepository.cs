using System.Collections.Generic;
using ToDoList.Models;
namespace ToDoList.Repository
{
    public interface IToDoListRepository
    {
        void AddItem(ToDoItems toDoItems);
        void UpdateItem(string id, ToDoItems toDoItem);
        void DeleteItem(string id);
        List<ToDoItems> GetAllItems();
    }
}
