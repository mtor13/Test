using System.Text.Json;
using ApiTest.Models;
using ApiTest.Repository.ActividadData;
using ApiTest.Repository.UsuarioData;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    public class UsuarioController : Controller
    {
        readonly IUsuarioRepository usuarioData;
        public UsuarioController(IUsuarioRepository _usuarioData)
        {
            usuarioData = _usuarioData;
        }

        [HttpGet]
        [Route("GetUsuarios")]
        public async Task<ActionResult<Actividades>> GetUsuarios()
        {
            try
            {
                var usuarioList = await usuarioData.GetUsuarios();
                if (usuarioList == null)
                {
                    return NotFound();
                }
                return Ok(usuarioList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUsuario")]
        public async Task<IActionResult> AddUsuario([FromBody] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Usuarios user = JsonSerializer.Deserialize<Usuarios>(usuario.ToString());
                    var idUsuario = await usuarioData.AddUsuario(usuario);
                    if (idUsuario > 0)
                    {

                        return Ok(idUsuario);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }
    }
}
