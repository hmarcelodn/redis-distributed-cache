using SouthWorks.Events.Web.Data;
using System.Web.Mvc;

namespace SouthWorks.Events.Web.Controllers
{
    public class EventsController : Controller
    {
        [HttpGet]
        [OutputCache(CacheProfile = "CacheEvents")]
        public JsonResult GetEvents(int iDisplayStart, int iDisplayLength, string sSearch)
        {
            return Json(EventsDataReader.ReadEvents(int.Parse(Request.QueryString["sEcho"]), iDisplayStart, iDisplayLength, sSearch), 
                JsonRequestBehavior.AllowGet);
        }
    }
}