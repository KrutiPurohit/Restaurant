using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.Common
{
        public class CurrentDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime == DateTime.Today;
            }
        }
}
