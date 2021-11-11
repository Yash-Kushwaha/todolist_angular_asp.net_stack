using Microsoft.AspNetCore.Mvc;
using System;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoListRepository db;

        public ToDoItemsController(IToDoListRepository db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(db.GetAllItems());
            }
            catch (Exception) { throw; }
        }

        [HttpPost]
        public IActionResult Post(ToDoItems toDo)
        {
            try
            {
                db.AddItem(toDo);
                return Ok();
            }
            catch (Exception) { throw; }
        }

        [HttpDelete("{Id}")]
        public IActionResult delete(string Id)
        {
            try
            {
                db.DeleteItem(Id);
                return Ok();
            }
            catch (Exception) { throw; }
        }

        [HttpPut("{Id}")]
        public IActionResult Put(string Id, ToDoItems toDo)
        {
            try
            {
                db.UpdateItem(Id, toDo);
                return Ok();
            }
            catch (Exception) { throw; }
        }
    }
}
