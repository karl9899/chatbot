//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BotProcivicaV3.ConnectionDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Casos
    {
        public int idcaso { get; set; }
        public int idtipocaso { get; set; }
        public int idstatus { get; set; }
        public string folio { get; set; }
        public int idciudadano { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string descripcion { get; set; }
        public string nombre_funcionario { get; set; }
        public string nombre_dependencia { get; set; }
        public System.DateTime fecha_registro { get; set; }
    }
}
