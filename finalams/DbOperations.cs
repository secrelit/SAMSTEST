using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
namespace finalams
{
  //public  class DbOperations
  //  {
  //    public string dept;
  //    public string status;
       

  //      // Inserting value in DailyPunchTime table called from xlSheetReader
  //      public void InsertToDailyPunchTime(string staffName,Date date,PunchTimeDetails ptd)
  //      {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
          
  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();

  //          string str = "insert into daily_punch_time values('" + staffName + "'," +date.Day  + "," + date.Month + "," + date.Year + "," + ptd.InTime.Hour + "," + ptd.InTime.Minute + "," + ptd.OutTime.Hour+ "," +  ptd.OutTime.Minute+",'"+ptd.DateCategory+"','"+ptd.Remark+"')";
  //          cmd = new MySqlCommand(str, con);
  //          cmd.ExecuteNonQuery();
  //          Console.WriteLine("values inserted");
  //          con.Close();
  //      }

  //      //checking for new staff member
  //      public Boolean IsNewStaff(string name)
  //      {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //          MySqlDataReader reader; 

  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();

  //          string nameString = "Select name from staff_member where name =@name ";

  //          cmd = new MySqlCommand(nameString, con);

  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@name";
  //          param.Value = name;
  //          cmd.Parameters.Add(param);
  //          reader = cmd.ExecuteReader();
            
  //          if (!reader.HasRows)
  //          {
  //              con.Close();
  //              return true;
  //          }

            
  //          else
  //          {
  //            con.Close();
  //          return false;
  //          }
                
  //      }

  //      //Reading the department from staff_member table for the given name
  //      public string ReadDepartment(string name)
  //      {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //          MySqlDataReader reader;
  //                     con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();
  //          string nameString = "Select dept from staff_member where name =@name ";

  //          cmd = new MySqlCommand(nameString, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@name";
  //          param.Value = name;
  //          cmd.Parameters.Add(param);
  //          reader = cmd.ExecuteReader();
  //          while (reader.Read())
  //          {
  //              dept = reader.GetString(1);
               
  //          }
  //          con.Close();
  //          return dept;
            
  //      }

  //      //Reading the status from staff_member table for the given name
  //      public string ReadStatus(string name)
  //      {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //          MySqlDataReader reader;

  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();

  //          string nameString = "Select status from staff_member where name =@name ";

  //          cmd = new MySqlCommand(nameString, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@name";
  //          param.Value = name;
  //          cmd.Parameters.Add(param);
  //          reader = cmd.ExecuteReader();
  //          while (reader.Read())
  //          {
  //              status = reader.GetString(2);
  //          }
  //          con.Close();
  //          return status;
  //      }


  //      //inserting values in NewStaffMember ...Method Called From XLSheetReader..
  //     //why nt date_time object...........
  //      public void InsertNewStaff(int id, string name, Time in_time, Time out_time, Date date)
  //      {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //          // MySqlDataReader reader;

  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();
  //          string str = "insert into new_staff_member values("+id+",'"+name+"',+"+in_time.Hour+","+in_time.Minute+","+out_time.Hour+","+out_time.Minute+","+date.Day+","+date.Month+","+date.Year+")";
  //          cmd = new MySqlCommand(str, con);
  //          cmd.ExecuteNonQuery();
  //          Console.WriteLine("values inserted");
  //          con.Close();
  //      }

  //    //revert to form geting all dates of given date range of a particular faculty and of that date category .....
  //     //why nt date range object
  //    public List<Date> ReadDatesFromDailyPunchTime(String dateCategory, String Name, DateRange dr)
  //      {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //          MySqlDataReader reader;

  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();
            
  //          int fromDay = dr.fromdate.Day;
  //          int fromMonth =dr. fromdate.Month;
  //          int fromYear = dr.fromdate.Year;

  //          int toDay = dr.todate.Day;
  //          int toMonth = dr.todate.Month;
  //          int toYear = dr.todate.Year;

  //          string str = "select day,month,year from daily_punch_time where name=@Name AND date_category=@dateCategory AND day BETWEEN @fromDay and @toDay AND month BETWEEN @fromMonth and @toMonth AND year BETWEEN @fromYear and @toYear";
  //          cmd = new MySqlCommand(str, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@Name";
  //          param.Value = Name;

  //          param.ParameterName = "@dateCategory";
  //          param.Value = dateCategory;

  //          param.ParameterName = "@fromDay";
  //          param.Value = fromDay;

  //          param.ParameterName = "@toDay";
  //          param.Value = toDay;

  //          param.ParameterName = "@fromMonth";
  //          param.Value = fromMonth;


  //          param.ParameterName = "@toMonth";
  //          param.Value = toMonth;

  //          param.ParameterName = "@fromYear";
  //          param.Value = fromYear;

  //          param.ParameterName = "@toYear";
  //          param.Value = toYear;

  //          cmd.Parameters.Add(param);

  //          reader = cmd.ExecuteReader();

  //          List<Date> dates = new List<Date>();

  //          while (reader.Read())
  //          {
  //               Date d = new Date();
  //               d.Day= int.Parse(reader.GetString(1));
  //               d.Month = int.Parse(reader.GetString(2));
  //               d.Year =int.Parse(reader.GetString(3));
  //               dates.Add(d);
                 
  //          }
  //          con.Close();
  //          return dates;
           

  //      }
        
