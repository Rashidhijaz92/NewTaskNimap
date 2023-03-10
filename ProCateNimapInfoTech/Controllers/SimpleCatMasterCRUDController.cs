﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProCateNimapInfoTech.Models;
using PagedList;
using PagedList.Mvc;

namespace ProCateNimapInfoTech.Controllers
{
    public class SimpleCatMasterCRUDController : Controller
    { 
        NimapContext db = new NimapContext();
        //public ActionResult Details()
        //{
        //    var categories = db.CategoriesTable.ToList();
        //    return View(categories);
        //}

        public ActionResult Details(int? pageNumber)
        {
            BAL bl = new BAL();
            ModelState.Clear();
            return View(bl.Catelist().ToPagedList(pageNumber ?? 1, 10));
        }


        public ActionResult CreateCat()
        {
            return View("CreateCatUpdateCat");
        }
        [HttpPost]
        public ActionResult CreateCat(Category Cat)
        {
            if (ModelState.IsValid == true)
            {
                db.CategoriesTable.Add(Cat);

                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Saved')</script>");
                    return RedirectToAction("Details");
                }
                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data not Saved')</script>");

                }
            }
            return RedirectToAction("Details");
        }

        //Edit Category
        public ActionResult Edit(int Id)
        {
            var row = db.CategoriesTable.Where(modal => modal.PK_CategoryId == Id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Category CID)
        {
            db.Entry(CID).State = EntityState.Modified;
            int b = db.SaveChanges();
            if (b > 0)
            {
                ViewBag.UpdateMessage = ("<script>alert('Data Updated')</script>");
                return RedirectToAction("Details");
            }
            else
            {
                ViewBag.UpdateMessage = ("<script>alert('Data not Update')</script>");

            }
            return RedirectToAction("Details");
        }


        //Delete category
        public ActionResult Delete(int id)
        {
            var category = db.CategoriesTable.Find(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = db.CategoriesTable.Find(id);
            db.CategoriesTable.Remove(category);
            db.SaveChanges();
            return RedirectToAction(nameof(Details));
        }

    }
}