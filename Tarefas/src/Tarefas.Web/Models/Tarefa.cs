using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class Tarefa
{
    public int Id { get; set; }
    
    [Required(ErrorMessage     = " Por favor preencha o titulo ")]
    [MinLength(5, ErrorMessage = "O titulo deve conter no minino 5 caracteres")]
    [DisplayName("Título")]    
    public string? Titulo { get; set; }  


    [Required(ErrorMessage     = "Por favor preencha o campo de Descrição")]
    [MinLength(5, ErrorMessage = "A Descrição deve conter no minimo 5 caracteres")]
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; }  


    [DisplayName("Concluída")]
    public bool Concluida { get; set; }
}