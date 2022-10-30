using Control_Shipping.Models.DataModel;
using Control_Shipping.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control_Shipping.Controllers
{
    public class ControlShippingController : Controller
    {
        // GET: ControlShipping
        public ActionResult Aplicacion()
        {
            return View();
        }
        public ActionResult Head()
        {
            return View();
        }

        public string Juliano(DateTime Dia)
        {
            int jul = -1;
            jul = Dia.DayOfYear;
            if (Dia.Hour < 6)
            {
                if (jul == 0)
                    jul = 365;
                else
                    jul = jul - 1;
            }
            int j = 0;
            int.TryParse(Dia.Year.ToString().Substring(Dia.Year.ToString().Length - 1, 1), out j);
            jul = (jul * 10) + j;
            return "" + jul;
        }
        public int Turno(DateTime Dia)
        {
            if (Dia.Hour < 6)
                return 3;
            if (Dia.Hour >= 6 && Dia.Hour < 14)
                return 1;
            if (Dia.Hour >= 14 && Dia.Hour < 21)
                return 2;
            if (Dia.Hour == 21)
            {
                if (Dia.Minute < 30)
                    return 2;
                else
                    return 3;
            }
            return 3;
        }




        public ActionResult GetProjects(int id)
        {
            using (CSEntities db = new CSEntities())
            {
                var list = db.tbl_Proyectos.Select(d => new ProjectoVM
                {
                    Id = d.Id,
                    Proyecto = d.Proyecto,
                    Fecha = d.Fecha,
                    Estatus = d.Estatus
                }).Where(X => X.Estatus == true).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GetEstation(int Id)
        {
            using (CSEntities db = new CSEntities())
            {
                var list = db.tbl_Estaciones.Select(d=>  new EstacionVM { 
                    Id = d.Id, Nombre = d.Nombre,
                    Estatus = d.Estatus, Fk_Proyecto = d.Fk_Proyecto
                }).Where(x => x.Fk_Proyecto == Id) .ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetParts(int Id)
        {
            using (CSEntities db = new CSEntities())
            {
                var data = db.tbl_Estacion_Partes.Join(db.tbl_Partes.Where(y => y.Estatus == true),
                                c => c.Fk_Parte,
                                o => o.Id,
                                (c, o) => new { c, o })
                    .Select(d => new PartesVM
                    {
                        Id = d.c.Id,
                        CMS = d.o.CMS,
                        Parte = d.o.Parte,
                        Cant_Pza = d.o.Cant_Pzas,
                        Fk_Estacion = d.c.Fk_Estacion,
                        Estatus = d.c.Estatus
                    })
                    .Where(x => x.Fk_Estacion == Id) //.o.Estatus == true) 
                    .ToList();

                //var list = db.tbl_Estacion_Partes.Where(x => x.Fk_Estacion == Id).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult btnPart(int Id)
        {
            using (CSEntities db = new CSEntities())
            {
                var data = db.tbl_Estacion_Partes.Join(db.tbl_Partes.Where(y => y.Estatus == true),
                                c => c.Fk_Parte,
                                o => o.Id,
                                (c, o) => new { c, o })
                    .Select(d => new PartesVM
                    {
                        Id = d.c.Id,
                        CMS = d.o.CMS,
                        Parte = d.o.Parte,
                        Cant_Pza = d.o.Cant_Pzas,
                        Fk_Estacion = d.c.Fk_Estacion,
                        Estatus = d.c.Estatus
                    })
                    .Where(x => x.Fk_Estacion == Id && x.Estatus == true)
                    .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetListDMC(int Id)
        {
            using (CSEntities db = new CSEntities())
            {
                var data = db.tbl_Estacion_Partes.Join(db.tbl_Partes.Where(y => y.Estatus == true),
                                c => c.Fk_Parte,
                                o => o.Id,
                                (c, o) => new { c, o })
                    .Select(d => new PartesVM
                    {
                        Id = d.c.Id,
                        CMS = d.o.CMS,
                        Parte = d.o.Parte,
                        Cant_Pza = d.o.Cant_Pzas,
                        Fk_Estacion = d.c.Fk_Estacion,
                        Estatus = d.c.Estatus
                    })
                    .Where(x => x.Fk_Estacion == Id && x.Estatus == true)
                    .ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        //[HttpPost]
        //public ActionResult EvaluaPallet(PalletVM Pallet)
        //{
        //    Pallet.Juliano = Juliano(System.DateTime.Now);
        //    Pallet.Turno = Turno(System.DateTime.Now);
        //    using (CSEntities db = new CSEntities())
        //    {
        //        var data = db.sp_Inserta_DMC(Pallet.Estacion, Pallet.DMC, Pallet.Parte, Pallet.Juliano, Pallet.Turno, Pallet.Fecha).ToList();
        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }

        //}

        //[HttpPost]
        //public ActionResult ObtenerDMCs(PalletVM Pallet)
        //{ 
        //    using (CSEntities db = new CSEntities())
        //    {
        //        var data = db.sp_GetPallet(Pallet.Estacion, Pallet.Parte).ToList();
        //        return Json(data, JsonRequestBehavior.AllowGet);
        //    }

        //}
        public ActionResult UpdatePart(int Id, bool val)
        {
            using (CSEntities db = new CSEntities())
            { db.sp_UpdateParte(Id, val); }
            return null;
        }
    } 
}