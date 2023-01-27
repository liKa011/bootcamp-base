using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        public List<Tarefa> listaDeTarefas { get; set; }

        public TarefaController()
        {
            listaDeTarefas = new List<Tarefa>()
            {
                new Tarefa() { Id = 1, Titulo = "Escovar os dentes" },
                new Tarefa() { Id = 2, Titulo = "Arrumar a cama" },
                new Tarefa() { Id = 3, Titulo = "Por o lixo para fora", Descricao = "somente às terças, quintas e sábados" }
            };
        }

/*         public IActionResult Details(int id)
        {
            var tarefa = listaDeTarefas.Find(tarefa => tarefa.Id == id);
            return View(tarefa);
        } */

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {
            var tarefaDTO = new TarefaDTO
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Criar(tarefaDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var tarefaDAO = new TarefaDAO();
            var listDeTarefasDTO = tarefaDAO.Consultar();
            var listaDeTarefa = new List<Tarefa>();

            foreach (var tarefaDTO in listDeTarefasDTO)
            {
                listaDeTarefa.Add(new Tarefa()
                {
                    Id = tarefaDTO.Id,
                    Titulo = tarefaDTO.Titulo,
                    Descricao = tarefaDTO.Descricao,
                    Concluida = tarefaDTO.Concluida
                });
            }
            return View(listaDeTarefa);
        }

        public IActionResult Details(int id)
        {
            var tarefaDAO = new TarefaDAO();
            var tarefaDTO = tarefaDAO.Consultar(id);
            var tarefa = new Tarefa()
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };
            return View(tarefa);
        }

        public IActionResult Update(Tarefa tarefa){
             var tarefaDTO = new TarefaDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("Index");
        }


    }
}