﻿using BLL;
using Entidades;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_BE.Controllers
{
    [Route("api/Inventario")]
    [ApiController]
    public class InventarioController : Controller
    {
        #region VARIABLE PRIVADA
        private cls_Inventario_BLL Obj_Inventario_BLL = new cls_Inventario_BLL();
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
        [Route(nameof(ListarInventario))] //BORRAR ROUTE DE SER NECESARIO
        public ActionResult<List<cls_Inventario>> ListarInventario() //Get()
        {
            return Obj_Inventario_BLL.GetAllValues();
        }

        // GET: api/values/5
        [HttpGet("{id}")]
        [Route(nameof(FiltrarInventario))]
        public ActionResult<cls_Inventario> FiltrarInventario(int id)
        {
            var value = Obj_Inventario_BLL.GetValueById(id);
            if (value == null)
            {
                return NotFound();
            }
            return value;

        }

        [HttpGet]
        [Route(nameof(ConsultarInventario))]
        public List<cls_Inventario> ConsultarInventario([FromHeader] int id)
        {
            return Obj_Inventario_BLL.ConsultaFiltrada(new cls_Inventario
            {
                IdInventario = id
            });
        }

        // POST: api/values
        [HttpPost]
        [Route(nameof(AgregarInventario))]
        public ActionResult AgregarInventario([FromBody] cls_Inventario P_Entidad)
        {
            Obj_Inventario_BLL.AddValue(P_Entidad);
            return CreatedAtAction(nameof(FiltrarInventario), new { id = P_Entidad.IdInventario }, P_Entidad); //nameof(Get())
        }

        // PUT: api/values/5
        [HttpPut("{id}")]
        [Route(nameof(ModificarInventario))]
        public IActionResult ModificarInventario([FromHeader] int id, [FromBody] cls_Inventario P_Entidad)
        {
            if (P_Entidad.IdInventario!= id)
            {
                return BadRequest();
            }
            var existingValue = Obj_Inventario_BLL.GetValueById(id);
            if (existingValue == null)
            {
                return NotFound();
            }
            Obj_Inventario_BLL.UpdateValue(P_Entidad);
            return NoContent();
        }

        // DELETE: api/values/5
        [HttpDelete("{id}")]
        [Route(nameof(EliminarInventario))]
        public IActionResult EliminarInventario([FromHeader] int id)
        {
            var value = Obj_Inventario_BLL.GetValueById(id);
            if (value == null)
            {
                return NotFound();
            }
            Obj_Inventario_BLL.DeleteValue(id);
            return NoContent();
        }
        #endregion
    }
}
