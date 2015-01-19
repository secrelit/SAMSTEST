using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
     public class StaffAttendanceRecord
    {
       
        string name,  dept;
        TimeFrameDetails timeframe;
        //StaffMember smd;
        double  avgWorkingHours, minWorkingHours, maxWorkingHours;
        //DateRange dr;
        //Date date;//dateofjoining;
        //Time Intime, Outtime;
        //string remark;
        int punchid;
        Constants.Status status;
        //string  dc;//=new DateCategory();
        List<PunchTimeDetails> punchTimeDetails;// = new List<PunchTimeDetails>();

       // int noOfAbsentDates, noOfNoPunchDates, noOfIPTDates, noOfLateDates;
       
        public string Name
        {
            get { return name; }
        }
        public string Dept
        {
            get { return dept; }
        }
        //public Date Date
        //{
        //    get { return date; }

        //}
        //public Time InTime
        //{
        //    get { return Intime; }
        //}
        //public Time OutTime
        //{ get { return Outtime; } }

        //public string  DateCategory
        //{
        //    get { return dc; }
        //}
        //public string Remark
        //{
        //    get { return remark; }
        //}
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
      /*  public void Populate(string name, Date date)
        {
           // List<PunchTimeDetails> ptds = new List<PunchTimeDetails>();
            // same for smd and timeframe
            p.Populate(name, date);
              // Populating the sar object with ptd 
            this.name=p.Name;
            this.date=p.Date;
            this.Intime=p.InTime;
            this.Outtime= p.OutTime;
           // this.dc = p.DateCategory;
            this.remark=p.Remark;
           
        }
        */

        public StaffAttendanceRecord Populate(string name, DateRange dr)
        {
            
            StaffMember staffMember = new StaffMember();
            staffMember.Populate(name);

            //// init department////
            this.dept = staffMember.Department;
            
            //// init status ////
            this.status = staffMember.Status;

            //// init TimeFrame ////
            this.timeframe = (new TimeFrameDetails()).GetTimeFrame(this.dept);

            //// init PTD list ////
            punchTimeDetails = PunchTimeDetails.GetPunchTimeDetails(name, dr);
           
            //// init avg, min, max working hrs ////
            this.CalculateAvgMinMax();

            return this;
   
        }
                                                    
        //
        public StaffAttendanceRecord GetStaffAttendanceRecord(string name, Date date)
        {
            //StaffAttendanceRecord s1;
            PunchTimeDetails punchtimedetail= PunchTimeDetails.GetPunchTimeDetails(name, date);
          //  this.name = punchtimedetail.Name;
           // this.date = punchtimedetail.Date;
            //this.Intime = punchtimedetail.InTime;
            //this.Outtime = punchtimedetail.OutTime;
            //this.dc = punchtimedetail.DateCategory;
            //this.remark = punchtimedetail.Remark;

          //  Console.WriteLine("The values of sar:  " + this.Name + " " + this.date.toString() + " " + this.Intime.toString() + " " + this.Outtime.toString() + " " + this.dc.absent + " " + this.remark);
              
            //s1 = punchtimedetail;
            //p.Populate(name, date);
            
            ////  Console.WriteLine(p.Name);
            //List<StaffMember> members = new List<StaffMember>();
            //StaffMember sm = new StaffMember();
            //sm.ReadStaffMember(name);
            
            //s1.dept = sm.Department;
            //s1.name = sm.Name;
            //s1.status = sm.Status;
            //s1.dateofjoining = sm.DateOfJoining;
            //s1.punchid = sm.PunchId;
            ////maintaining punchtimedetails data in sar object
            //s1.Intime = p.InTime;
            //s1.Outtime = p.OutTime;
            //s1.dc = p.DateCategory;
            //s1.remark = p.Remark;
            return this;
        }

        public void CalculateAvgMinMax()
        {
            int minMinutes = 0;
            int maxMinutes = 0;
            int totalMinutes = 0;

            foreach (PunchTimeDetails punchTime in this.punchTimeDetails)
            {
                int minutes = punchTime.OutTime - punchTime.InTime;
                
                if (minMinutes > minutes)
                    minMinutes = minutes;
                
                if (maxMinutes < minutes)
                    maxMinutes = minutes;
                totalMinutes += totalMinutes;
            }

            this.minWorkingHours = minMinutes / 60; 
            this.maxWorkingHours = maxMinutes / 60;
            this.avgWorkingHours = totalMinutes / punchTimeDetails.Count;

        }


        public void UpdatePTD()
        { 
        
        }

        public int GetDateCount(String dateCategory)
        {
            int count = 0;

            foreach (PunchTimeDetails ptd in this.punchTimeDetails)
            {
                if (ptd.DateCategory.Equals(dateCategory))
                    count++;
                    
            }

            return count;
        }
    }
}
