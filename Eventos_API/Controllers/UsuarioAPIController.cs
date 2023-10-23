using Eventos_API.DataStorage;
using Eventos_API.Models;
using Eventos_API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventos_API.Controllers
{
    [Route("api/usuarioAPI")]
    [ApiController]
    public class UsuarioAPIController : ControllerBase
    {
        // LOGGER EN EL CONTROLADOR
        private readonly ILogger<UsuarioAPIController> _logger;

        private readonly ApplicationDBContext _dbContext;
        public UsuarioAPIController(ILogger<UsuarioAPIController> logger, ApplicationDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> GetUsuarios()
        {
            _logger.LogInformation("Devolvemos la Lista de Usuarios");
            return Ok(_dbContext.Usuarios.ToList());
        }

        [HttpGet("{id:int}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(200, Type =typeof(UsuarioDTO))]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        public ActionResult<UsuarioDTO> GetUsuario(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var usu = _dbContext.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usu == null)
            {
                return NotFound();
            }
            return Ok(usu);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UsuarioDTO> CreateUsuario([FromBody] UsuarioDTO usu)
        {
            if (_dbContext.Usuarios.FirstOrDefault(u => u.Name.ToLower() == usu.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "El usuario ya existe en la BBDD");
                return BadRequest(ModelState);
            }
            if (usu == null)
            {
                return BadRequest();
            }
            if (usu.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            int id = _dbContext.Usuarios.ToList().LastOrDefault() != null ? _dbContext.Usuarios.ToList().LastOrDefault().Id + 1 : 0;

            Usuario model = new() { Id = id, Name = usu.Name, Surname1 = usu.Surname1, Surname2 = usu.Surname2, Age = usu.Age, BirthDate = usu.BirthDate, High = usu.High, Location = usu.Location };
            _dbContext.Add(model);
            _dbContext.SaveChanges();



            return (CreatedAtRoute("GetUsuario", new { id = usu.Id }, usu));
        }

        [HttpDelete("{id:int}", Name = "DeleteUsuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUsuario(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var usu = _dbContext.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usu == null)
            {
                ModelState.AddModelError("CustomError", "El usuario no existe en la BBDD");
                return NotFound(ModelState);
            }
            _dbContext.Usuarios.Remove(usu);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateUsuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUsuario(int id, [FromBody] UsuarioDTO usu)
        {
            if (usu == null || id != usu.Id)
            {
                return BadRequest();
            }

            var usuario = _dbContext.Usuarios.AsNoTracking().FirstOrDefault(usu => usu.Id == id);
            if (usuario == null)
            {
                ModelState.AddModelError("CustomError", "El usuario no existe en la BBDD");
                return NotFound(ModelState);
            }
            else
            {
                Usuario model = new() { Id = usu.Id, Name = usu.Name, Surname1 = usu.Surname1, Surname2 = usu.Surname2, Age = usu.Age, BirthDate = usu.BirthDate, High = usu.High, Location = usu.Location };
                _dbContext.Usuarios.Update(model);
                _dbContext.SaveChanges();
            }

            return (CreatedAtRoute("GetUsuario", new { id = usu.Id }, usu));
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialUsuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialUsuario(int id, JsonPatchDocument<UsuarioDTO> patch)
        {
            if (patch == null)
            {
                return BadRequest();
            }

            var usu = _dbContext.Usuarios.AsNoTracking().FirstOrDefault(u => u.Id == id);

            UsuarioDTO dto = new() { Id = usu.Id, Name = usu.Name, Surname1 = usu.Surname1, Surname2 = usu.Surname2, Age = usu.Age, BirthDate = usu.BirthDate, High = usu.High, Location = usu.Location };

            if (usu == null)
            {
                return BadRequest();
            }
            patch.ApplyTo(dto, ModelState);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CustomError", "No fue posible actualizar el usuario.");
                return BadRequest(ModelState);
            }

            Usuario model = new() { Id = dto.Id, Name = dto.Name, Surname1 = dto.Surname1, Surname2 = dto.Surname2, Age = dto.Age, BirthDate = dto.BirthDate, High = dto.High, Location = dto.Location };

            _dbContext.Usuarios.Update(model);
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}