  //    //geting the no of date count of given dateCategory
  //    //need to be execute..separatory
  //    public int GetDateCount(string Name, string  dateCategory, DateRange dr)
  //      {
  //          MySqlConnection con = new MySqlConnection("server=localhost;User Id=root;password=admin;Persist Security Info=True;database=attendence");
  //        int fromDay = dr.fromdate.Day;
  //          int fromMonth =dr. fromdate.Month;
  //          int fromYear = dr.fromdate.Year;

  //          int toDay = dr.todate.Day;
  //          int toMonth = dr.todate.Month;
  //          int toYear = dr.todate.Year;
  //          string str = "select count(date_category) from daily_punch_time where name=@Name AND date_catogory=@dateCategory AND day BETWEEN @fromDay and @toDay AND month BETWEEN @fromMonth and @toMonth AND year BETWEEN @fromYear and @toYear";
  //          MySqlCommand cmd = new MySqlCommand(str, con);

  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@Name";
  //          param.Value = Name;

  //          param.ParameterName = "@dateCategory";
  //          param.Value = dateCategory;

  //          param.ParameterName = "@fromDay";
  //          param.Value = fromDay;

  //          param.ParameterName = "@toDay";
  //          param.Value = toDay;

  //          param.ParameterName = "@fromMonth";
  //          param.Value = fromMonth;


  //          param.ParameterName = "@toMonth";
  //          param.Value = toMonth;

  //          param.ParameterName = "@fromYear";
  //          param.Value = fromYear;

  //          param.ParameterName = "@toYear";
  //          param.Value = toYear;


  //          cmd.Parameters.Add(param);

  //         int count=(int)cmd.ExecuteScalar();

  //         con.Close();
  //         return count;
           
  //      }

  //    //returning list of string which contains name of the given status 
  //    public  List<string> ReadStaffNameWithStatus(string Status)
  //    {
  //        MySqlConnection con;
  //          MySqlCommand cmd;
  //          MySqlDataReader reader;

  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();

  //          string str = "select name from staff_member where status=@Status";
  //          cmd = new MySqlCommand(str, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@Status";
  //          param.Value = Status;
  //          cmd.Parameters.Add(param);

  //          List<string> StaffNameList = new List<string>();
  //          reader = cmd.ExecuteReader();
  //          while (reader.Read())
  //          {
  //              StaffNameList.Add(reader.GetString(0));
              
  //          }
  //          con.Close();
  //          return StaffNameList;
  //    }
  //   //returning the list of members of given department
  //    public List<StaffMember> ReadStaffMemberDetailsUsingDept(string dept)
  //    {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //          MySqlDataReader reader;

  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();

  //          string str = "select name,status,date_of_joining,punch_id from staff_member where dept=@dept";
  //          cmd = new MySqlCommand(str, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@dept";
  //          param.Value = dept;
  //          cmd.Parameters.Add(param);

  //          List<StaffMember> staffMemberDetails = new List<StaffMember>();
  //          reader = cmd.ExecuteReader();
  //          while (reader.Read())
  //          {
  //             StaffMember smDetail = new StaffMember();
  //              smDetail.Name = reader.GetString(0);
  //              //smDetail.Department =reader.GetString(1);
  //              smDetail.Status= Constants.GetStatus(reader.GetString(2));
  //              smDetail.DateOfJoining=new Date(reader.GetString(3));
  //              smDetail.PunchId=int.Parse( reader.GetString(4));
  //              staffMemberDetails.Add(smDetail);
  //          }
  //          con.Close();
  //          return staffMemberDetails;
  //      }
  //    //returning the time frame details of the given department....
  //    public TimeFrameDetails ReadTimeFrameDetails(string dept)
  //      {

  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //          MySqlDataReader reader;

  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();

  //          string nameString = "Select valid_in_time,valid_out_time,late_time from time_frame where dept =@dept ";

  //          cmd = new MySqlCommand(nameString, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@dept";
  //          param.Value = dept;
  //          cmd.Parameters.Add(param);
  //          reader = cmd.ExecuteReader();
  //          TimeFrameDetails timeFrame=new TimeFrameDetails();
  //          while (reader.Read())
  //          {
  //              timeFrame.ValidInTime = new Time(reader.GetString(1));
  //              timeFrame.ValidOutTime = new Time(reader.GetString(2));
  //              timeFrame.LateTime = new Time(reader.GetString(3));
  //          }
  //          con.Close();
  //          return timeFrame;
           
  //      }
      
  //    //returning the time frame details of the given name ....//
  //    //query pending......
  //    public TimeFrameDetails ReadTimeFrame(string name)
  //    {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //          MySqlDataReader reader;

  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();

  //          string nameString = "Select  where dept =@dept ";

  //          cmd = new MySqlCommand(nameString, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@";
  //          param.Value = dept;
  //          cmd.Parameters.Add(param);
  //          reader = cmd.ExecuteReader();
  //          TimeFrameDetails timeFrame = new TimeFrameDetails();
  //          while (reader.Read())
  //          {
  //              timeFrame.Department = reader.GetString(0);
  //              timeFrame.ValidInTime = (Time)reader[1];
  //              timeFrame.ValidOutTime = (Time)reader[2];
  //              timeFrame.LateTime = (Time)reader[3];
  //          }
  //          con.Close();
  //          return timeFrame;
            
  //     }
   
  //    //Pending for creating trigger .
  //    public void UpdateDepartmentOf(TimeFrameDetails timeFrame)
  //      {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //      //    MySqlDataReader reader;
  //          string newDept=timeFrame.Department;
  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();
  //          //nt complete
  //          //create trigger 
  //          string nameString = "update time_frame set dept=@newDept where dept=@newDept ";

