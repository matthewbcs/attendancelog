using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.AttendanceStatus;
using EmployeeAttendanceManager.Model.Enums;
using EmployeeAttendanceManager.Repository.Attendance;

namespace EmployeeAttendanceManager.Service.Attendance
{
    public class AttendanceStatusService
    {
        private readonly AttendanceStatusRepository _attendanceStatusRepository;
        public AttendanceStatusService()
        {
            _attendanceStatusRepository = new AttendanceStatusRepository();
        }
        public List<AttendanceStatusDto> GetAttendanceStatus()
        {
            return _attendanceStatusRepository.GetAllAttendanceStatus();
        }
        public AttendanceStatusDto GetAttendanceStatus(EAttendanceStatus status)
        {
            return _attendanceStatusRepository.GeAttendanceStatus((int)status);
        }
    }
}
