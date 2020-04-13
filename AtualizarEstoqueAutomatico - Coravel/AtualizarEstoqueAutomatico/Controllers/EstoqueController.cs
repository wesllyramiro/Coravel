using AtualizarEstoqueAutomatico.Invocavel;
using Coravel.Queuing.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtualizarEstoqueAutomatico.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IQueue _queue;
        public EstoqueController(IQueue queue)
        {
            _queue = queue;
        }
        [HttpGet]
        public IActionResult Index()
        {
            _queue.QueueInvocable<AtualizarEstoque>();
            return Ok();
        }
    }
}