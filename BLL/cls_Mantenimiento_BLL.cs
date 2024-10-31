using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class cls_Mantenimiento_BLL
    {
        #region VARIABLE PRIVADA
        public cls_Mantenimiento_DAL Obj_Mantenimiento_DAL = new cls_Mantenimiento_DAL();
        #endregion

        #region MÉTODOS
        public List<cls_Mantenimiento> GetAllValues()
        {
            return Obj_Mantenimiento_DAL.GetAll();
        }
        public cls_Mantenimiento GetValueById(int id)
        {
            return Obj_Mantenimiento_DAL.GetById(id);
        }
        public List<cls_Mantenimiento> ConsultaFiltrada(cls_Mantenimiento P_Entidad)
        {
            return Obj_Mantenimiento_DAL.ConsultaFiltrada(P_Entidad);
        }
        public void AddValue(cls_Mantenimiento P_Entidad)
        {
            Obj_Mantenimiento_DAL.Add(P_Entidad);
        }
        public void UpdateValue(cls_Mantenimiento P_Entidad)
        {
            Obj_Mantenimiento_DAL.Update(P_Entidad);
        }
        public void DeleteValue(int id)
        {
            Obj_Mantenimiento_DAL.Delete(id);
        }
        #endregion
    }
}
