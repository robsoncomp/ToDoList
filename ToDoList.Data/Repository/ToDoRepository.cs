using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Data.Context;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interface.Repository;

namespace ToDoList.Data.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _db;


        public ToDoRepository(ToDoContext context)
        {
            _db = context;
        }

        public void AlterarStatus(int id, bool status)
        {
            _db.ToDos.Find(id).Status = status;
            _db.ToDos.Find(id).DataAtualizacao = DateTime.Now;
            _db.SaveChanges();
        }

        public ToDo ObterPorId(string id)
        {
            return _db.ToDos.Find(id);
        }

        public IEnumerable<ToDo> ObterTodos()
        {
            return _db.ToDos.ToList();
        }

        public void Adicionar(ToDo todo)
        {
            _db.ToDos.Add(todo);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}