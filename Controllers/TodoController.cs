using System.Linq;
using System.Web.Mvc;
using ToDoList.Models;


namespace TodoListMvcApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext db = new TodoContext();

        // Показ усіх задач
        public ActionResult Index()
        {
            var items = db.TodoItems.OrderBy(i => i.Id).ToList();
            return View(items);
        }

        // Додавання нової задачі
        [HttpPost]
        public ActionResult Add(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                db.TodoItems.Add(new TodoItem { Title = title, IsDone = false });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Перемикання виконаного стану
        [HttpPost]
        public ActionResult Toggle(int id)
        {
            var item = db.TodoItems.Find(id);
            if (item != null)
            {
                item.IsDone = !item.IsDone;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Видалення задачі
        public ActionResult Delete(int id)
        {
            var item = db.TodoItems.Find(id);
            if (item != null)
            {
                db.TodoItems.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
