using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    public class StaffMember
    {
         string name, dept;
        Date d_o_j;
        int punch_id;
        Constants.Status status;
          //member variables representing fields in the sm table 
        bool isNameChanged, isDateOfJoiningChanged, isDepartmentChanged, isStatusChanged;

        DbOperations dbo = new DbOperations();
       // public string readFacultyStatus(string n)
       // {
       //     //status= ReadStatus(n);//method of Dal
       //     return status;
       // }
        public string Name
        { get { return name; }
            set {
                this.name = value;
                isNameChanged = true;
                }
        }

        public string Department
        { get { return dept; }
            set {
                this.dept = value;
                isDepartmentChanged = true;
                }
        }

        public Date DateOfJoining
        { get { return d_o_j; }
            set {
                this.d_o_j = value;
                isDateOfJoiningChanged = true;
                }
        }

        public int   PunchId
        { get { return punch_id; }
            set { this.punch_id = value; }
        }

        public Constants.Status Status
        { get { return status; }
            set {
                this.status = value;
                isStatusChanged = true;
                }
        }
        public List<string> GetStaffNamesWithStatus(Constants.Status status)
        {
            List<string> n = new List<string>();

            n = (new DbOperations()).ReadStaffNameWithStatus(status.ToString());
          
            return n;
        }
        public StaffMember ReadStaffMember(string name)// this method will call dal method to fetch following data
        { 
            //StaffMember member = (new DbOperations()).ReadStaffMemberDetail(name);
            return (new DbOperations()).ReadStaffMemberDetail(name);
        }
        public List<StaffMember> ReadStaffMembers(Constants.Status status)// this method will call dal method to fetch following data
        {
            //List<StaffMember> smlist = (new DbOperations()).ReadStaffMemberDetails(status);
            return (new DbOperations()).ReadStaffMemberDetails(status.ToString());
        }

        public void UpdateStaffMemberDetails()
        {

            //if (isNameChanged)
            //{
            //    dbo.upUpdateName(this);
            //}
            if (isDepartmentChanged)
            {
                dbo.UpdateDepartmentOf(this);
            }
            if (isStatusChanged)
            {
                dbo.UpdateStatusOf(this);
            }
            //throw new NotImplementedException();
        }

        public void Populate(string name)
        {
            DbOperations dbo = new DbOperations();
           // dbo.ReadStaffMemberDetails(status);
            StaffMember member= dbo.ReadStaffMemberDetail(name);
            this.dept = member.dept ;
            this.d_o_j = member.d_o_j;
            this.name = name;
            this.status = member.status;
            this.punch_id = member.punch_id;
           Console.WriteLine("The values staffmember in staffmember class::name= "+this.Name+"  department =" + this.Department + " date of joing =" + this.DateOfJoining.toString() + " status = " + this.Status + " punchid =" + this.PunchId);
           
        }
    }
}
