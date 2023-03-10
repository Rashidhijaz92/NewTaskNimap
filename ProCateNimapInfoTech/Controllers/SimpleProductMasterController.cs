using ProCateNimapInfoTech.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProCateNimapInfoTech.Controllers
{
    public class SimpleProductMasterController : Controller
    {
      
        NimapContext db = new NimapContext();
        

        public ActionResult ProductDetails()
        {           
            var productsss = db.ProductsTable.ToList();
            return View(productsss);
        }


        // GET SimpleCatMasterCRUD
        public ActionResult CreateProduct()
        {
            return View("CreateUpdateProduct");
        }
        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
            if (ModelState.IsValid == true)
            {
                db.ProductsTable.Add(pro);

                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.CreateMessage = ("<script>alert('Data Saved')</script>");
                    return RedirectToAction("ProductDetails");
                }
                else
                {
                    ViewBag.CreateMessage = ("<script>alert('Data not Saved')</script>");

                }
            }
            return RedirectToAction("ProductDetails");



        }
          
        public ActionResult Edit(int Id)
        {

            var row = db.ProductsTable.Where(modal => modal.PK_ProductId== Id).FirstOrDefault();
            return View(row);

          
        }
        [HttpPost]
        public ActionResult Edit(Product Pro)
        {
            db.Entry(Pro).State = EntityState.Modified;
             db.SaveChanges();
            return RedirectToAction("ProductDetails");
        }

        //Delete Prodct
        public ActionResult Delete(int id)
        {
            var category = db.ProductsTable.Find(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            var Productss = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(Productss);
            db.SaveChanges();
            return RedirectToAction(nameof(ProductDetails));
        }

    }
}





