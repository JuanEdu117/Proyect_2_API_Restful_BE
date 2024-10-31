using BLL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_BE.Controllers
{
    [Route("api/Empleados")]
    [ApiController]
    public class EmpleadosController : Controller
    {
        #region VARIABLE PRIVADA
        private cls_Empleados_BLL Obj_Empleado_BLL = new cls_Empleados_BLL();
        #endregion

        #region EVENTOS APERTURA VIEW
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region MÉTODOS
        // GET: api/values
        [HttpGet]
        [Route(nameof(ListarEmpleados))] //BORRAR ROUTE DE SER NECESARIO
        public ActionResult<List<cls_Empleados>> ListarEmpleados() //Get()
        {
            return Obj_Empleado_BLL.GetAllValues();
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        [Route(nameof(FiltrarEmpleados))]
        public ActionResult<cls_Empleados> FiltrarEmpleados(int id)
        {
            var value = Obj_Empleado_BLL.GetValueById(id);
            if (value == null)
            {
                return NotFound();
            }
            return value;

        }

        [HttpGet]
        [Route(nameof(ConsultarEmpleados))]
        public List<cls_Empleados> ConsultarEmpleados([FromHeader] int id)
        {
            return Obj_Empleado_BLL.ConsultaFiltrada(new cls_Empleados
            {
                iCedula = id
            });
        }

        // POST: api/values
        [HttpPost]
        [Route(nameof(AgregarEmpleados))]
        public ActionResult AgregarEmpleados([FromBody] cls_Empleados P_Entidad)
        {
            Obj_Empleado_BLL.AddValue(P_Entidad);
            return CreatedAtAction(nameof(FiltrarEmpleados), new { id = P_Entidad.iCedula }, P_Entidad); //nameof(Get())
        }

        // PUT: api/values/5
        [HttpPut("{id}")]
        [Route(nameof(ModificarEmpleados))]
        public IActionResult ModificarEmpleados([FromHeader] int id, [FromBody] cls_Empleados P_Entidad)
        {
            if (P_Entidad.iCedula != id)
            {
                return BadRequest();
            }
            var existingValue = Obj_Empleado_BLL.GetValueById(id);
            if (existingValue == null)
            {
                return NotFound();
            }
            Obj_Empleado_BLL.UpdateValue(P_Entidad);
            return NoContent();
        }

        // DELETE: api/values/5
        [HttpDelete("{id}")]
        [Route(nameof(EliminarEmpleados))]
        public IActionResult EliminarEmpleados([FromHeader] int id)
        {
            var value = Obj_Empleado_BLL.GetValueById(id);
            if (value == null)
            {
                return NotFound();
            }
            Obj_Empleado_BLL.DeleteValue(id);
            return NoContent();
        }
        #endregion
    }
}
