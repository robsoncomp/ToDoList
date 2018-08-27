using System.ComponentModel.DataAnnotations;

namespace ToDoList.MVC.Models
{
    public class ToDoViewModel
    {
        [Required(ErrorMessage = "Campo Descrição Obrigatório")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Data Obrigatório")]
        [Display(Name = "Data")]
        public string Data { get; set; }
    }
}