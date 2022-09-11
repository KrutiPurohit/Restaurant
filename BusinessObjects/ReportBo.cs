using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class ReportBo
    {
        public IEnumerable<SelectListItem> ColumnNames { get; set; }

        [Display(Name = "Column Name")]
        public string ColumnToFilter { get; set; }

        [Display(Name = "Operator")]
        public string  Operator{ get; set; }

        [Display(Name = "Column Value")]
        public string FilterValue { get; set; }

        [Display(Name = "Order By")]
        public string OrderByColumn { get; set; }

        [Display(Name = "Type")]
        public string OrderByType { get; set; }
    }
}
