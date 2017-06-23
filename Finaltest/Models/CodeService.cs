using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;


namespace Finaltest.Models
{
    public class CodeService
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
        /// 取得資料
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetCustContactTitle()
        {

            DataTable dt = new DataTable();
            string sql = @"SELECT CodeVal,CodeId
                    FROM dbo.CodeTable
                    where CodeType like 'TITLE'";
            
            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }


            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem()
            {
                Text ="",
                Value =""
            });
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CodeVal"].ToString(),
                    Value= row["CodeVal"].ToString()
                });
            }

            return result;
        }
    }
}