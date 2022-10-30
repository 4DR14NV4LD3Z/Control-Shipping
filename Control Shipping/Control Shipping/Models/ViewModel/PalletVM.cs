using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Control_Shipping.Models.ViewModel
{
    public class PalletVM
    {
        public string Estacion { get; set; }
        public string DMC { get; set; }
        public string Parte { get; set; }
        public string Juliano { get; set; }
        public int Turno { get; set; }
        public DateTime Fecha { get; set; }

    }
}