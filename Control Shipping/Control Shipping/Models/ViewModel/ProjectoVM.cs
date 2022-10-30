using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Control_Shipping.Models.ViewModel
{
    public class ProjectoVM
    {
        public int Id { get; set; }
        public string Proyecto { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Estatus { get; set; }

    }
}