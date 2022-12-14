using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.GetList(p);
            //var values = context.Contents.ToList();
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}