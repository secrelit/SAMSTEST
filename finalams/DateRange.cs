using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
   public class DateRange
    {
        public Date fromdate;
        public Date todate;
        public DateRange(string date1,string date2)
        {
            fromdate = new Date(date1);
            todate = new Date(date2);
        }
        

    }
}
