using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace finalams
{
   public class NewStaffMember
    {
        private string name;
        private int punch_id;
        private Time inTime;
        private Time outTime;
        private Date newdate;

        public String Name { get { return this.name; } set { this.name = value; } }

        public int punchId { get { return this.punch_id; } set { this.punch_id = value; } }

        public Time InTime { get { return this.inTime; } set { this.inTime = value; } }

        public Time OutTime { get { return this.outTime; } set { this.outTime = value; } }

        public Date PunchDate { get { return this.newdate; } set { this.newdate = value; } }

   
    }
}
