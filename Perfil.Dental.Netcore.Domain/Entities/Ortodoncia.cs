using System;
using System.Collections.Generic;

namespace Perfil.Dental.Netcore.Domain.Entities
{
    public class Ortodoncia
    {
        public int? nIdOrtodoncia { get; set; }
        public int? nIdPaciente { get; set; }
        public int? nEstado { get; set; }
        public int? nCantidadSesiones { get; set; }
        public DateTime? dFechaInstalacion { get; set; }
        public DateTime? dFechaTermino { get; set; }
        public string sComentario { get; set; }
        public IEnumerable<DetOrtodoncia> DetOrtodoncia { get; set; }
    }
    public class DetOrtodoncia
    {
        public int? nIdDetOrtodoncia { get; set; }
        public int? nIdOrtodoncia { get; set; }
        public string sDescripcion { get; set; }
        public DateTime? dFechaControl { get; set; }
    }
    public class OrtodonciaDto
    {
        public int nIdOrtodoncia { get; set; }
        public string sCodigo { get; set; }
        public int nIdPaciente { get; set; }
        public string sNomPaciente { get; set; }
        public string sFechaInstalacion { get; set; }
        public string sFechaTermino { get; set; }
        public int nEstado { get; set; }
        public string sEstado { get; set; }
        public int nCantidadSesiones { get; set; }
        public string sFechaReg { get; set; }   
    }

    public class DetOrtodonciaDto
    {
        public string sControl { get; set; }
        public string sFechaControl { get; set; }
        public string sDescripcion { get; set; }
    }
}
