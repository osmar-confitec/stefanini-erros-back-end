using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    public class Requisicao : IRequisicao
    {

       public readonly LNoty _notificacoes; 

        public Requisicao(LNoty notificacoes)
        {
            if (notificacoes == null)
                notificacoes = new LNoty();

            _notificacoes = notificacoes;
        }

        public async Task ObterRequisicao()
        {

            _notificacoes.Add(new Noty { Message = "Erro Fatal" });

           await  Task.CompletedTask;
        }
    }

    public interface IRequisicao
    {

        Task ObterRequisicao();

    }
}
