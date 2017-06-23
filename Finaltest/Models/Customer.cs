using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Finaltest.Models
{
    public class Customer
    {

        /// <summary>
        /// 客戶代號
        /// </summary>
        [Required]
        public string CustomerID { get; set; }

        /// <summary>
        /// 客戶公司名稱
        /// </summary>
        [Required]
        public string CompanyName { get; set; }

        /// <summary>
        /// contact名稱
        /// </summary>
        [Required]
        public string ContactName { get; set; }
        /// <summary>
        /// contact標題
        /// </summary>
        [Required]
        public string ContactTitle { get; set; }
        /// <summary>
        /// 建檔日期
        /// </summary>
        [Required]
        public string CreationDate { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Required]
        public string Address { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// 地區
        /// </summary>
        public string Region { get; set; }
        /// <summary>
        /// 郵遞區號
        /// </summary>
        [Required]
        public string PostalCode { get; set; }
        /// <summary>
        /// 鄉鎮
        /// </summary>
        [Required]
        public string Country { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        [Required]
        public string Phone { get; set; }
        /// <summary>
        /// FAX
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// CodeVal
        /// </summary>
        public string CodeVal { get; set; }

        /// <summary>
        /// bool
        /// </summary>
        public bool indexboo { get; set; }
    }
}
