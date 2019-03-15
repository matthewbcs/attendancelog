using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.AttendanceStatus;
using EmployeeAttendanceManager.Model.Enums;

namespace EmployeeAttendanceManager.Model.Dto.Attendance
{
    public class AttendanceLogItem
    {
        public int AttendanceLogItemId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime DateAttended { get; set; }
        public bool isToday
        {
            get
            {
                if (DateAttended.Date == DateTime.Now.Date) return true;
                return false;
            }
        }
        public string DateAttendedAsString { get; set; }
        public EAttendanceStatus AttendanceStatus { get; set; }
        public int AttendanceStatusId  { get; set; }
        public string AttendanceStatusLabel  { get; set; }

        public AttendanceStatusDto SelectedStatus { get; set; }
        public int SelectedAttendanceStatusId { get; set; }
        
    }
}
