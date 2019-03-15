using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.AnnualLeave;

namespace EmployeeAttendanceManager.Model.ViewModels
{
    public class AnnualLeaveCalenderViewModel
    {
        public List<AnnualLeaveItem> EmployeeAnnualLeaveListing { get; set; }
        public List<AnnualLeaveCalenderDto> EmployeeAnnualLeaveForCalender { get; set; }
    }
}
