using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
    class StaffMemberDetails
    {
        string name, dept, status;
        Date d_o_j;
        int punch_id;
        List<string> n = new List<string>();
        public string readFacultyStatus(string n)
        {
            //status= ReadStatus(n);//method of Dal
            return status;
        }
        public List<string> getStaffNamesWithStatus(string status)
        {
            n.Add("manu");
            n.Add("gsdfg");
            n.Add("gsjh");
            return n;
        }
    }
}
