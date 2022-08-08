using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InspireEdu.Models;

namespace InspireEdu.Controllers
{
    public class BlogController : Controller
    {
        InspireModel db = new InspireModel();
        [HttpGet]
        public ActionResult BlogList()
        {
            var bloglist = db.Blogtbls.ToList();
            return View(bloglist);
        }
        [HttpPost]
        public ActionResult BlogList(Blogtbl bg)
        {
            return View();
        }

        // GET: Blog
        [HttpGet]
        public ActionResult Uploadblog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Uploadblog(Blogtbl bg)
        {
            string fileName = Path.GetFileNameWithoutExtension(bg.ImageFile.FileName);
            string extension = Path.GetExtension(bg.ImageFile.FileName);
            bg.BlogImage = "../Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("../Images/"), fileName);
            bg.ImageFile.SaveAs(fileName);
            using (InspireModel db = new InspireModel())
            {  
                db.Blogtbls.Add(bg);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMsg = "Blog Saved Successfully..!";
            return View();
        }
        [HttpGet]
        public ActionResult BlogEdit(int id)
        {
            using (InspireModel db = new InspireModel())
            {
                return View(db.Blogtbls.Where(x => x.BlogId.Equals(id)).FirstOrDefault());
            }
        }
        [HttpPost]
        public ActionResult BlogEdit(int id,Blogtbl bg)
        {
            try
            {
                using (InspireModel db = new InspireModel())
                {
                    db.Entry(bg).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("BlogList", "Blog");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult BlogDelete(int id)
        {
            using (InspireModel db= new InspireModel())
            {
                return View(db.Blogtbls.Where(x => x.BlogId.Equals(id)).FirstOrDefault());
            } 
        }
        [HttpPost]
        public ActionResult BlogDelete(int id,Blogtbl bg)
        {
            try
            {
                using (InspireModel db = new InspireModel())
                {
                    bg=db.Blogtbls.Where(x=>x.BlogId.Equals(id)).FirstOrDefault();
                    db.Blogtbls.Remove(bg);
                    db.SaveChanges();
                }
                return RedirectToAction("BlogList", "Blog");
            }
            catch
            {
                return View();
            }
        }
    }
}