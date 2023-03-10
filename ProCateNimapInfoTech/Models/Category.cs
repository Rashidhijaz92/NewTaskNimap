using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProCateNimapInfoTech.Models
{
    [Table("tblCategories")]
    public class Category
    {   [Key]
        public int PK_CategoryId { get; set; }
        public String CategoryName { get; set; }




    //    {
    //[Table("tblCategories")]
    //    public class Category
    //    {
    //        [Key]
    //        public int PK_CategoryId { get; set; }
    //        public String CategoryName { get; set; }
    //        public String product { get; set; }
    //        public int ProductId { get; set; }

    //    }
    //    public class CategoryNew
    //    {
    //        public string CategoryName { get; set; }
    //    }

    //}

}
}