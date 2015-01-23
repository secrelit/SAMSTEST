using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    public class Program
    {
        static void Main(string[] args)
        {
           // Controller controller = new Controller();
           // List<NewStaffMember> nsm = controller.SaveExcelToDatabase("H:\\Nilesh sir\\14-12-2015.xls");
           //Console.WriteLine("Count of new members : {0}",nsm.Count);
             DbOperations db = new DbOperations();
            DateRange dr = new DateRange("12-12-2015","14-12-2015");
            // public List<PunchTimeDetails> ReadPunchTimeDetails(string name, DateRange dr)
            //Console.WriteLine(db.GetDateCount("Jyoti M Kadam", "IPT Dates", dr ));
//       TimeFrameDetails timeframe = new TimeFrameDetails();
             PunchTimeDetails ptd = new PunchTimeDetails();
            List<PunchTimeDetails> punchTimeDetailList = new List<PunchTimeDetails>();
            punchTimeDetailList = db.ReadPunchTimeDetails("Jyoti M Kadam", dr);
          //  ptd =  db.ReadPunchTimeDetails("Darshan S Talegaonkar",new Date("12-12-2015"));
            Console.WriteLine(punchTimeDetailList.Count);
           //  timeframe.ValidInTime.Hour = 10;
//timeframe.ValidInTime.Minute = 10;
             // timeframe.ValidInTime.Hour = 10;
             //timeframe.ValidInTime.Hour = 10;
           
       //     db.UpdateInTimeOf(timeframe);
       //      StaffMember staffMember = new StaffMember();
           //  staffMember.Populate("Darshan S Talegaonkar");
             //List<StaffMember> staffNameofStatus = new List<StaffMember>();
             //staffNameofStatus = staffMember.ReadStaffMembers(Constants.Status.Working);
             //Console.WriteLine("Count of new members : {0}", staffNameofStatus.Count);
            // staffMember = staffMember.ReadStaffMember("Prashant P Solankar");
           //  Console.WriteLine(staffMember.Department+ staffMember.DateOfJoining.Day+ staffMember.DateOfJoining.Month+ staffMember.DateOfJoining.Year+staffMember.Status.ToString());
                    
            Console.ReadLine();
        }
    }
}
