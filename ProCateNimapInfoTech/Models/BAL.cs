using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ProCateNimapInfoTech.Models
{
    public class BAL
    {
        DAL dl = new DAL();
        public List<ListCatPro> Alldetails()
        {

            return dl.Alldetails();
        }
        public List<Category> Catelist()
        {
            return dl.Catelist();

        }
    }
}