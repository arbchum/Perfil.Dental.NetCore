using System;
using System.Collections.Generic;

namespace Perfil.Dental.NetCore.Application.Contracts.Responses
{
    public class OrtodonciaGetResponse
    {
        public string sCodigo { get; set; }
        public string sNomPaciente { get; set; }
        public short nIdEstado { get; set; }
        public DateTime dFechaReg { get; set; }
        public DateTime dFechaMod { get; set; }
        public IEnumerable<DetOrtodonciaGetResponse> Sesiones { get; set; }
    }

    public class DetOrtodonciaGetResponse
    {
        public short nNroSesion { get; set; }
        public DateTime dFechaControl { get; set; }
        public string sComentario { get; set; }
    }
}
