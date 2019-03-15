using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.Attendance;
using EmployeeAttendanceManager.Model.Dto.AttendanceStatus;

namespace EmployeeAttendanceManager.Model.ViewModels
{
    public class AddAttendanceLogViewModel
    {
        public List<AttendanceLogItem> AttendanceLog { get; set; }
        public List<AttendanceStatusDto> Statuses { get; set; }
         
    }
}
