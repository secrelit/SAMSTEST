using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    class StaffGridRecords
    {
        string name, dept;
        DateCategory dc;
        double avgWH, minWh, maxWh;
        int noOfAbsentDates, noOfNoPunchDates, noOfIPTDates, noOfLateDates;
        StaffAttendanceRecord s = new StaffAttendanceRecord();
        
       
        

        Controller c;
        StaffMember smd = new StaffMember();
        StaffGridRecords sg = new StaffGridRecords();
      //  List<StaffGridRecords> sgr = new List<StaffGridRecords>();

        public List<StaffGridRecords> ReadStaffGridRecords(DateRange dr,Constants.Status status)
        {
            StaffMember sm=new StaffMember();
            List<string> namestr = new List<string>();
            namestr=sm.GetStaffNamesWithStatus(status);
            StaffAttendanceRecord sar = new StaffAttendanceRecord();
            StaffGridRecords sgr = new StaffGridRecords();
            List<StaffGridRecords> sgrlist = new List<StaffGridRecords>();

            foreach (string name in namestr)
            {
                sar= s.GetStaffAttendanceRecords(name,dr);
                sgr.name = sar.Name;
                sgr.dept = sar.Dept;
                sgr.avgWH = sar.AvgWorkingHours;
                sgr.maxWh = sar.MaxWorkingHours;
                sgr.minWh = sar.MinWorkingHours;
                sgr.noOfAbsentDates = sar.Category.absent.Length;
                sgr.noOfNoPunchDates = sar.Category.nopunch.Length;
                sgr.noOfIPTDates = sar.Category.ipt.Length;
                sgr.noOfLateDates = sar.Category.late.Length;
                sgrlist.Add(sgr);
                
            }
            return sgrlist;
        }
     }
}
