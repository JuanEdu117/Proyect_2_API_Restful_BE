using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class cls_Inventario_DAL
    {
        #region VARIABLE PRIVADA   
        private static List<cls_Inventario> _lstInventario = new List<cls_Inventario>
        { new cls_Inventario {  IdInventario = 1, 
                                Descripcion = "Mediana", 
                                TipoMaquina = "Shindaiwa", 
                                HorasActuales = 1, 
                                HorasMaximas = 1000, 
                                HorasMantenimiento = 100}
        };
        #endregion
        #region MÉTODOS EMPLEADOS

        public List<cls_Inventario> GetAll()
        {
            return _lstInventario;
        }
        public cls_Inventario GetById(int id)
        {
            return _lstInventario.FirstOrDefault(v => v.IdInventario == id);
        }
        public List<cls_Inventario> ConsultaFiltrada(cls_Inventario P_Entidad)
        {
            List<cls_Inventario> lstResultado = new List<cls_Inventario>();
            try
            {
                if (!string.IsNullOrEmpty(P_Entidad.IdInventario.ToString()))
                {
                    lstResultado = _lstInventario.Where(doc => doc.IdInventario == P_Entidad.IdInventario).OrderBy(orden => orden.Descripcion).ToList();
                }
                else if (!string.IsNullOrEmpty(P_Entidad.Descripcion))
                {
                    lstResultado = _lstInventario.Where(doc => doc.Descripcion.Equals(P_Entidad.Descripcion)).OrderBy(orden => orden.Descripcion).ToList();
                }
                else
                {
                    lstResultado = _lstInventario.OrderBy(orden => orden.Descripcion).ToList(); // Devuelve todo ordenado por nombre
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstResultado;
        }
        public void Add(cls_Inventario P_Entidad)
        {
            //P_Entidad.iCedula = _lstEmpleado.Max(v => v.iCedula) + 1;
            _lstInventario.Add(P_Entidad);
        }
        public void Update(cls_Inventario P_Entidad)
        {
            var existingInventario = GetById(P_Entidad.IdInventario);
            if (existingInventario != null)
            {
                existingInventario.Descripcion= P_Entidad.Descripcion;
                existingInventario.TipoMaquina = P_Entidad.TipoMaquina;
                existingInventario.HorasActuales = P_Entidad.HorasActuales;
                existingInventario.TipoMaquina = P_Entidad.TipoMaquina;
                existingInventario.HorasMantenimiento = P_Entidad.HorasMantenimiento;
            }
        }
        public void Delete(int id)
        {
            var inventario = GetById(id);
            if (inventario != null)
            {
                _lstInventario.Remove(inventario);
            }
        }
        #endregion
    }
}
