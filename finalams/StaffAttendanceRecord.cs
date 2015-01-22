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
        //double  avgWorkingHours, minWorkingHours, maxWorkingHours;
        Time avgWorkingTime,minWorkingTime,maxWorkingTime;
         //DateRange dr;
        Date date;//dateofjoining;
        Time Intime, Outtime;
        //string remark;
        int punchid;
        int noOfCLDates, noOfODDates, noOfMLDates, noOfCODates, noOfVacationDates, noOfPunctualDates;
        Constants.Status status;
        //string  dc;//=new DateCategory();
        List<PunchTimeDetails> punchTimeDetails;// = new List<PunchTimeDetails>();

        bool  isDateChanged, isInTimeChanged, isOutTimeChanged;

       
        public string Name
        {
            get { return name; }
        }
        public string Dept
        {
            get { return dept; }
        }
        public Date Date
        {
            get { return date;
            
            }

            set { this.date = value;
            isDateChanged = true;
            }

        }
        public Time InTime
        {
            get { return Intime; }
            set { this.Intime = value;
            isInTimeChanged = true;
            }
        }
        public Time OutTime
        { get { return Outtime; }
            set {

                this.Outtime = value;
                isOutTimeChanged = true;
            }
        }

        public int NumberOfClDates
        {
            get { return noOfCLDates; }
        }

        public int NumberOfOdDates
        {
            get { return noOfODDates; }
        }

        public int NumberOfMlDates
        {
            get { return noOfMLDates; }
        }

        public int NumberOfCoDates
        {
            get { return noOfCODates; }
        }

        public int NumberOfVacationDates
        {
            get { return noOfVacationDates; }
        }

        public int NumberOfPunctualDates
        {
            get { return noOfPunctualDates; }
        }
        //public string  DateCategory
        //{
        //    get { return dc; }
        //}
        //public string Remark
        //{
        //    get { return remark; }
        //}
        public Time AvgWorkingTime
        {
            get { return avgWorkingTime; }
        }
       
        public Time  MinWorkingTime
        {
            get { return minWorkingTime; }
        }
        public Time  MaxWorkingTime
        {
            get { return maxWorkingTime; }
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
            //Console.WriteLine("The values staffmember in sar class::name=" + staffMember.Name + "  department =" + staffMember.Department + " date of joing =" + staffMember.DateOfJoining.toString() + " status = " + staffMember.Status + " punchid =" + staffMember.PunchId);
            this.name = name;
            //// init department////
            this.dept = staffMember.Department;
            
            //// init status ////
            this.status = staffMember.Status;

            //// init TimeFrame ////
            this.timeframe = (new TimeFrameDetails()).GetTimeFrame(this.dept);

            //// init PTD list ////
            punchTimeDetails = PunchTimeDetails.GetPunchTimeDetails(name, dr);
           
            this.noOfCLDates = GetDateCount(DateCategory.cl);
            this.noOfODDates = GetDateCount(DateCategory.od);
            this.noOfMLDates = GetDateCount(DateCategory.ml);
            this.noOfCODates = GetDateCount(DateCategory.co);
            this.noOfVacationDates = GetDateCount(DateCategory.vacation);
            this.noOfPunctualDates = GetDateCount(DateCategory.punctual);
            this.CalculateAvgMinMax();

            return this;
   
        }
                                                    
       
        public StaffAttendanceRecord GetStaffAttendanceRecord(string name, Date date)
        {
            
            PunchTimeDetails punchtimedetail= PunchTimeDetails.GetPunchTimeDetails(name, date);
         
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
                { minMinutes = minutes;
                if (minMinutes < 0)
                    minMinutes = minMinutes * -1;
                minutes = minutes * -1;
                }
                
                if (maxMinutes < minutes)
                    maxMinutes = minutes;
                totalMinutes += minutes;
            }

            
            minWorkingTime=new Time(minMinutes);
            maxWorkingTime=new Time(maxMinutes);
            int avg;
            avg = totalMinutes / punchTimeDetails.Count;
            avgWorkingTime = new Time(avg );

            Console.WriteLine("in sar min working time=" + minWorkingTime.Hour +":"+minWorkingTime.Minute+ " max wkg time= " + maxWorkingTime.Hour +":"+maxWorkingTime.Minute+ " avg wkg time=" + avgWorkingTime.Hour+":"+avgWorkingTime.Minute);

        }


        public void UpdatePTD()
        {
            PunchTimeDetails punchTime = new PunchTimeDetails();
            if (isDateChanged)
            {
                punchTime.Date = this.date;
            }
            if (isInTimeChanged)
            {
                punchTime.InTime = this.Intime;
            
            }
            if (isOutTimeChanged)
            {
                punchTime.OutTime = this.Outtime;
            
            }
            punchTime.UpdateDailyPunchTimeTable();

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
