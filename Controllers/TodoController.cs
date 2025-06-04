using System.Linq;
using System.Web.Mvc;
using ToDoList.Models;


namespace TodoListMvcApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext db = new TodoContext();
        public ActionResult Index()
        {
            var items = db.TodoItems.OrderBy(x => x.Id).ToList(); // Отримати всі задачі
            return View(items); // Передати список у View
        }

        // Метод для додавання нової задачі (через POST)
        [HttpPost]
        public ActionResult Add(string title)
        {
            if (!string.IsNullOrWhiteSpace(title)) // Перевірка, що введено щось
            {
                db.TodoItems.Add(new TodoItem { Title = title, IsDone = false });
                db.SaveChanges();
            }

            return RedirectToAction("Index"); // Повернутись на головну сторінку
        }

        // Метод для видалення задачі
        public ActionResult Delete(int id)
        {
            var item = db.TodoItems.Find(id);
            
            if(item != null)
            {
                db.TodoItems.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index"); // Повернутись
        }

        // Метод для перемикання виконання задачі (виконано ↔ не виконано)
        public ActionResult Toggle(int id)
        {
            var item = db.TodoItems.Find(id);

            if (item != null)
            {
                item.IsDone = !item.IsDone;
                db.SaveChanges();
            } // Змінити статус
            return RedirectToAction("Index"); // Повернутись
        }
    }
}
