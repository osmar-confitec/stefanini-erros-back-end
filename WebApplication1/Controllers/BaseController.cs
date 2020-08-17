using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{


    [ApiController]
    public abstract class BaseController : Controller
    {
        public readonly LNoty _notificacoes = new LNoty();


        protected BaseController(LNoty notificacoes)
        {
            _notificacoes = notificacoes;
        }

        protected IActionResult CustomResponse(Exception exception)
        {
            var n = new LNoty();
            n.Add(new Noty { Message = exception.InnerException?.Message ?? exception.Message  });
            return BadRequest(new
            {
                success = false,
                falhas = n
            });
        }

        protected IActionResult CustomResponse(object result = null)
        {

            if (_notificacoes == null || (_notificacoes != null && !_notificacoes.Any(x => x.NotyType == NotyType.Alert || x.NotyType == NotyType.Error)))
                return Ok(new
                {
                    success = true,
                    data = result
                });


            return BadRequest(new
            {
                success = false,
                falhas = _notificacoes
            });
        }



    }
}
