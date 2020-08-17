using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/requisicao")]
    public class RequisicaoController : BaseController
    {

        public readonly IRequisicao _requisicao;

        public RequisicaoController(IRequisicao requisicao,LNoty notificacoes) 
                        : base(notificacoes)
        {
            _requisicao = requisicao;

        }



        [HttpGet]
        [Route("RetornarOk")]
        public async Task<IActionResult> RetornarOk()
        {
            // throw new Exception(" Erro Bad ");
            try
            {
                await _requisicao.ObterRequisicao();
                //throw new Exception(" Erro Bad ");
                return CustomResponse(new { ativo = true });
            }
            catch (Exception ex)
            {
                return CustomResponse(ex);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
