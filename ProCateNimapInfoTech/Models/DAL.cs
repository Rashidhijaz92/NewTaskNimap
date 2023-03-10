using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProCateNimapInfoTech.Models
{
    public class DAL
    {
        public List<ListCatPro> Alldetails()
        {
            string CON = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            List<ListCatPro> procatLsit = new List<ListCatPro>();

            SqlConnection con = new SqlConnection(CON);
            SqlCommand cmd = new SqlCommand("Select P.PK_ProductId AS ProductId, P.ProdctName AS ProductName, C.PK_CategoryId AS CategoryId, C.CategoryName AS CategoryName From [tblproducts] P Inner Join [tblCategories] C ON P. PK_ProductId = C.PK_CategoryId", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                procatLsit.Add(
                        new ListCatPro
                        {
                            PK_ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProdctName = Convert.ToString(reader["ProductName"]),
                            PK_CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            CategoryName = Convert.ToString(reader["CategoryName"])

                        });

            }
            con.Close();

            return procatLsit;
        }
        public List<Category> Catelist()
        {
            string CON = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            List<Category> procatLsit = new List<Category>();

            SqlConnection con = new SqlConnection(CON);
            SqlCommand cmd = new SqlCommand("CatList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                procatLsit.Add(
                        new Category
                        {
                           
                            PK_CategoryId = Convert.ToInt32(reader["PK_CategoryId"]),
                            CategoryName = Convert.ToString(reader["CategoryName"])

                        });

            }
            con.Close();

            return procatLsit;
        }
    }
}
