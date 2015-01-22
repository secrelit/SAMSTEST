using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    public class Controller
    {
         
        
        //using obj of xlsheetReader  call to method SaveXLPunchTimesToDB() which atomatically fetch d records,
        //and save to d respective tables


        public List<NewStaffMember>  SaveExcelToDatabase(string xlSheetPath)
        {

            //DateSeparator dateSeparator = new DateSeparator();
            //string path= dateSeparator.StringDate(xlSheetPath);
            XLSheetReader xlsheetReader = new XLSheetReader(xlSheetPath);
           
         return xlsheetReader.SaveXLPunchTimesToDB();
        }

        StaffMember staffmember = new StaffMember();
        StaffAttendanceRecord SArecord = new StaffAttendanceRecord();
       StaffGridRecord gridrecord = new StaffGridRecord();
        TimeFrameDetails timeframe = new TimeFrameDetails();

        
       
        public List<StaffGridRecord> GetStaffGridRecords(DateRange dr,Constants.Status status)
        {
         //   StaffGridRecord sgr = new StaffGridRecord();
            List<StaffGridRecord> sgrlist ;//= new List<StaffGridRecord>();
            sgrlist=(new StaffGridRecord()).GetStaffGridRecords(dr,status);
            //Console.WriteLine("The values of Controllergrid :  " + sgrlist[0].Name + " " + sgrlist[0].Dept);
            //Console.WriteLine("The values of Controllergrid :  " + sgrlist[1].Name + " " + sgrlist[1].Dept);
            //Console.WriteLine("The values of Controllergrid :  " + sgrlist[2].Name + " " + sgrlist[2].Dept);
           
         
           
            return sgrlist;
            
        }
        public StaffMember GetStaffMember(string name)
        {
            StaffMember sm = new StaffMember();
            sm.ReadStaffMember(name);

            Console.WriteLine("The values of Controller:  " + sm.Name + " " + sm.Department);
            
            return sm;
        }
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
        public List<StaffAttendanceRecord> GetStaffAttendanceRecords(string name, DateRange dr)
        {
            StaffAttendanceRecord sar = new StaffAttendanceRecord();
            List<StaffAttendanceRecord> staffAttendanceRecordList = new List<StaffAttendanceRecord>();
            List<string> namestr = new List<string>();
            StaffMember staffMember = new StaffMember();
            namestr = staffMember.GetStaffNamesWithStatus(Constants.Status.Working);
            foreach (string n in namestr)
            {
                sar.Populate(name, dr);
                staffAttendanceRecordList.Add(sar);
            }
            return staffAttendanceRecordList;
        }

        //for updations 
        public void UpdateStaffAttendanceRecord(string name, Date date, Time intime, Time outtime, DateCategory dc)
        {
            SArecord.UpdatePTD();
              
        }
        public void UpdateStaffMemberRecord(StaffMember member)
        {
            member.UpdateStaffmemberDetails();
        }

        public void UpdateTimeFrameRecord(TimeFrameDetails frame)
        {
            frame.UpdateTimeFrameDetails();
        }
        
    }
}
