using Perfil.Dental.Netcore.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Perfil.Dental.Netcore.Domain.Entities
{
    public class Ortodoncia
    {
        public int nIdPaciente { get; set; }
        public EAtencionEstado? nIdEstado { get; set; }
        public short nIdUsuario { get; set; }
        public IEnumerable<DetOrtodoncia> DetOrtodoncia { get; set; }
    }
    public class DetOrtodoncia
    {
        public int nIdPaciente { get; set; }
        public short nNroSesion { get; set; }
        public string sComentario { get; set; }
        public DateTime dFechaControl { get; set; }
        public short nIdUsuario { get; set; }
    }
}
