using System;
using System.Collections.Generic;
using System.Text;

namespace finalams
{
    public class Controller
    {
        //StaffMember staffmember = new StaffMember();
        //StaffAttendanceRecord SArecord = new StaffAttendanceRecord();
        //StaffGridRecord gridrecord = new StaffGridRecord();
        //TimeFrameDetails timeframe = new TimeFrameDetails();
       
        public List<StaffGridRecord> GetStaffGridRecords(DateRange dr,Constants.Status status)
        {
         //   StaffGridRecord sgr = new StaffGridRecord();
            List<StaffGridRecord> sgrlist ;//= new List<StaffGridRecord>();
            sgrlist=(new StaffGridRecord()).GetStaffGridRecords(dr,status);

            foreach (StaffGridRecord sgr in sgrlist)
            {
                Console.WriteLine("The values of staffmember  Controller class::name=" + sgr.Name + "   department =" + sgr.Dept + " avgworkingtime= " +sgr.AvgWorkingTime.toString()+ " minworkingtime= " + sgr.MinWorkingTime.toString() +    "maxworking time= " + sgr.MaxWorkingTime.toString());

            }
          
           
            return sgrlist;
            
        }

        //returning staff details of the given name...
        public StaffMember GetStaffMember(string name)
        {
            StaffMember sm = new StaffMember();
            sm.ReadStaffMember(name);

            //Console.WriteLine("The values of Controller:  " + sm.Name + " " + sm.Department);
            
            return sm;
        }

        //returning all staff memeber details of given status ....
        public List<StaffMember> GetStaffMembers(Constants.Status status)
        {
            List<StaffMember> smlist = new List<StaffMember>();
            StaffMember sm = new StaffMember();
            smlist=sm.ReadStaffMembers(status);
            return smlist;
        }


        //public StaffAttendanceRecord GetStaffAttendanceRecord(string name, Date date)
        //{
        //    StaffAttendanceRecord sar = new StaffAttendanceRecord();
        //    sar.Populate(name,date);
        //    sar.GetStaffAttendanceRecord(name,date);
        //    Console.WriteLine("The values of Controllersar :  " + sar.Name + " " + sar.Date.toString() + " " + sar.InTime.toString() + " " + sar.OutTime.toString() + " " + sar.DateCategory.absent + " " + sar.Remark);
            
            
        //    return sar;
            
        //}

        //returning details of a particular staff memeber of the given date range .....
        public StaffAttendanceRecord GetStaffAttendanceRecord(string name, DateRange dr)
        {
            StaffAttendanceRecord sar = new StaffAttendanceRecord();
            sar.Populate(name, dr);
           
            
                Console.WriteLine("The values staffmember in Controller class::name=" + sar.Name + "   department =" + sar.Dept);
            
            
            return sar ;
        }



       //updating all details of a staff memeber .... 
        public void UpdateStaffAttendanceRecord(StaffAttendanceRecord sar)
        {
           // Console.WriteLine("the updated values for dpt in controller::intime = "+sar.InTime.toString()+"outtime = "+sar.OutTime.toString()+"  date = "+sar.Date.toString());
            sar.UpdatePTD();
              
        }

        
        public void UpdateStaffMemberRecord(StaffMember member)
        {
            member.UpdateStaffMemberDetails();
        }

        public void UpdateTimeFrameRecord(TimeFrameDetails frame)
        {
            frame.UpdateTimeFrameDetails();
        }
        
    }
}
