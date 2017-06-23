using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Finaltest.Models
{
    public class OrderService
    {
        /// <summary>
        /// 取得DB連線字串
        /// </summary>
        /// <returns></returns>
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBconnect"].ConnectionString.ToString();
        }

        /// <summary>
        /// 取得客戶資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Customer> GetCustInfor()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT a.CustomerID,a.CompanyName,a.ContactName,(a.ContactTitle+'-'+b.CodeVal) as Contact
                    FROM Sales.Customers a inner join dbo.CodeTable b on a.ContactTitle=b.CodeId
                    where a.ContactTitle=b.CodeId and b.CodeType like 'TITLE'";
            
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            
            List<Models.Customer> result = new List<Customer>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Customer()
                {
                    CustomerID = row["CustomerID"].ToString(),
                    CompanyName = row["CompanyName"].ToString(),
                    ContactName = row["ContactName"].ToString(),
                    ContactTitle = row["Contact"].ToString()
                });
            }
            return result;
        }

        /// <summary>
        /// 取得條件客戶資料
        /// </summary>
        /// <returns></returns>
        public List<Models.Customer> GetCustInforby(Models.Customer arg)
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT a.CustomerID,a.CompanyName,a.ContactName,(a.ContactTitle+'-'+b.CodeVal) as Contact
                    FROM Sales.Customers a inner join dbo.CodeTable b on a.ContactTitle=b.CodeId
                    where (a.ContactTitle=b.CodeId) and 
                          (b.CodeType like 'TITLE') and 
                          (a.CustomerID like @CustomerID or @CustomerID='') and
                          (a.CompanyName like @CompanyName or @CompanyName='') and
                          (a.ContactName like @ContactName or @ContactName='') and
                          (b.CodeVal=@CodeVal or @CodeVal='')";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.Add(new SqlParameter("@CustomerID", arg.CustomerID == null ? string.Empty : '%' + arg.CustomerID + '%'));
                cmd.Parameters.Add(new SqlParameter("@CompanyName", arg.CompanyName == null ? string.Empty : '%' + arg.CompanyName + '%'));
                cmd.Parameters.Add(new SqlParameter("@ContactName", arg.ContactName == null ? string.Empty : '%' + arg.ContactName + '%'));
                cmd.Parameters.Add(new SqlParameter("@CodeVal", arg.CodeVal == null ? string.Empty : arg.CodeVal));

                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }

            List<Models.Customer> result = new List<Customer>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new Customer()
                {
                    CustomerID = row["CustomerID"].ToString(),
                    CompanyName = row["CompanyName"].ToString(),
                    ContactName = row["ContactName"].ToString(),
                    ContactTitle = row["Contact"].ToString()
                });
            }
            return result;
        }
    }
}