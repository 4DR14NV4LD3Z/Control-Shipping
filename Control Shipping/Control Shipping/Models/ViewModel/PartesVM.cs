using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Control_Shipping.Models.ViewModel
{
    public class PartesVM
    {
        public int Id { get; set; }
        public string CMS { get; set; }
        public string Parte { get; set; }
        public int Fk_Proyecto { get; set; }
        public int Fk_Parte { get; set; }
        public int Fk_Estacion { get; set; }
        public int Cant_Pza { get; set; }
        public bool Estatus { get; set; }
    }
}