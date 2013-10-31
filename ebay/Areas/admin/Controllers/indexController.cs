using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoRepository;
using ebay.Helpers;
using ebay.Areas.admin.Models;

namespace ebay.Areas.admin.Controllers
{
    public class indexController : Controller
    {
        //
        // GET: /admin/index/
        [HttpGet]
        public ActionResult Index()
        {
            //AdminMenuModel m = new AdminMenuModel();
            //m.Action = "11111";
            //MongoRepository<AdminMenuModel> mm = new MongoRepository<AdminMenuModel>();
            //DbContext<AdminMenuModel>.Current.Add(m);
            List<AdminMenuModel> lm;
            lm = DbContext<AdminMenuModel>.Current.OrderBy(x => x.IdMenu).ToList() as List<AdminMenuModel>;
            ViewBag.TopMenu = lm;
            return View();
        }
        [HttpPost]
    public ActionResult IndexPost()
        {
            List<AdminMenuModel> lm;
            lm = DbContext<AdminMenuModel>.Current.OrderBy(x => x.IdMenu).ToList() as List<AdminMenuModel>;
            ViewBag.TopMenu = lm;
            return PartialView();
        }
	}
}