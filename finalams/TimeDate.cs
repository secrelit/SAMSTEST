using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    public class TimeDate
    {
        Date d;
        Time inTime,outTime;
        public TimeDate()
        { 
        
        }
        public TimeDate(string date,string inTime,string outTime)
        {
            d = new Date(date);
            this.inTime = new Time(inTime);
            this.outTime = new Time(outTime);

        }
        public Date date
        {
            get { return (d); }
        }

        public Time in_Time
        {
            get { return (inTime); }
        }

        public Time out_Time
        {
            get { return (outTime); }
        }
    }
}