  //          cmd = new MySqlCommand(nameString, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@newDept";
  //          param.Value =newDept;
  //          cmd.Parameters.Add(param);
  //          cmd.ExecuteNonQuery();

  //        con.Close();
  //      }

  //    //updating InTime of time frame table 
  //    public void UpdateInTimeOf(TimeFrameDetails time_Frame)
  //     {
  //      MySqlConnection con;
  //      MySqlCommand cmd;
  //      //MySqlDataReader reader;
  //      string validInTime = time_Frame.ValidInTime.toString();
  //      //doubt....
  //      //int inHours = inTime.Hour;
  //      //int inMins = inTime.Minute;

  //      con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //      con.Open();

  //      string nameString = "update time_frame  set  valid_in_time where valid_in_time=@validInTime";

  //      cmd = new MySqlCommand(nameString, con);
  //      MySqlParameter param = new MySqlParameter();
  //      param.ParameterName = "@inTime";
  //      param.Value =validInTime;
  //      cmd.Parameters.Add(param);
  //      cmd.ExecuteNonQuery();

  //     Console.WriteLine("In Time Upadated");
  //      con.Close();
  //   }

  //    //updating out time of time frame table 
  //    public void UpdateOutTimeOf(TimeFrameDetails time_Frame)
  //   {
  //       MySqlConnection con;
  //       MySqlCommand cmd;
  //      // MySqlDataReader reader;
  //       string validOutTime = time_Frame.ValidOutTime.toString();
  //       //doubt....
  //       //int outHours =outTime.Hour;
  //       //int outMins = outTime.Minute;

  //       con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //       con.Open();

  //       string nameString = "update time_frame  set  valid_out_time where valid_out_time=@validOutTime ";

  //       cmd = new MySqlCommand(nameString, con);
  //       MySqlParameter param = new MySqlParameter();
  //       param.ParameterName = "@outTime";
  //       param.Value = validOutTime;
  //      cmd.Parameters.Add(param);
  //      cmd.ExecuteNonQuery();

       
  //       Console.WriteLine("Out Time Upadated");
  //       con.Close();
  //   }
  //    //updating late time of time frame table 
  //    public void UpdateLateTimeOf(TimeFrameDetails time_Frame)
  //     {
  //         MySqlConnection con;
  //         MySqlCommand cmd;
  //         //MySqlDataReader reader;
  //         string lateTime = time_Frame.LateTime.toString();
  //         //doubt....
  //         //int outHours = lateTime.Hour;
  //         //int outMins = lateTime.Minute;

  //         con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //         con.Open();

  //         string nameString = "update time_frame  set  late_time where late_time=@lateTime  ";

  //         cmd = new MySqlCommand(nameString, con);
  //         MySqlParameter param = new MySqlParameter();
  //         param.ParameterName = "@lateTime";
  //         param.Value = lateTime;
  //         cmd.Parameters.Add(param);
  //         cmd.ExecuteNonQuery();

  //         Console.WriteLine("Late Time Upadated");
  //         con.Close();
  //     }
  //    //updating in time of daily punch time table 
  //    public void UpdateInTimeOf(PunchTimeDetails punchTimeDetails)
  //     {
  //         MySqlConnection con;
  //         MySqlCommand cmd;
  //        // MySqlDataReader reader;
          
  //         int inTimeHours = int.Parse(punchTimeDetails.InTime.Hour.ToString());
  //         int inTimeMinutes = int.Parse(punchTimeDetails.InTime.Minute.ToString());


  //         con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //         con.Open();

  //         string nameString = "update daily_punch_time set in_hours=@inTimeHours And in_mins=@inTimeMinutes where in_hours=@inTimeHours AND in_mins=@inTimeMinutes";

  //         cmd = new MySqlCommand(nameString, con);
  //         MySqlParameter param = new MySqlParameter();
  //         param.ParameterName = "@inTimeHours";
  //         param.Value = inTimeHours;

  //         param.ParameterName = "@inTimeMintues";
  //         param.Value = inTimeMinutes;

  //         cmd.Parameters.Add(param);
  //         cmd.ExecuteNonQuery();
  //         Console.WriteLine("In Time Updated");
  //         con.Close();
  //     }
  //     //updating out time of daily punch time table 
  //    public void UpdateOutTimeOf(PunchTimeDetails punchTimeDetails)
  //       {
  //           MySqlConnection con;
  //           MySqlCommand cmd;
  //          // MySqlDataReader reader;
            
  //           int outHours = int.Parse(punchTimeDetails.OutTime.Hour.ToString());
  //           int outMins = int.Parse(punchTimeDetails.OutTime.Minute.ToString());

  //           con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //           con.Open();

  //           string nameString = "update daily_punch_time set out_hours=@outHours And out_mins=@outMins where out_hours=@outHours AND out_mins=@outMins";

  //           cmd = new MySqlCommand(nameString, con);
  //           MySqlParameter param = new MySqlParameter();
  //           param.ParameterName = "@outHours";
  //           param.Value = outHours;

  //           param.ParameterName = "@outMins";
  //           param.Value = outMins;

  //           cmd.Parameters.Add(param);
  //           cmd.ExecuteNonQuery();
  //           Console.WriteLine("Out Time Updated");
  //           con.Close();
  //       }
  //  //updating dateCategory of daily punch time table
  //     public void UpdateDateCategoryOf(PunchTimeDetails punchTimeDetails)
  //      {
  //          MySqlConnection con;
  //          MySqlCommand cmd;
  //         // MySqlDataReader reader;
       
