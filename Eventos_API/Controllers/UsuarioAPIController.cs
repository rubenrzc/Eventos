using Eventos_API.DataStorage;
using Eventos_API.Models;
using Eventos_API.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Eventos_API.Controllers
{
    [Route("api/usuarioAPI")]
    [ApiController]
    public class UsuarioAPIController : ControllerBase
    {
        // LOGGER EN EL CONTROLADOR
        private readonly ILogger<UsuarioAPIController> _logger;
        public UsuarioAPIController(ILogger<UsuarioAPIController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> GetUsuarios()
        {
            _logger.LogInformation("Devolvemos la Lista de Usuarios");
            return Ok(UsuarioStore.GetAll);
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
            List<UsuarioDTO> list = UsuarioStore.GetAll;

            UsuarioDTO usu = list.FirstOrDefault(u => u.Id == id);

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
            if (UsuarioStore.GetAll.FirstOrDefault(u => u.Name.ToLower() == usu.Name.ToLower()) != null)
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
            usu.Id = UsuarioStore.GetAll.Count + 1;

            UsuarioStore.GetAll.Add(usu);



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

            var usu = UsuarioStore.GetAll.FirstOrDefault(u => u.Id == id);
            if (usu == null)
            {
                ModelState.AddModelError("CustomError", "El usuario no existe en la BBDD");
                return NotFound(ModelState);
            }
            UsuarioStore.GetAll.Remove(usu);

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

            var usuario = UsuarioStore.GetAll.FirstOrDefault(usu => usu.Id == id);
            if (usuario == null)
            {
                ModelState.AddModelError("CustomError", "El usuario no existe en la BBDD");
                return NotFound(ModelState);
            }
            else
            {
                usuario.Name = usu.Name;
                usuario.Age = usu.Age;
                usuario.High = usu.High;
            }

            return (CreatedAtRoute("GetUsuario", new { id = usu.Id }, usu));
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialUsuario")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialUsuario(int id, JsonPatchDocument<UsuarioDTO> patch)
        {
            if (patch == null || id == 0)
            {
                return BadRequest();
            }

            var usu = UsuarioStore.GetAll.FirstOrDefault(u => u.Id == id);
            if (usu == null)
            {
                return BadRequest();
            }
            patch.ApplyTo(usu, ModelState);
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CustomError", "");
                return BadRequest(ModelState);
            }

            return NoContent();
        }

    }
}
