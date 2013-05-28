using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wines.DataAccess;

namespace Wines.Web.Controllers {
    public class WineController : Controller {
        [HttpGet]
        public JsonResult Get() {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            WineDa da = new WineDa();
            return Json(da.GetWines(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetWine(long id) {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            WineDa da = new WineDa();
            Wine wine = da.GetWine(id);

            return Json(wine, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Insert(Wine wine) {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            WineDa da = new WineDa();
            
            Wine result = da.Insert(wine);

            return Json(result);
        }

        [HttpPut]
        public JsonResult Update(long wineId, Wine wine) {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            WineDa da = new WineDa();
            wine.id = wineId;
            int rows = da.Update(wine);

            int status;
            string message;
            if (rows > 0) {
                status = 200;
                message = "updated";
            } else {
                status = 400;
                message = "error";
            }

            return Json(new { Status = status, Message = message });
        }

        [HttpDelete]
        public JsonResult Delete(long wineId) {
            Response.AppendHeader("Access-Control-Allow-Origin", "*");
            WineDa da = new WineDa();
            int rows = da.Delete(wineId);
            
            int status;
            string message;
            if (rows >= 0) {
                status = 200;
                message = "Deleted";
            } else {
                status = 400;
                message = "error";
            }

            return Json(new { Status = status, Message = message });
        }
    }
}
