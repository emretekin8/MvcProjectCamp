using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context c = new Context();

        public ActionResult MyContent(string p)
        {

            p = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();

            var contentValues = contentManager.GetListByWriter(writerIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail= (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId = writerIdInfo;
            p.ContentStatus = true;

            contentManager.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}