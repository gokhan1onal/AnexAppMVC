using AnexAppMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Web.Mvc;

namespace AnexAppMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string W_JSON = "";
            using (WebClient wc = new WebClient())
            {
                W_JSON = wc.DownloadString("http://localhost:63839/api/Reservations");
            }

            List<ReservationModel> W_Reservations = MyJsonToList<ReservationModel>(W_JSON);
            return View(W_Reservations);
        }


        /// <summary>
        /// Add Gökhan ÖNAL
        /// JSON verisini Object Liste çevirir
        /// </summary>
        /// <returns></returns>
        List<pObject> MyJsonToList<pObject>(string pJson)
        {
            try
            {
                return (List<pObject>)JsonConvert.DeserializeObject(pJson, typeof(List<pObject>));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodBase.GetCurrentMethod().Name + "_" + ex.Message);
            }
        }
    }
}