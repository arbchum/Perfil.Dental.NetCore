using System.Collections.Generic;

namespace Perfil.Dental.Netcore.Domain.Entities
{
    public class Atencion
    {
        public int nIdAtencion { get; set; }
        public string sNota { get; set; }
        public int nIdCliente { get; set; }
        public double nMonto { get; set; }
        public IEnumerable<DetAtencion> DetAtencion { get; set; }
    }
    public class DetAtencion
    {
        public int nIdAtencion { get; set; }
        public int nIdTratamiento { get; set; }
        public int nCantidad { get; set; }
        public double nPrecio { get; set; }
    }

    public class AtencionDto
    {
        public int nIdAtencion { get; set; }
        public string sCodigo { get; set; }
        public string sFechaReg { get; set; }
        public string sNomCliente { get; set; }
        public decimal nMonto { get; set; }
        public string sActivo { get; set; }
    }

    public class AtencionHistorico
    {
        public string nIdAtencion { get; set; }
        public string sCodigo { get; set; }
        public string sFechaReg { get; set; }
        public string sNota { get; set; }
        public string sTratamientos { get; set; }
    }
}
