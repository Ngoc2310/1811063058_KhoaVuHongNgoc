using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace _1811063058_KhoaVuHongNgoc.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var IsValid = DateTime.TryParseExact(Convert.ToString(value), "MM/dd/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime);

            return (IsValid && dateTime > DateTime.Now);
        }
    }
}