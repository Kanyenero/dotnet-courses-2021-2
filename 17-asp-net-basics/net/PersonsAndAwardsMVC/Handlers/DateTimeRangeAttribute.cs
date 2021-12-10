using System;
using System.ComponentModel.DataAnnotations;

namespace Handlers
{
    public class DateTimeRangeAttribute : RangeAttribute
    {
        public DateTimeRangeAttribute() : 
            base(typeof(DateTime), DateTime.Now.AddYears(-150).ToShortDateString(), DateTime.Now.ToShortDateString())
        { 
        }
    }
}
