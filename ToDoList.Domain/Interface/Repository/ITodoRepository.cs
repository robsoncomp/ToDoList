using System;
using System.Collections.Generic;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interface.Repository
{
    public interface IToDoRepository : IDisposable
    {
        ToDo ObterPorId(string id);
        IEnumerable<ToDo> ObterTodos();
        void AlterarStatus(int id, bool status);
    }
}