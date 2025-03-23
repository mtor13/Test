using ApiTest.Models;
using ApiTest.Repository.ActividadData;
using ApiTest.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    public class ActividadController : Controller
    {
        readonly IActividadRepository actividadData;
        public ActividadController(IActividadRepository _actividadData)
        {
            actividadData = _actividadData;
        }       

        [HttpGet]
        [Route("GetActividades")]
        public async Task<ActionResult<ActividadesViewModel>> GetActividades()
        {
            try
            {
                var actividadList = await actividadData.GetActividades();
                if (actividadList == null)
                {
                    return NotFound();
                }
                return Ok(actividadList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddActividad")]
        public async Task<IActionResult> AddActividad([FromBody] Actividades actividad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var idActividad = await actividadData.AddActividad(actividad);
                    if (idActividad > 0)
                    {
                        return Ok(idActividad);
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