  //          string dateCategory = punchTimeDetails.DateCategory;
  //          string remark = punchTimeDetails.Remark;
  //          con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //          con.Open();

  //          string nameString = "update daily_punch_time set date_category=@dateCategory And remark=@remark where date_category=@dateCategory";

  //          cmd = new MySqlCommand(nameString, con);
  //          MySqlParameter param = new MySqlParameter();
  //          param.ParameterName = "@dateCategory";
  //          param.Value = dateCategory;

  //          param.ParameterName = "@remark";
  //          param.Value = remark;

  //          cmd.Parameters.Add(param);
  //           cmd.ExecuteNonQuery();


  //          Console.WriteLine("Date Category Updated");
  //          con.Close();
  //      }

  //     public PunchTimeDetails ReadPunchTimeDetails(string name, Date date)
  //     {
  //         MySqlConnection con;
  //         MySqlCommand cmd;
  //         MySqlDataReader reader;

  //         int day = date.Day;
  //         int month = date.Month;
  //         int year = date.Year;

  //         con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //         con.Open();

  //         string nameString = "Select in_hours,in_mins,out_hours,out_mins,date_category,remark from daily_punch_time where name=@name and day=@day and month=@month and year=@year  ";

  //         cmd = new MySqlCommand(nameString, con);
  //         MySqlParameter param = new MySqlParameter();
  //         param.ParameterName = "@name";
  //         param.Value = name;

  //         param.ParameterName = "@day";
  //         param.Value = day;

  //         param.ParameterName = "@month";
  //         param.Value = month;

  //         param.ParameterName = "@year";
  //         param.Value = year;
  //         cmd.Parameters.Add(param);
  //         PunchTimeDetails punchTimeDeail = new PunchTimeDetails();
  //         reader = cmd.ExecuteReader();

  //         while (reader.Read())
  //         {
  //             punchTimeDeail.InTime.Hour = int.Parse(reader.GetString(4));
  //             punchTimeDeail.InTime.Minute = int.Parse(reader.GetString(5));
  //             punchTimeDeail.OutTime.Hour = int.Parse(reader.GetString(6));
  //             punchTimeDeail.OutTime.Minute = int.Parse(reader.GetString(7));
  //             punchTimeDeail.DateCategory = reader.GetString(8);
  //             punchTimeDeail.Remark = reader.GetString(9);
  //         }
  //         con.Close();
  //         return punchTimeDeail;
          
  //     }

  //     public List<PunchTimeDetails> ReadPunchTimeDetails(string name, DateRange dr)
  //     {
  //         MySqlConnection con;
  //         MySqlCommand cmd;
  //         MySqlDataReader reader;

  //         con = new MySqlConnection("server=localhost;User Id=root;password=admin;database=attendence;Persist Security Info=True");
  //         con.Open();

  //        int fromDay = dr.fromdate.Day;
  //          int fromMonth =dr. fromdate.Month;
  //          int fromYear = dr.fromdate.Year;

  //          int toDay = dr.todate.Day;
  //          int toMonth = dr.todate.Month;
  //          int toYear = dr.todate.Year;

  //         string str = "select in_hours,in_mins,out_hours,out_mins,date_category,remark from daily_punch_time where name=@name AND day BETWEEN @fromDay and @toDay AND month BETWEEN @fromMonth and @toMonth AND year BETWEEN @fromYear and @toYear";
  //         cmd = new MySqlCommand(str, con);
  //         MySqlParameter param = new MySqlParameter();
  //         param.ParameterName = "@name";
  //         param.Value = name;

  //         param.ParameterName = "@fromDay";
  //         param.Value = fromDay;

  //         param.ParameterName = "@toDay";
  //         param.Value = toDay;

  //         param.ParameterName = "@fromMonth";
  //         param.Value = fromMonth;


  //         param.ParameterName = "@toMonth";
  //         param.Value = toMonth;

  //         param.ParameterName = "@fromYear";
  //         param.Value = fromYear;

  //         param.ParameterName = "@toYear";
  //         param.Value = toYear;

  //         cmd.Parameters.Add(param);

  //         List<PunchTimeDetails> ptDetails = new List<PunchTimeDetails>();

  //         reader = cmd.ExecuteReader();
  //         while (reader.Read())
  //         {
  //             PunchTimeDetails ptDetail = new PunchTimeDetails();

  //             ptDetail.InTime.Hour = int.Parse(reader.GetString(4));
  //             ptDetail.InTime.Minute = int.Parse(reader.GetString(5));
  //             ptDetail.OutTime.Hour = int.Parse(reader.GetString(6));
  //             ptDetail.OutTime.Minute = int.Parse(reader.GetString(7));
  //             ptDetail.DateCategory = reader.GetString(8);
  //             ptDetail.Remark = reader.GetString(9);
  //             ptDetails.Add(ptDetail);
  //         }
  //         con.Close();
  //         return ptDetails;
           
  //     }



  //     internal void UpdateDepartmentOf(StaffMember staffMember)
  //     {
  //         throw new NotImplementedException();
  //     }

  //     internal void UpdateStatusOf(StaffMember staffMember)
  //     {
  //         throw new NotImplementedException();
  //     }

  //     internal List<StaffMember> ReadStaffMemberDetails(Constants.Status status)
  //     {
  //         throw new NotImplementedException();
  //     }

  //     internal StaffMember ReadStaffMemberDetail(string name)
  //     {
  //         throw new NotImplementedException();
  //     }
  //  }
    public class DbOperations
    {
        public string dept;
        public string status;

