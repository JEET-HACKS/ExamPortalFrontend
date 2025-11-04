using Examportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examportal.Controllers
{
    public class ExamController : Controller
    {
        private ActionDbContext _context = new ActionDbContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signup(Credentials cd)
        {
            string msg=_context.SignUpCredentials(cd.Role,cd.UserId,cd.pswd);

            // Success message JSON me
            return Json(new { success = true, message = "Signup Successfully" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Login(Credentials cd)
        {
            string msg = _context.LoginCredentials(cd.Role, cd.UserId, cd.pswd);

            return Json(new { success = true,
                              message = msg == "ok" ? "Login Successfully" : "Incorrect UserName Or Password" },
                              JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult FormDetails(FormDetails fd)
        {
            //string msg = _context.UserInfo(fd.AcDate,fd.Full_Name,fd.Father_Name,fd.Mother_Name,fd.Email,fd.DOB,fd.Course,fd.Exam_Type,fd.Idproof,fd.State,fd.Idproof,fd);
            string msg = _context.UserInfo(fd);
            return Json(new
            {
                success = true,
                message = msg == "ok" ? "Login Successfully" : "Incorrect UserName Or Password"
            },
                              JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddNewForm(NewFormDetails Anf)
        {
            string msg = _context.AddNewFormDetails(Anf);
            return Json(new
            {
                success = true,
                message = msg == "ok" ? "Login Successfully" : "Incorrect UserName Or Password"
            },
                              JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetFormDetails()
        {
            var msg = _context.GetDetails();
            return Json(new
            {
                success = true,
                msg
            },
            JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult DeleteFormDetails(string id)
        {
            _context.DeleteDetails(id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RetrieveFormDetails(string id)
        {
            var msg=_context.RetrieveDetails(id);
            
            return Json(new { success = true,msg }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetQuickDetails()
        {
            var msg = _context.DashboardDetails();
            return Json(new { success = true, msg }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDashDetails()
        {
            var msg = _context.DashGetDetails();
            return Json(new
            {
                success = true,
                msg
            },
            JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateForm(NewFormDetails fd)
        {
            var msg = _context.UpdateDetails(fd);
            return Json(new
            {
                success = true,
                msg
            },
            JsonRequestBehavior.AllowGet);
        }




    }
}