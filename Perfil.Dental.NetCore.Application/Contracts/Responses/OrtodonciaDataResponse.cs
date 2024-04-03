using System;
using System.Collections.Generic;

namespace Perfil.Dental.NetCore.Application.Contracts.Responses
{
    public class OrtodonciaDataResponse
    {
        public string sCodigo { get; set; }
        public int nIdPaciente { get; set; }
        public string sNomPaciente { get; set; }
        public short nCantidadControles { get; set; }
        public string sEstado { get; set; }
        public string sFechaReg { get; set; }
        public IEnumerable<DetOrtodonciaDataResponse> Sesiones { get; set; }
    }

    public class DetOrtodonciaDataResponse
    {
        public string sControl { get; set; }
        public DateTime dFechaControl { get; set; }
        public string sComentario { get; set; }
    }
}
