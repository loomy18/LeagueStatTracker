using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LOLSA.Models;

namespace LOLSA.Controllers
{
    public class GameController : Controller
    {
        //private StatDataEntities1 entities = new StatDataEntities1();

        //
        // GET: /Game/
        public ActionResult Index()
        {
            //return View(entities.GameTables.ToList());
            return View();
        }
          public ActionResult Details(int id)

        {

            return View();

        }

 

        //

        // GET: /Customers/Create

        


 

        public ActionResult Create()

        {

            return View();

        }

 

        //

        // POST: /Customers/Create

 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Create(FormCollection collection)

        {

            try

            {

                // TODO: Add insert logic here

 

                return RedirectToAction("Index");

            }

            catch

            {

                return View();

            }

        }

 

        //

        // GET: /Customers/Edit/5

 

        public ActionResult Edit(int id)

        {

            return View();

        }

 

        //

        // POST: /Customers/Edit/5

 

        [AcceptVerbs(HttpVerbs.Post)]

        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

	}
}