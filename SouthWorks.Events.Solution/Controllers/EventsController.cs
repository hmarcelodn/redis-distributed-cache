using SouthWorks.Events.Solution.Data;
using System.Web.Mvc;

namespace SouthWorks.Events.Solution.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[OutputCache(Duration = 3600, VaryByParam = "iDisplayStart;iDisplayLength;sSearch")]
        public JsonResult GetEvents(int iDisplayStart, int iDisplayLength, string sSearch)
        {
            return Json(EventsDataReader.ReadEvents(int.Parse(Request.QueryString["sEcho"]), iDisplayStart, iDisplayLength, sSearch), JsonRequestBehavior.AllowGet);
        }
    }
}