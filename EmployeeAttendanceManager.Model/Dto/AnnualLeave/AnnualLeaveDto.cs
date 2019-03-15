using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceManager.Model.Dto.AnnualLeave
{
    public class AnnualLeaveDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AnnualLeaveDate { get; set; }
        public string AnnualLeaveDateAsString { get; set; }
        public bool IsHalfDay { get; set; }


        public string title => EmployeeName;
        public string start => AnnualLeaveDate.ToShortDateString();
        public string end => AnnualLeaveDate.ToShortDateString();
    }
    public class AnnualLeaveCalenderDto
    {

        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string textColor { get; set; }
        public string color { get; set; }
        public string editable { get; set; }
        public string backgroundColor { get; set; }
    }
}
