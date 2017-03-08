using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Dashing;
using InstagramClone.App_Start;
using InstagramClone.Models;
using InstagramClone.Models.Domain;

namespace InstagramClone.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: User/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

        // GET: User/Create
        public ActionResult Create()
        {
            var user = new User();
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Username,Password")] User user)
        {
            try
            {
                await session.InsertAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: User/Login
        public ActionResult Login()
        {
            var user = new LoginViewModel();
            return View(user);
 
        }

        [HttpPost]
        public async Task<ActionResult> Login(FormCollection collection)
        {

            var user = await session.Query<User>().Where(u => u.Username == collection["Username"] && u.Password == collection["Password"]).FirstOrDefaultAsync();

            if (user != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        // GET: User/Edit/5
        //        public ActionResult Edit(int id)
        //        {
        //            return View();
        //        }
        //
        //        // POST: User/Edit/5
        //        [HttpPost]
        //        public ActionResult Edit(int id, FormCollection collection)
        //        {
        //            try
        //            {
        //                // TODO: Add update logic here
        //
        //                return RedirectToAction("Index");
        //            }
        //            catch
        //            {
        //                return View();
        //            }
        //        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
