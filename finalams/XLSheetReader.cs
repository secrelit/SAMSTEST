using System;
using System.Collections.Generic;
using System.Linq;
using Secrelit.FAMS;

using System.Text;
namespace finalams
{ 
   public class XLSheetReader
    {
       Secrelit.FAMS.XLSheetReader xlreader;
        DbOperations db;
        DateSeparator dateSaparator;
        public string DateString;
        public int rowcount, columnCount;
    //    public string str;
        public DateCategory dateCategory;
      
       // public DateCategory dcInReader;
        public string name, in_Time, out_Time;
        public int id;

        List<NewStaffMember> nsm = new List<NewStaffMember>();
         
        //XLSheetReader xlreader;
        public int row, column;
        public XLSheetReader(string filepath)
        {
            db = new DbOperations();
            xlreader = new Secrelit.FAMS.XLSheetReader(filepath);
            dateSaparator = new DateSeparator();
            DateString = dateSaparator.StringDate(filepath);
            rowcount = xlreader.getRowCount();
            columnCount = xlreader.getColumnCount();
                        if (columnCount != 4)
                throw new Exception("Invalid no.of Columns (Required: id,name,in_time,out_time)");
     
     
            
        }

       
       public List<NewStaffMember> SaveXLPunchTimesToDB()
        {
           
            for ( row = 1; row < rowcount; row++)
            {
                //XLPunchTimeRecord xl = new XLPunchTimeRecord();
                //xl = xl.ReadRow(row);
                for (column = 1; column <= columnCount; column++)
                {
                    object obj = xlreader.cellReturn(row, column);
                    if (column == 1)
                    { 
                        id = GetPunchID(obj);
                        if (id == -1)
                            goto
                                exit;
                    }
                    else if (column == 2)
                    {
                        name = GetStaffName(obj);

                    }
                    else if (column == 3)
                    {
                        

                        in_Time = GetTime(obj);
                        if (in_Time == null)
                        {
                            in_Time = null;
                        }
                    }
                    else if (column == 4)
                    {

                        out_Time = GetTime(obj);
                        if (out_Time == null)
                            out_Time = null;
                    } 
                }

                //1st Operation 
                if (db.IsNewStaff(name))
                {  //createNewStaff(XLPunchTimeRecord)
                    NewStaffMember newStaffMember = new NewStaffMember();
                    newStaffMember.punchId = id;
                    newStaffMember.Name = name;
                    newStaffMember.PunchDate = new Date(DateString);//we get the date from the exl filename
                    newStaffMember.InTime = new Time(in_Time);
                    newStaffMember.OutTime = new Time(out_Time);
                    nsm.Add(newStaffMember);
                    db.InsertNewStaff(id, name, new Time(in_Time), new Time(out_Time), new Date(DateString));   
                   
                }

                else
                {
                    Time inTimeObject = new Time(in_Time);
                    Time outTimeObject = new Time(out_Time);
                   
                    //getting the department by passing the name to dal
                    string dept = db.ReadDepartment(name);
                    //string remark = "NIL";
                   
                   // = dc.absent;
                    //we have to send name  and department obj of ptd and datecategory to ptd
                    PunchTimeDetails ptd = new PunchTimeDetails();
                    ptd.InTime =new Time(in_Time);
                    ptd.OutTime=new Time(out_Time);


                    //timeframedetails class object for getting the valid in,out,dep,late
                    TimeFrameDetails timeFrameDetails = db.ReadTimeFrameDetails(dept);
                   
                    //TimeFrameDetails timeFrameDetails = new TimeFrameDetails();
                    //timeFrameDetails.InitTimeFrame(dept);
                  //  TimeFrameDetails  timeFrameDetails= db.ReadTimeFrameDetails(dept);
                   
                    
                   
                       // TimeFrameDetails timeFrameDetails = db.ReadTimeFrameDetails(dept);
                

                    //ptd.remark = "";
                    ptd.Remark = "NIL";
             
                    if (in_Time == "" && out_Time == "")
                    {
                        ptd.DateCategory = DateCategory.absent;
                         //dateCategory = DateCategory.Absent;
                    //     ptd.Remark= "NIL";
                    }
                    else if ((in_Time == "" && out_Time != "") || (in_Time != "" && out_Time == ""))
                    {
                        ptd.DateCategory = DateCategory.nopunch;
;
                        
                       ptd.Remark =  "Application Not Recived";
                    }

                    else if (outTimeObject.Hour < timeFrameDetails.ValidOutTime.Hour || outTimeObject.Minute < timeFrameDetails.ValidOutTime.Minute)
                    {
                        ptd.DateCategory = DateCategory.ipt;
                        ptd.Remark = "No Entry";
                    }

                    else if ((inTimeObject.Hour == timeFrameDetails.LateTime.Hour) && (inTimeObject.Minute > 0 )&&(inTimeObject.Minute < timeFrameDetails.LateTime.Minute))
                    {
                        ptd.DateCategory = DateCategory.late;
                        ptd.Remark = "NIL";

                    }
                        //read TimeFrame Details dept pass 

                    else if ((inTimeObject.Hour == timeFrameDetails.ValidInTime.Hour && inTimeObject.Minute > timeFrameDetails.LateTime.Minute) || (inTimeObject.Hour > timeFrameDetails.ValidInTime.Hour))
                    //else if ((inTimeObject.Hour >= (timeFrameDetails.LateTime.Hour) || inTimeObject.Minute > timeFrameDetails.LateTime.Minute))
                    {
                        ptd.DateCategory = DateCategory.ipt;

                        /// datecategory is the property of the ptd how to assign this
                        //ptd.dc =  (DateCategory)dcInReader.ipt;
                        ptd.Remark = "NO Entry ";
                    }


                    else
                    {
                        ptd.DateCategory = DateCategory.punctual;
                    }
                  


                    ptd.InsertIntoDailyPunchTime(ptd, name, new Date(DateString)); 

                } Console.WriteLine("{0} {1} {2} {3} ",id,name,in_Time,out_Time);
           
                
                //1. check name in DB;
                //2-1. if available construct PTD object and send to DB;
                //2-2. else construct of StaffMemberRecord and save it to list<SMR>
            }

            exit : 
           Console.WriteLine("");
            return nsm;
        }

        private string GetTime(object obj)
        {
            string strTime = string.Empty;

            if(obj!=null)
            {
                double time;
                DateTime dateTime;

                if (double.TryParse(obj.ToString(), out time))
                {
                    strTime = DateTime.FromOADate(time).ToShortTimeString();
                   
                }
                else if(DateTime.TryParse(obj.ToString(),out dateTime))
                {
                    strTime = dateTime.ToShortTimeString();
                }
            }

            return strTime;
                        
        }

        private string GetStaffName(object obj)
        {
            if (obj != null)
                return obj.ToString();
            else
                return String.Empty;
        }

        private int GetPunchID(object obj)
        {
           
            int pid = -1;

            if (obj != null)
            {
                pid = int.Parse(obj.ToString());
            }
           

            return pid;
        }
       

       //public class XLPunchTimeRecord
       //{
       //    public string name, in_Time, out_Time;
       //    public int id;

       //    public XLPunchTimeRecord()
       //    {
              
               

       //    }
       //    public XLPunchTimeRecord ReadRow(int i)
       //    {
               
       //    }
       //}
    }
}
