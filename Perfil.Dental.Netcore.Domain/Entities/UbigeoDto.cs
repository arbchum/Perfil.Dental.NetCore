using System.Collections.Generic;

namespace Perfil.Dental.Netcore.Domain.Entities
{
    public class UbigeoDto
    {
        public int nIdProv { get; set; }
        public string sNomProv { get; set; }
        public int nIdDist { get; set; }
        public string sNomDist { get; set; }
    }

    public class Provincia
    {
        public int nIdUbigeo { get; set; }
        public string sNombre { get; set; }
        public IEnumerable<Distrito> Distritos { get; set; }
    }

    public class Distrito
    {
        public int nIdUbigeo { get; set; }
        public string sNombre { get; set; }
    }
}
