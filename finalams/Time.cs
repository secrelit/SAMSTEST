using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace finalams
{
    public class Time
    {
         int h;
       int  m;
       string hourstr, minutestr;
        public Time()
        {
            h = 0;
            m = 0;
        }

        public Time(int minutes)
        {
            if (minutes > 60)
            {
                this.h = minutes / 60;
                this.m = minutes % 60;
                //Console.WriteLine("the values of hours and minutes in the minutes contructor ... hours="+this.h+" minutes ="+this.m);
            }

        }
        public Time(string strtime)
        {
            if (strtime == null || strtime == "" || strtime == " ")
            {
                this.h = -1;
                this.m = -1;
                //Console.WriteLine("Values in constructor...." + this.toString());
                //Console.ReadLine();
                //throw new Exception("InAppropriate Time format::time value is null(--:--)"+this.toString());
                NullHandler();
                //string  hourvalues =null;
                //string  minutevalues = null;


                //ExtractValuesFromStringTime(strtime, out hourvalues, out minutevalues);

            }
            else
            {
                int hourvalue = 0;
                int minutevalue = 0;


                ExtractValuesFromStringTime(strtime, out hourvalue, out minutevalue);
                this.h = hourvalue;
                this.m = minutevalue;
            }
        
        }
        void ExtractValuesFromStringTime(String strTime, out int hourvalue, out int minutevalue)
        {
            Char[] separator = new Char[1];

            if (strTime.Contains(":"))
                separator[0] = ':';
           

            String[] timeValues = strTime.Split(separator);

            //if (timeValues.Length != 2)
                //throw new Exception("Invalid Time (Required Format: HH:MM)!");

            hourvalue = int.Parse(timeValues[0]);
            minutevalue = int.Parse(timeValues[1]);
            //Console.WriteLine("In the Extract value for integer for string time:"+hourvalue+" "+minutevalue);
          }
        void ExtractValuesFromStringTime(String strTime, out string  hourvalues, out string minutevalues)
        {
            Char[] separator = new Char[1];

            if (strTime.Contains(":"))
                separator[0] = ':';


            String[] timeValues = strTime.Split(separator);

            //if (timeValues.Length != 2)
                //throw new Exception("Invalid Time (Required Format: HH:MM)!");

            hourvalues = timeValues[0];
            minutevalues = timeValues[1];

            //Console.WriteLine("In the Extract value for string for string time:" + hourvalues + " " + minutevalues);
        }
        
        public int Hour
        {
            get { return this.h; }
            set { this.h = value; }
        }
        public string HourString
        {
            get { return this.hourstr; }
        }
        public string MinuteString
        {
            get { return this.minutestr; }
        }
        public int Minute
        {
            get { return this.m; }
            set { this.m = value; }
        }

        public string FetchTime()
        {
            string s = toString();

            return s;
        }
        public Time(int h, int m)
        {
            this.h = h;
            this.m = m;
        }
        public static int operator - (Time obj1, Time obj2)
        {
            Time t = new Time();
            t.h = obj2.h - obj1.h;
            t.m = obj2.m - obj1.m;

            if (t.m < 0)
                t.m = t.m * (-1);
            //temp.m = obj1.m - obj2.m;
            while (t.m > 59)
            {
                --t.h;
                t.m -= 60;
            }
            ////for converting hours into minutes,multiply by 60////
            ////for converting minutes into hours,divide by 60////
            //Console.WriteLine("minutes in Time Class before cal " + t.m);

            t.m += t.h*60 ;
            //Console.WriteLine("Hours in Time Class " + t.h);
            //Console.WriteLine("Hours in Time Class*60 " + t.h * 60);
            //Console.WriteLine("minutes in Time Class/60 " + t.m / 60);

            //Console.WriteLine("Minutes in Time Class "+ t.m);
            //Console.WriteLine("miinutes in Time Class/60 " + (double)t.m / 60);

            return t.m;
        }

      

        public String toString()
        {
            String strTime;
            if (this.h == -1 && this.m == -1)
            {
                strTime = this.hourstr + ":" + this.minutestr;
            }
            else
            {
                strTime = this.h + ":" + this.m;
            }
            return strTime;
        }
        public void NullHandler()
        {
            if (this.h == -1 && this.m == -1)
            {
                this.hourstr = "-";
                this.minutestr = "-";
                //new Time("-:-"); 
                 
            }
        }
    }
    
}
