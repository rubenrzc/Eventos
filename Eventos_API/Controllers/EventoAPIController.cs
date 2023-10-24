using Eventos_API.DataStorage;
using Eventos_API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventos_API.Controllers
{
    [Route("api/eventoAPI")]
    [ApiController]
    public class EventoAPIController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public EventoAPIController(ILogger<EventoAPIController> logger, ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventoDTO>> GetEventos()
        {
            var lista = _dbContext.Eventos.Include(e => e.Usuarios).ToList();
            
            return Ok(lista);
        }
    }
}
