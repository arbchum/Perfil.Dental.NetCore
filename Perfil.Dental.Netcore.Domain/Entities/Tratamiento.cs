using System;

namespace Perfil.Dental.Netcore.Domain.Entities
{
    public class Tratamiento
    {
        public int nIdTratamiento { get; set; }
        public string sNombre { get; set; }
        public string nPrecio { get; set; }
        public bool bActivo { get; set; }
        public DateTime dFechaReg { get; set; }
    }
}
