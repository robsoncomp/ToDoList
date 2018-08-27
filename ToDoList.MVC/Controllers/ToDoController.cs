using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data.Context;
using ToDoList.Data.Repository;
using ToDoList.Domain.Entities;
using ToDoList.MVC.Models;

namespace ToDoList.MVC.Controllers
{
    public class ToDoController : Controller
    {
        private static ToDoContext _context;
        private readonly ToDoRepository _toDoRepository;

        public ToDoController(ToDoContext context)
        {
            _context = context;
            _toDoRepository = new ToDoRepository(_context);
        }

        public ActionResult Listar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Listar(ToDoViewModel instancia)
        {
            if (instancia == null) throw new ArgumentNullException(nameof(instancia));

            if (ModelState.IsValid)
            {
                var todo = new ToDo
                {
                    Data = Convert.ToDateTime(instancia.Data),
                    DataAtualizacao = DateTime.Now,
                    Descricao = instancia.Descricao,
                    Status = false
                };

                _toDoRepository.Adicionar(todo);
            }

            return RedirectToAction();
        }

        public JsonResult Grid(string query = "")
        {
            try
            {
                if (query == "done")
                    return Json(new {data = _toDoRepository.ObterTodos().Where(x => x.Status), status = "OK"});
                if (query == "todo")
                    return Json(new {data = _toDoRepository.ObterTodos().Where(x => x.Status == false), status = "OK"});
                return Json(new {data = _toDoRepository.ObterTodos(), status = "OK"});
            }
            catch (Exception e)
            {
                return Json(new {data = "", status = "Error"});
            }
        }

        public JsonResult AtualizarTarefa(int id)
        {
            try
            {
                _toDoRepository.AlterarStatus(id, true);
                return Json(new {data = "Atualizado", status = "OK"});
            }
            catch (Exception e)
            {
                return Json(new {data = "Erro ao Atualizar", status = "Error"});
            }
        }
    }
}