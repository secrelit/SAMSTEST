using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    public class PunchTimeDetails
    {
        string name;
        Date date;
        Time inTime, outTime;
      //public  DateCategory dc;
        string dateCategory;
        string remark;
        //member variables representing fields in the dpt table 
        //List<PunchTimeDetails> ptd = new List<PunchTimeDetails>();
        bool isDateChanged, isInTimeChanged, isOutTimeChanged, isDateCategoryChanged, isRemarkChanged;

    

        //DbOperations dbo = new DbOperations();

        public string Name
        {
            get { return name; }
            set
            {
                this.name = value;
               // isNameChanged = true;
            }
        }
        public Date Date
        { get { return date; }

            set { this.date = value;
            isDateChanged = true;
                }
        }

        public Time InTime
        { get { return inTime; }
            set { this.inTime = value;
            isInTimeChanged = true;
            
            }
        }

        public Time OutTime
        { get { return outTime; }

            set { this.outTime = value;
            isOutTimeChanged = true;
            }
        }
        public string DateCategory
        { get { return dateCategory; }
            set { this.dateCategory = value;
            isDateCategoryChanged = true;
                }
        
        }
        public string  Remark
        { get { return remark; }
            set { this.remark = value;

            isRemarkChanged = true;
            }
        }


        public static PunchTimeDetails GetPunchTimeDetails(string name, Date date)
        {

            return (new DbOperations()).ReadPunchTimeDetails(name, date);
        }
        
        public static List<PunchTimeDetails> GetPunchTimeDetails(string name, DateRange dr)
        {
            return (new DbOperations()).ReadPunchTimeDetails(name, dr);
        }
        public void Populate(string name, Date date)
        {
            // punchtimedetails det= GetPunchTumeDetails(name,date);
            DbOperations dbo = new DbOperations();
            PunchTimeDetails det = dbo.ReadPunchTimeDetails(name, date);//method of dal
            this.name = det.name;
            this.date = det.date;
            this.inTime = det.inTime;
            this.outTime = det.outTime;
            this.dateCategory = det.dateCategory;
            this.remark = det.remark;
        }

        //public void Populate(string name, DateRange dr)
        //{
        //    punchtimedetails det = GetPunchTumeDetails(name, date);
        //    DbOperations dbo = new DbOperations();
        //    List<PunchTimeDetails> ptdlist = dbo.ReadPunchTimeDetails(name, dr);//method of dal
        //    for (int i = 0; i <= ptdlist.Count; i++)
        //        this.name = ptdlist[i].name;
        //    this.date = ptdlist[i].date;
        //    this.inTime = ptdlist[i].inTime;
        //    this.outTime = ptdlist[i].outTime;
        //    this.dc = ptdlist[i].dc;
        //    this.remark = det.remark;
        //}

        public void UpdateDailyPunchTimeTable()
        {
            DbOperations dbo = new DbOperations();
            

            if (isInTimeChanged)
            {
                
                dbo.UpdateInTimeOf(this);
            }
            if (isOutTimeChanged)
            {
                
                dbo.UpdateOutTimeOf(this);
            }


            if (isDateCategoryChanged)
            {
                Console.WriteLine("the updated values for dpt in ptd::date = " + this.Date.toString());
                dbo.UpdateDateCategoryOf(this);
            }
        }
        internal void InsertIntoDailyPunchTime(PunchTimeDetails ptd, string name, finalams.Date date)
        {
            (new DbOperations()).InsertToDailyPunchTime(ptd, name, date);
            //throw new NotImplementedException();
        }
   
    }
}
