using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Control_Shipping.Models.ViewModel
{
    public class EstacionVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Fk_Proyecto { get; set; }
        public bool Estatus { get; set; }

    }
}