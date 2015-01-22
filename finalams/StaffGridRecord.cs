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
        Time avgWorkingTime, minWorkingTime, maxWorkingTime;
        int noOfAbsentDates, noOfNoPunchDates, noOfIPTDates, noOfLateDates;



        public string Name
        {
            get { return name; }
        }
        public string Dept
        {
            get { return dept; }
        }
        public Time AvgWorkingTime
        {
            get { return avgWorkingTime; }
        }

        public Time MinWorkingTime
        {
            get { return minWorkingTime; }
        }
        public Time MaxWorkingTime
        {
            get { return maxWorkingTime; }
        }
        public int NumberOfAbsentDates
        {
            get { return noOfAbsentDates; }
        }

        public int NumberOfIPTDates
        {
            get { return noOfIPTDates; }
        }

        public int NumberOfNOPunchDates
        {
            get { return noOfNoPunchDates; }
        }

        public int NumberOfLateDates
        {
            get { return noOfLateDates; }

        }

        
        //public String DateCategory
        //{
        //    get { return dateCategory; }
        //}
       //Controller c;
       
        public List<StaffGridRecord> GetStaffGridRecords(DateRange dr,Constants.Status status)
        {
            StaffMember staffMember = new StaffMember();//We need staffmember object for getting list<name> with the specified status 
            StaffAttendanceRecord sar = new StaffAttendanceRecord();//We need sar object to collect and assign all the necessary values for grid to fetch from sar
            //DateCategory dc = new DateCategory();
            List<StaffGridRecord> sgrlist = new List<StaffGridRecord>();
            List<string> namestr = new List<string>();
            namestr = staffMember.GetStaffNamesWithStatus(status);
            //foreach (string name in namestr)
            //{
            //    Console.WriteLine(name);
            //}
       


           foreach (string name in namestr)
           {
               StaffGridRecord sgr = new StaffGridRecord();
               //StaffAttendanceRecord sar = new StaffAttendanceRecord();

               sar.Populate(name, dr);
               sgr.name = name;
               sgr.dept = sar.Dept;
               sgr.avgWorkingTime = sar.AvgWorkingTime;
               sgr.maxWorkingTime = sar.MaxWorkingTime;
               sgr.minWorkingTime  = sar.MinWorkingTime;
               //testing// Console.WriteLine("The values of StaffGridrecord :  " + sgr.Name + " " + sgr.Dept);

               sgr.noOfAbsentDates = sar.GetDateCount(DateCategory.absent);
               sgr.noOfNoPunchDates = sar.GetDateCount(DateCategory.nopunch);// NumberOfDates(name, dc.nopunch, dr);
               sgr.noOfIPTDates = sar.GetDateCount(DateCategory.ipt);//NumberOfDates(name, dc.ipt, dr);
               sgr.noOfLateDates = sar.GetDateCount(DateCategory.late);//NumberOfDates(name, dc.late, dr);

               // Console.WriteLine(sgr.name + " " + sgr.dept + " " + sgr.avgWH + " " + sgr.minWh + " " + sgr.maxWh + " " + sgr.noOfAbsentDates + " " + sgr.noOfIPTDates + " " + sgr.noOfLateDates + " " + sgr.noOfNoPunchDates);
               sgrlist.Add(sgr);
             

           }
           //foreach (StaffGridRecord sgr in sgrlist)
           //{
           //    Console.WriteLine();
           //    Console.WriteLine();
           //    Console.WriteLine();
           //    Console.WriteLine();
           //    Console.WriteLine();
           //    Console.WriteLine("The values staffmember in sgr class::name=" + sgr.Name + "   department =" + sgr.Dept+"avg working hours = "+sgr.avgWorkingHours+" min working hours= " +sgr.minWorkingHours+" max working hours = "+sgr.maxWorkingHours+" no of absent dates = "+sgr.noOfAbsentDates+" no of ipt dates = "+ sgr.noOfIPTDates+" no of no punch dates= "+sgr.noOfNoPunchDates+" no of late dates = "+ sgr.noOfLateDates);
           
           //}
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
