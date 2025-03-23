using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAppTest.Models;
using WebAppTest.Services.Actividades;
using WebAppTest.Services.Usuarios;

namespace WebAppTest.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarios _service;
        private UsuariosModel _usuario = new UsuariosModel();

        public UsuariosController(IUsuarios service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<IActionResult> UsuariosView()
        {
            return View();
        }

        public async Task<IActionResult> AddUsuario(
            [FromForm] string nombre,
            [FromForm] string apellido,
            [FromForm] string email,
            [FromForm] DateOnly fecha,
            [FromForm] int telefono,
            [FromForm] string pais,
            [FromForm] bool contacto
            )
        {            
            _usuario.Nombre = nombre;
            _usuario.Apellido = apellido;
            _usuario.CorreoElectronico = email;
            _usuario.FechaNacimiento = fecha;
            _usuario.Telefono = telefono;
            _usuario.PaisResidencia = pais;
            _usuario.Contacto = contacto;
            await _service.AddUsuario(_usuario);

            return Ok();
        }
    }
}
