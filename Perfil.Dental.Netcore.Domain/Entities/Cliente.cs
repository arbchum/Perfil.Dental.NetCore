using System;

namespace Perfil.Dental.Netcore.Domain.Entities
{
    public class Cliente
    {
        public int nIdCliente { get; set; }
        public string sNombres { get; set; }
        public string sApePaterno { get; set; }
        public string sApeMaterno { get; set; }
        public string sNroDocumento { get; set; }
        public string sSexo { get; set; }
        public DateTime? dFechaNac { get; set; }
        public string sCelular { get; set; }
        public string sTelefono { get; set; }
        public string sCorreo { get; set; }
        public int nIdDistrito { get; set; }
        public string sDireccion { get; set; }
        public int bMayor { get; set; }
    }
    public class ClienteDto
    {
        public int nIdCliente { get; set; }
        public string sCodigo { get; set; }
        public string sNomCliente { get; set; }
        public string sNroDocumento { get; set; }
        public string sEdad { get; set; }
        public string sCelular { get; set; }
        public string sActivo { get; set; }
        public string sFechaReg { get; set; }
    }
}
