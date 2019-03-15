using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceManager.Repository.Attendance
{
    public class AttendanceLogRepository: BaseContext
    {
        public void AddAttendanceLog(DbContextFiles.EmployeeAttendance log)
        {
            Context.EmployeeAttendances.Add(log);
        }

        public void AddAttendanceLog(List<DbContextFiles.EmployeeAttendance> logs)
        {
            Context.EmployeeAttendances.AddRange(logs);
        }

        public List<DbContextFiles.EmployeeAttendance> GetLogs(int employeeId, DateTime attendanceDate)
        {
            return Context.EmployeeAttendances.Where(x => x.EmployeeId == employeeId && x.AttendanceDate == attendanceDate).ToList();
        }
        public List<DbContextFiles.EmployeeAttendance> GetLogs(int rowCount)
        {
            
            return Context.EmployeeAttendances.Include("Employee").Include("AttendanceStatu").OrderByDescending(x =>x.AttendanceDate).Take(rowCount).ToList();
        }

        public bool UpdateAttendanceLogStatus(int logId, int statusId)
        {
            DbContextFiles.EmployeeAttendance employeeAttendance = Context.EmployeeAttendances.FirstOrDefault(x => x.EmployeeAttendanceId == logId);

            if (employeeAttendance == null)
                return false;

            DbContextFiles.AttendanceStatu attendanceStatu = Context.AttendanceStatus.FirstOrDefault(x => x.AttendanceStatusId == statusId);

            if (attendanceStatu == null)
                return false;

            employeeAttendance.AttendanceStatusId = attendanceStatu.AttendanceStatusId;

            return true;
        }
    }
}