        private string connectionString = "server=localhost;User Id=root;password=root;database=attendence;Persist Security Info=True";


        // Inserting value in DailyPunchTime table called from xlSheetReader
        public void InsertToDailyPunchTime(PunchTimeDetails ptd, string name, finalams.Date date)
        {
            MySqlConnection con;
            MySqlCommand cmd;

            con = new MySqlConnection(connectionString);
            con.Open();

            string str = "insert into daily_punch_time values('" + name + "'," + date.Day + "," + date.Month + "," + date.Year + ",'" +ptd.InTime.toString()+ "','" +ptd.OutTime.toString()+ "','" + ptd.DateCategory + "','" + ptd.Remark + "')";
            cmd = new MySqlCommand(str, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("values inserted");
            con.Close();
        }

        //checking for new staff member
        public Boolean IsNewStaff(string name)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "Select name from staff_member where name =@name ";

            cmd = new MySqlCommand(nameString, con);

            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@name";
            param.Value = name;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();

            if (!reader.HasRows)
            {
                con.Close();
                return true;
            }


            else
            {
                con.Close();
                return false;
            }

        }

        //Reading the department from staff_member table for the given name
        public string ReadDepartment(string name)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;
            con = new MySqlConnection(connectionString);
            con.Open();
            string nameString = "Select dept from staff_member where name =@name ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@name";
            param.Value = name;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dept = reader.GetString("dept");

            }
            con.Close();
            return dept;

        }

        //Reading the status from staff_member table for the given name
        public string ReadStatus(string name)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "Select status from staff_member where name =@name ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@name";
            param.Value = name;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                status = reader.GetString(2);
            }
            con.Close();
            return status;
        }


        //inserting values in NewStaffMember ...Method Called From XLSheetReader..
        public void InsertNewStaff(int id, string name, Time in_time, Time out_time, Date date)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            // MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();
            string str = "insert into new_staff_member values('" + name + "','" + in_time.toString() + "','" + out_time.toString() + "'," + date.Day + "," + date.Month + "," + date.Year + "," + id + ")";
            //string str = "insert into new_staff_member values("+id+",'"+name+"',+"+in_time.Hour+","+in_time.Minute+","+out_time.Hour+","+out_time.Minute+","+date.Day+","+date.Month+","+date.Year+")";
            cmd = new MySqlCommand(str, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("values inserted");
            con.Close();
        }

        //revert to form geting all dates of given date range of a particular faculty and of that date category .....
        public List<Date> ReadDatesFromDailyPunchTime(String dateCategory, String Name, DateRange dr)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            int fromDay = dr.fromdate.Day;
            int fromMonth = dr.fromdate.Month;
            int fromYear = dr.fromdate.Year;

            int toDay = dr.todate.Day;
            int toMonth = dr.todate.Month;
            int toYear = dr.todate.Year;

            string str = "select day,month,year from daily_punch_time where name=@Name AND date_category=@dateCategory AND day BETWEEN @fromDay and @toDay AND month BETWEEN @fromMonth and @toMonth AND year BETWEEN @fromYear and @toYear";
            cmd = new MySqlCommand(str, con);
            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@Name";
            param1.Value = Name;

            MySqlParameter param2 = new MySqlParameter();
            param2.ParameterName = "@dateCategory";
            param2.Value = dateCategory;

            MySqlParameter param3 = new MySqlParameter();
            param3.ParameterName = "@fromDay";
            param3.Value = fromDay;

            MySqlParameter param4 = new MySqlParameter();
            param4.ParameterName = "@toDay";
            param4.Value = toDay;

            MySqlParameter param5 = new MySqlParameter();
            param5.ParameterName = "@fromMonth";
            param5.Value = fromMonth;

            MySqlParameter param6 = new MySqlParameter();
            param6.ParameterName = "@toMonth";
            param6.Value = toMonth;

            MySqlParameter param7 = new MySqlParameter();
            param7.ParameterName = "@fromYear";
            param7.Value = fromYear;

            MySqlParameter param8 = new MySqlParameter();
            param8.ParameterName = "@toYear";
            param8.Value = toYear;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);

            reader = cmd.ExecuteReader();

            List<Date> dates = new List<Date>();

            while (reader.Read())
            {
                Date d = new Date();
                d.Day = int.Parse(reader.GetString(1));
                d.Month = int.Parse(reader.GetString(2));
                d.Year = int.Parse(reader.GetString(3));
                dates.Add(d);

            }
            con.Close();
            return dates;


        }

        //geting the no of date count of given dateCategory
        //need to be execute..separatory
        public int GetDateCount(string Name, string dateCategory, DateRange dr)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();

            int fromDay = dr.fromdate.Day;
            int fromMonth = dr.fromdate.Month;
            int fromYear = dr.fromdate.Year;

            int toDay = dr.todate.Day;
            int toMonth = dr.todate.Month;
            int toYear = dr.todate.Year;

            string str = "select date_category from daily_punch_time where name=@Name AND date_category=@dateCategory AND day BETWEEN @fromDay and @toDay AND month BETWEEN @fromMonth and @toMonth AND year BETWEEN @fromYear and @toYear";
            MySqlCommand cmd = new MySqlCommand(str, con);

            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@Name";
            param1.Value = Name;

            MySqlParameter param2 = new MySqlParameter();
            param2.ParameterName = "@dateCategory";
            param2.Value = dateCategory;

            MySqlParameter param3 = new MySqlParameter();
            param3.ParameterName = "@fromDay";
            param3.Value = fromDay;

            MySqlParameter param4 = new MySqlParameter();
            param4.ParameterName = "@toDay";
            param4.Value = toDay;

            MySqlParameter param5 = new MySqlParameter();
            param5.ParameterName = "@fromMonth";
            param5.Value = fromMonth;

            MySqlParameter param6 = new MySqlParameter();
            param6.ParameterName = "@toMonth";
            param6.Value = toMonth;

            MySqlParameter param7 = new MySqlParameter();
            param7.ParameterName = "@fromYear";
            param7.Value = fromYear;

            MySqlParameter param8 = new MySqlParameter();
            param8.ParameterName = "@toYear";
            param8.Value = toYear;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);
            cmd.Parameters.Add(param8);

           // int count = (int)cmd.ExecuteScalar();
            int count = 0;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = count + 1;
            }
            
            con.Close();
            return count;

        }

        //returning list of string which contains name of the given status 
        public List<string> ReadStaffNameWithStatus(string Status)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string str = "select name from staff_member where status=@Status";
            cmd = new MySqlCommand(str, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@Status";
            param.Value = Status;
            cmd.Parameters.Add(param);

            List<string> StaffNameList = new List<string>();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StaffNameList.Add(reader.GetString(0));

            }
            con.Close();
            return StaffNameList;
        }

        //returning the list of members of given department
        public List<StaffMember> ReadStaffMemberDetailsUsingDept(string dept)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string str = "select name,status,date_of_joining,punch_id from staff_member where dept=@dept";
            cmd = new MySqlCommand(str, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@dept";
            param.Value = dept;
            cmd.Parameters.Add(param);

            List<StaffMember> staffMemberDetails = new List<StaffMember>();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                StaffMember smDetail = new StaffMember();
                smDetail.Name = reader.GetString(0);
                //smDetail.Department =reader.GetString(1);
                smDetail.Status = Constants.GetStatus(reader.GetString(2));
                smDetail.DateOfJoining = new Date(reader.GetString(3));
                smDetail.PunchId = int.Parse(reader.GetString(4));
                staffMemberDetails.Add(smDetail);
            }
            con.Close();
            return staffMemberDetails;
        }
        //returning the time frame details of the given department....
        public TimeFrameDetails ReadTimeFrameDetails(string dept)
        {

            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "Select valid_in_time,valid_out_time,late_time from time_frame where dept=@dept ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@dept";
            param.Value = dept;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();
            TimeFrameDetails timeFrame = new TimeFrameDetails();
           // while (reader.Read())
            reader.Read();
            {
                timeFrame.ValidInTime = new Time(reader.GetString("valid_in_time"));
                timeFrame.ValidOutTime = new Time(reader.GetString("valid_out_time"));
                timeFrame.LateTime = new Time(reader.GetString("late_time"));
            }

          //  Console.WriteLine(timeFrame.ValidInTime.T + timeFrame.ValidOutTime.ToString() + timeFrame.LateTime.ToString());
            con.Close();
            return timeFrame;

        }

        //returning the time frame details of the given name ....//
        //query pending......
        //select dept from staffmemeber of the given name and the in outside query check validtimes for that dept of that name 
        public TimeFrameDetails ReadTimeFrame(string name)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "Select  where dept =@dept ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@";
            param.Value = dept;
            cmd.Parameters.Add(param);
            reader = cmd.ExecuteReader();
            TimeFrameDetails timeFrame = new TimeFrameDetails();
            while (reader.Read())
            {
                timeFrame.Department = reader.GetString(0);
                timeFrame.ValidInTime = (Time)reader[1];
                timeFrame.ValidOutTime = (Time)reader[2];
                timeFrame.LateTime = (Time)reader[3];
            }
            con.Close();
            return timeFrame;

        }

        //Pending for creating trigger .
        //triggr will require two parameters the modified and the old one
        public void UpdateDepartmentOf(TimeFrameDetails timeFrame, string oldDept)
        {
            MySqlConnection con;
            MySqlCommand cmd;

            string newDept = timeFrame.Department;
            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update time_frame set dept=@newDept where dept=@oldDept ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@newDept";
            param.Value = newDept;
            cmd.Parameters.Add(param);

            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@oldDept";
            param1.Value = oldDept;
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery();
            //Console.WriteLine("DepartMent Updated");

            con.Close();
        }

        //updating InTime of time frame table 
        public void UpdateInTimeOf(TimeFrameDetails time_Frame)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            //MySqlDataReader reader;
            string validInTime = time_Frame.ValidInTime.toString();
            string dept = time_Frame.Department;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update time_frame  set  valid_in_time=@validInTime where dept=@dept";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@validInTime";
            param.Value = validInTime;
            cmd.Parameters.Add(param);

            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@dept";
            param1.Value = dept;
            cmd.Parameters.Add(param1);

            cmd.ExecuteNonQuery();

          //  Console.WriteLine("In Time Upadated");
            con.Close();
        }

        //updating out time of time frame table 
        public void UpdateOutTimeOf(TimeFrameDetails time_Frame)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            // MySqlDataReader reader;
            string validOutTime = time_Frame.ValidOutTime.toString();
            string dept = time_Frame.Department;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update time_frame  set  valid_out_time=@validOutTime where dept=@dept ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@validOutTime";
            param.Value = validOutTime;
            cmd.Parameters.Add(param);
            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@dept";
            param1.Value = dept;
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery();


            Console.WriteLine("Out Time Upadated");
            con.Close();
        }
        //updating late time of time frame table 
        public void UpdateLateTimeOf(TimeFrameDetails time_Frame)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            //MySqlDataReader reader;
            string lateTime = time_Frame.LateTime.toString();
            string dept = time_Frame.Department;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update time_frame  set  late_time=@lateTime where dept=@dept ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@lateTime";
            param.Value = lateTime;
            cmd.Parameters.Add(param);

            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@dept";
            param1.Value = dept;
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery();
        }
        //updating in time of daily punch time table 
        public void UpdateInTimeOf(PunchTimeDetails punchTimeDetails)
        {
            MySqlConnection con;
            MySqlCommand cmd;

            int inTimeHours = int.Parse(punchTimeDetails.InTime.Hour.ToString());
            int inTimeMinutes = int.Parse(punchTimeDetails.InTime.Minute.ToString());
            string name = punchTimeDetails.Name;


            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update daily_punch_time set in_hours=@inTimeHours And in_mins=@inTimeMinutes where name=@name";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@inTimeHours";
            param1.Value = inTimeHours;

            MySqlParameter param2 = new MySqlParameter();
            param2.ParameterName = "@inTimeMintues";
            param2.Value = inTimeMinutes;
            MySqlParameter param3 = new MySqlParameter();
            param3.ParameterName = "@name";
            param3.Value = name;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.ExecuteNonQuery();
            Console.WriteLine("In Time Updated");
            con.Close();
        }
        //updating out time of daily punch time table 
        public void UpdateOutTimeOf(PunchTimeDetails punchTimeDetails)
        {
            MySqlConnection con;
            MySqlCommand cmd;

            int outHours = int.Parse(punchTimeDetails.OutTime.Hour.ToString());
            int outMins = int.Parse(punchTimeDetails.OutTime.Minute.ToString());
            string name = punchTimeDetails.Name;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update daily_punch_time set out_hours=@outHours And out_mins=@outMins where name=@name";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@outHours";
            param1.Value = outHours;

            MySqlParameter param2 = new MySqlParameter();
            param2.ParameterName = "@outMins";
            param2.Value = outMins;

            MySqlParameter param3 = new MySqlParameter();
            param3.ParameterName = "@name";
            param3.Value = name;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Out Time Updated");
            con.Close();
        }
        //updating dateCategory of daily punch time table
        public void UpdateDateCategoryOf(PunchTimeDetails punchTimeDetails)
        {
            MySqlConnection con;
            MySqlCommand cmd;

            string dateCategory = punchTimeDetails.DateCategory;
            string remark = punchTimeDetails.Remark;
            string name = punchTimeDetails.Name;
            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update daily_punch_time set date_category=@dateCategory And remark=@remark where name=@name";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@dateCategory";
            param1.Value = dateCategory;
            MySqlParameter param2 = new MySqlParameter();
            param2.ParameterName = "@remark";
            param2.Value = remark;

            MySqlParameter param3 = new MySqlParameter();
            param2.ParameterName = "@name";
            param2.Value = name;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param2);
            cmd.ExecuteNonQuery();


            Console.WriteLine("Date Category Updated");
            con.Close();
        }

        public PunchTimeDetails ReadPunchTimeDetails(string name, Date date)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            int day = date.Day;
            int month = date.Month;
            int year = date.Year;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "Select in_time,out_time,date_category,remark from daily_punch_time where name=@name and day=@day and month=@month and year=@year  ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@name";
            param1.Value = name;

            MySqlParameter param2 = new MySqlParameter();
            param2.ParameterName = "@day";
            param2.Value = day;

            MySqlParameter param3 = new MySqlParameter();
            param3.ParameterName = "@month";
            param3.Value = month;

            MySqlParameter param4 = new MySqlParameter();
            param4.ParameterName = "@year";
            param4.Value = year;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);

            PunchTimeDetails punchTimeDeail = new PunchTimeDetails();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                punchTimeDeail.InTime = new Time(reader.GetString("in_time"));
              
                punchTimeDeail.OutTime =new Time(reader.GetString("out_time"));
             
                punchTimeDeail.DateCategory = reader.GetString("date_category");
                punchTimeDeail.Remark = reader.GetString("remark");
            }

            //Console.WriteLine(punchTimeDeail.InTime.Hour);
            con.Close();

            
            return punchTimeDeail;

        }

        public List<PunchTimeDetails> ReadPunchTimeDetails(string name, DateRange dr)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            int fromDay = dr.fromdate.Day;
            int fromMonth = dr.fromdate.Month;
            int fromYear = dr.fromdate.Year;

            int toDay = dr.todate.Day;
            int toMonth = dr.todate.Month;
            int toYear = dr.todate.Year;

            string str = "select in_time,out_time,date_category,remark from daily_punch_time where name=@name AND day BETWEEN @fromDay and @toDay AND month BETWEEN @fromMonth and @toMonth AND year BETWEEN @fromYear and @toYear";
            cmd = new MySqlCommand(str, con);
            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@name";
            param1.Value = name;

            MySqlParameter param2 = new MySqlParameter();
            param2.ParameterName = "@fromDay";
            param2.Value = fromDay;

            MySqlParameter param3 = new MySqlParameter();
            param3.ParameterName = "@toDay";
            param3.Value = toDay;

            MySqlParameter param4 = new MySqlParameter();
            param4.ParameterName = "@fromMonth";
            param4.Value = fromMonth;


            MySqlParameter param5 = new MySqlParameter();
            param5.ParameterName = "@toMonth";
            param5.Value = toMonth;

            MySqlParameter param6 = new MySqlParameter();
            param6.ParameterName = "@fromYear";
            param6.Value = fromYear;

            MySqlParameter param7 = new MySqlParameter();
            param7.ParameterName = "@toYear";
            param7.Value = toYear;

            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.Parameters.Add(param3);
            cmd.Parameters.Add(param4);
            cmd.Parameters.Add(param5);
            cmd.Parameters.Add(param6);
            cmd.Parameters.Add(param7);

            List<PunchTimeDetails> ptDetails = new List<PunchTimeDetails>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PunchTimeDetails ptDetail = new PunchTimeDetails();

                ptDetail.InTime= new Time(reader.GetString("in_time"));
                //ptDetail.InTime.Minute = int.Parse(reader.GetString(5));
                ptDetail.OutTime = new Time(reader.GetString("out_time"));
                //ptDetail.OutTime.Minute = int.Parse(reader.GetString(7));
                ptDetail.DateCategory = reader.GetString("date_category");
                ptDetail.Remark = reader.GetString("remark");
                ptDetails.Add(ptDetail);
            }
            con.Close();
            return ptDetails;

        }

        public StaffMember ReadStaffMemberDetail(string name)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "Select dept,status,date_of_joining,punch_id from staff_member where name=@name";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@name";
            param.Value = name;

            cmd.Parameters.Add(param);
            StaffMember staffMember = new StaffMember();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string status;
                staffMember.Department = reader.GetString("dept");
                staffMember.PunchId = int.Parse(reader.GetString("punch_id"));
                staffMember.DateOfJoining = new Date(reader.GetString("date_of_joining"));
              
                   staffMember.Status = Constants.GetStatus(reader.GetString("status"));
         

                
            }

           // Console.WriteLine("day= "+staffMember.DateOfJoining.Day+" month = "+staffMember.DateOfJoining.Month+" year = "+staffMember.DateOfJoining.Year);
           
            con.Close();
            return staffMember;
        }

        public List<StaffMember> ReadStaffMemberDetails(string status)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "Select name,dept,date_of_joining,punch_id from staff_member where status=@status";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@status";
            param.Value = status;

            cmd.Parameters.Add(param);
            List<StaffMember> staffMemberDetails = new List<StaffMember>();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                StaffMember staffMember = new StaffMember();
                staffMember.Name = reader.GetString("name");
                staffMember.Department = reader.GetString("dept");
                staffMember.DateOfJoining = new Date(reader.GetString("date_of_joining"));
                staffMember.PunchId = int.Parse(reader.GetString("punch_id"));
                staffMemberDetails.Add(staffMember);
            }
            con.Close();
            return staffMemberDetails;
        }
        public void UpdateDepartmentOf(StaffMember staffMember)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            string dept = staffMember.Department;
            string name = staffMember.Name;
            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update staff_member set dept=@dept where name=@name";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@dept";
            param.Value = dept;
            cmd.Parameters.Add(param);

            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@name";
            param1.Value = name;
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery();
        //    Console.WriteLine("Department Updated");
            con.Close();
        }
        public void UpdateStatusOf(StaffMember staffMember)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            string status = staffMember.Status.ToString();
            string name = staffMember.Name;
            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update staff_member set status=@status where name=@name";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@status";
            param.Value = status;
            cmd.Parameters.Add(param);

            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@name";
            param1.Value = name;
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Status Updated");
            con.Close();
        }

        //trigger wil be fired ......create trigger in staff_memeber table 
        //call from staffmember class .......creatre it in staffmember
        public void updateNameOf(StaffMember staffMemeber)
        {
            MySqlConnection con;
            MySqlCommand cmd;

            string name = staffMemeber.Name;
            int punchId = staffMemeber.PunchId;
            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update staff_member set name=@name where punch_id=@punchId ";
            //trigger will be called here ......
            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@name";
            param.Value = name;
            cmd.Parameters.Add(param);

            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@punchId";
            param1.Value = punchId;
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public List<StaffMember> ReadStaffMemberDetails(Constants.Status status)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader reader;

            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "Select name,dept,date_of_joining,punch_id from staff_member where status=@status";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@status";
            param.Value = status;

            cmd.Parameters.Add(param);
            List<StaffMember> staffMemberDetails = new List<StaffMember>();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                StaffMember staffMember = new StaffMember();
                staffMember.Name = reader.GetString(0);
                staffMember.Department = reader.GetString(1);
                staffMember.DateOfJoining = new Date(reader.GetString(3));
                staffMember.PunchId = int.Parse(reader.GetString(4));
                staffMemberDetails.Add(staffMember);
            }
            con.Close();
            return staffMemberDetails;
        }

        public void UpdateDepartmentOf(StaffMember staffMember, string oldDept)
        {
            MySqlConnection con;
            MySqlCommand cmd;

            string newDept = staffMember.Department;
            con = new MySqlConnection(connectionString);
            con.Open();

            string nameString = "update staff_member set dept=@newDept where dept=@oldDept ";

            cmd = new MySqlCommand(nameString, con);
            MySqlParameter param = new MySqlParameter();
            param.ParameterName = "@newDept";
            param.Value = newDept;
            cmd.Parameters.Add(param);

            MySqlParameter param1 = new MySqlParameter();
            param1.ParameterName = "@oldDept";
            param1.Value = oldDept;
            cmd.Parameters.Add(param1);
            cmd.ExecuteNonQuery();

            con.Close();
        }

       
    }
}
