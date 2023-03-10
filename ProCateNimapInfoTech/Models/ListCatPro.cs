using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProCateNimapInfoTech.Models
{
    public class ListCatPro
    {
        public int PK_ProductId { get; set; }
        public string ProdctName { get; set; }

        public int PK_CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
 
}