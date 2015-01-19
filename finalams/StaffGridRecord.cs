using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    public class StaffGridRecord
    {
        string name, dept;
       // String dateCategory;
        double avgWorkingHours, minWorkingHours, maxWorkingHours;
        int noOfAbsentDates, noOfNoPunchDates, noOfIPTDates, noOfLateDates;



        public string Name
        {
            get { return name; }
        }
        public string Dept
        {
            get { return dept; }
        }
        public double AvgWorkingHours
        {
            get { return avgWorkingHours; }
        }

        public double MinWorkingHours
        {
            get { return minWorkingHours; }
        }
        public double MaxWorkingHours
        {
            get { return maxWorkingHours; }
        }

        //public String DateCategory
        //{
        //    get { return dateCategory; }
        //}
       //Controller c;
       
        public List<StaffGridRecord> GetStaffGridRecords(DateRange dr,Constants.Status status)
        {
            StaffMember sm = new StaffMember();
            

            StaffAttendanceRecord sar = new StaffAttendanceRecord();
            //DateCategory dc = new DateCategory();
            List<StaffGridRecord> sgrlist = new List<StaffGridRecord>();
            List<string> namestr = new List<string>();
            namestr = sm.GetStaffNamesWithStatus(status);
            //foreach (string name in namestr)
            //{
            //    Console.WriteLine(name);
            //}
       


           foreach (string name in namestr)
           {
               StaffGridRecord sgr = new StaffGridRecord();
               //StaffAttendanceRecord sar = new StaffAttendanceRecord();

               sar.Populate(name, dr);
               sgr.name = sar.Name;
               sgr.dept = sar.Dept;
               sgr.avgWorkingHours = sar.AvgWorkingHours;    
               sgr.maxWorkingHours = sar.MaxWorkingHours;
               sgr.minWorkingHours = sar.MinWorkingHours;
              //testing// Console.WriteLine("The values of StaffGridrecord :  " + sgr.Name + " " + sgr.Dept);

               sgr.noOfAbsentDates = sar.GetDateCount(DateCategory.absent);
               sgr.noOfNoPunchDates = sar.GetDateCount(DateCategory.nopunch);// NumberOfDates(name, dc.nopunch, dr);
               sgr.noOfIPTDates = sar.GetDateCount(DateCategory.ipt);//NumberOfDates(name, dc.ipt, dr);
               sgr.noOfLateDates = sar.GetDateCount(DateCategory.late);//NumberOfDates(name, dc.late, dr);
             
              //// Console.WriteLine(sgr.name + " " + sgr.dept + " " + sgr.avgWH + " " + sgr.minWh + " " + sgr.maxWh + " " + sgr.noOfAbsentDates + " " + sgr.noOfIPTDates + " " + sgr.noOfLateDates + " " + sgr.noOfNoPunchDates);
               sgrlist.Add(sgr);
             

           }
           
           return sgrlist;
        }

        //public int NumberOfDates(string name, string dc, DateRange dr)
        //{
        //    int count = 0;
        //    if (dc == "AbsentDates")
        //    {
        //        count = (new DbOperations()).GetDateCount(name, dc, dr);
        //        //return count;
        //    }
        //    else if (dc == "NoPunchDates")
        //    {
        //        count = (new DbOperations()).GetDateCount(name, dc.nopunch, dr);
        //    }
        //    else if (dc == "IPTDates")
        //    {
        //        count = (new DbOperations()).GetDateCount(name, dc.ipt, dr);
        //    }
        //    else if (dc == "LateDates")
        //    {
        //        count = (new DbOperations()).GetDateCount(name, dc.late, dr);
        //    }
        //    return count;
        //}
     }
}
