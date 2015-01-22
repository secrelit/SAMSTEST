using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    public class TimeFrameDetails
    {
        string dept;
        Time ValidIntime, ValidOuttime,latetime;
        string olddept;
        //member variables representing fields in the tf table 
        bool isDepartmentChanged, isValidInTimeChanged, isValidOutTimeChanged,isValidLateTime;
        DbOperations dbo = new DbOperations();
        public string Department
        { get { return dept; }
            set { this.dept = value;
            isDepartmentChanged = true;
                }
        }

        public Time ValidInTime
        { get { return ValidIntime; }
            set { this.ValidIntime = value;
            isValidInTimeChanged = true;
            }
        }

        public Time ValidOutTime
        { get { return ValidOuttime; }
            set { this.ValidOuttime = value;
            isValidOutTimeChanged = true;
            }
        }
        public Time LateTime
        { get { return latetime; }
            set { this.latetime = value;
            isValidLateTime = true;
            }
        }
        public string OldDepartment
        {
            get { return olddept; }
        }

        public TimeFrameDetails GetTimeFrame( string dept)
        {
            return ((new DbOperations()).ReadTimeFrameDetails(dept));
           // TimeFrameDetails time = new TimeFrameDetails();

           //// time = time.readTimeFrameDetails(dept);//method of Dal
           // time.dept = "mca";
           // time.Intime = new Time("9:01");
           // time.latetime = new Time("4:00");
           // time.latetime = new Time("9:30");
           // return time;
            

        }

        public void Populate(string dept)
        {
            TimeFrameDetails timeframe = (new DbOperations()).ReadTimeFrameDetails(dept);
            this.dept = timeframe.dept;
            this.ValidIntime = timeframe.ValidIntime;
            this.ValidOuttime = timeframe.ValidOuttime;
            this.latetime = timeframe.latetime;
            this.olddept = dept;
        }

      


        public  void UpdateTimeFrameDetails()
        {
            if (isDepartmentChanged)
            {
                dbo.UpdateDepartmentOf(this);
            }
            if (isValidInTimeChanged)
            {
                dbo.UpdateInTimeOf(this);
            }
            if (isValidOutTimeChanged)
            {
                dbo.UpdateOutTimeOf(this);
            }
            if (isValidLateTime)
            {
                dbo.UpdateLateTimeOf(this);
            }
            //throw new NotImplementedException();
        }
    }
}
