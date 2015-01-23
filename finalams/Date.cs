using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{


    public class Date
    {
        private int day;
        private int month;
        private int year;
       
        public Date(String strDate)
        {
            int dayValue = 0;
            int monthValue = 0;
            int yearValue= 0;
          
            ExtractValuesFromStringDate(strDate, out dayValue, out monthValue, out yearValue);
            
            ////// REMEMBER: Always initiallize year first, then month and then day //////
            if (isValidYear(yearValue))
                this.year = yearValue;

            if (isValidMonth(monthValue))
                this.month = monthValue;

            if (isValidDate(dayValue))
                this.day = dayValue;
        }
        public Date()
        { }
        void ExtractValuesFromStringDate(String strDate, out int  dayValue, out int monthValue, out int yearValue)
        {
            Char[] separator = new Char[1];

            if (strDate.Contains("-"))
                separator[0] = '-';
            if (strDate.Contains("/"))
                separator[0] = '/';
            if (strDate.Contains("."))
                separator[0] = '.';

            String[] dateValues = strDate.Split(separator);

            if (dateValues.Length != 3)
                throw new Exception("Invalid Date (Required Format: DD/MM/YYYY or DD-MM-YYYY or DD.MM.YYYY)!");

            dayValue = int.Parse(dateValues[0]);
            monthValue = int.Parse(dateValues[1]);
            yearValue = int.Parse(dateValues[2]);
        }
    
        public int Day 
        { 
                get { return this.day; }
                set { if(isValidDate(value)) day = value; } 
        }

        public int Month 
        { 
                get { return this.month; } 
                set { if(isValidMonth(value)) this.month = value; } 
        }

        public int Year
        {
            get { return this.year; }
            set { if(isValidYear(value)) this.year = value; }
        }

        bool isValidDate(int date)
        {
            if (this.month == 0)
                throw new Exception("Month Value: 0! Note: Initiallize Year, then Month and then day Value");

            if (date < 1) 
                throw new Exception("Invalid Date (Less than 1).");

            if (date > 31)
                Console.WriteLine(date);
            //throw new Exception("Invalid Date (Greater than 31).");


            else if (this.month.Equals(Constants.MONTH.FEBRUARY))
            {
                if (date > 28 && !isLeapYear()) throw new Exception("Invalid Date (February Date Cannot Be More Than 28!)");
                if (date > 29 && isLeapYear()) throw new Exception("Invalid Date (February Date Cannot Be More than 29!)");
            }

            else if (is30DaysMonth())
            {
                if (date > 30) throw new Exception("The Month: [" + this.month + "]" + ", should have upto 30 days");
            }
            
            return true;
        }

        private bool is30DaysMonth()
        {
            //april, june, sep, nov: months have 30 days
            if ( this.month.Equals(Constants.MONTH.APRIL) ||
                 this.month.Equals(Constants.MONTH.JUNE) ||
                 this.month.Equals(Constants. MONTH.SEPTEMBER) ||
                 this.month.Equals(Constants.MONTH.NOVEMBER)
               )
                return true;

            else 
                return false;

        }

        private bool isLeapYear()
        {
            if ((this.year % 4 == 0 && this.year % 100 != 0) || (this.year % 400 == 0))
                return true;
                
            return false;
        }

        private bool isValidMonth(int month)
        {
            if(this.year == 0)
                throw new Exception("Year Value: 0! Note: Initiallize Year, then Month and then day Value");

            if (month < 1) 
                throw new Exception("Invalid Month (less than 1)");

            if (month > 12)
                throw new Exception("Invalid Month (greater than 12)");

            return true;
        }

        private bool isValidYear(int year)
        {
            int numberOfDigits = year.ToString().Length;
            if (numberOfDigits > 1 && numberOfDigits < 5)
                return true;
            else
            return false;
        }

        public String toString()
        {
            String strDate;
            strDate = this.day + "-" + this.month + "-" + this.year;
            return strDate;
        }

        public String toString(Constants.DateFormat dateFormat)
        {
            String strDate = String.Empty;

            if(dateFormat == Constants.DateFormat.DASH)
                strDate = this.day + "-" + this.month + "-" + this.year;

            else if (dateFormat == Constants.DateFormat.SLASH)
                strDate = this.day + "/" + this.month + "/" + this.year;

            else if (dateFormat == Constants.DateFormat.DOT)
                strDate = this.day + "." + this.month + "." + this.year;
           
            return strDate;
        }
    }
}
