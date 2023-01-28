
using Tarefas.DTO;

namespace Tarefas.DAO
{    
    public interface ITarefaDAO
    {
        void Atualizar(TarefaDTO tarefa);
        List<TarefaDTO> Consultar();
        TarefaDTO Consultar(int Id);
        void Criar(TarefaDTO tarefa);
        void Excluir(int id);
    }
}