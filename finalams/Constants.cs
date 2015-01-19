using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    public class Constants
    {
        public enum Status { All, Working, Resigned, Absconding };
        public enum MONTH { JANUARY, FEBRUARY, MARCH, APRIL, MAY, JUNE, JULY, AUGUST, SEPTEMBER, OCTOBER, NOVEMBER, DECEMBER };
        public enum DateFormat { DASH, SLASH, DOT };

        public static Status GetStatus(String strStatus)
        {

            if (strStatus.Equals(Status.Working.ToString()))
                return Status.Working;

            else if (strStatus.Equals(Status.All.ToString()))
                return Status.All;

            else if (strStatus.Equals(Status.Resigned.ToString()))
                return Status.Resigned;

            else if (strStatus.Equals(Status.Absconding.ToString()))
                return Status.Absconding;
            else
                throw new Exception("Invalid Status: " + strStatus);

        }
        
        
    }
}
