using System.Web.Mvc;

namespace NFlog.WebViewer.Controllers
{
    public class HomeController : Controller
    {
        private IMessageProvider messageProvider;

        public HomeController(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }

        public ActionResult Index()
        {
            return View(messageProvider.GetMessagesForApp("NFlog.TestApp"));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}