using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.AnnualLeave;

namespace EmployeeAttendanceManager.Model.ViewModels
{
    public class AnnualLeaveViewModel
    {
        public List<AnnualLeaveItem> EmployeeAnnualLeaveListing { get; set; }
    }

    public class AnnualLeaveItem
    {
        public string EmployeeName { get; set; }
        public List<AnnualLeaveDto> AnnualLeaveData { get; set; }
    }
}
