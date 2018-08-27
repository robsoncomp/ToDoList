using System;

namespace ToDoList.Domain.Entities
{
    public class ToDo
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public bool Status { get; set; }
    }
}