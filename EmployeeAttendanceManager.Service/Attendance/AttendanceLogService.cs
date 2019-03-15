using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.Attendance;
using EmployeeAttendanceManager.Model.Dto.AttendanceStatus;
using EmployeeAttendanceManager.Model.Messaging;
using EmployeeAttendanceManager.Repository;
using EmployeeAttendanceManager.Repository.Attendance;

namespace EmployeeAttendanceManager.Service.Attendance
{
    public class AttendanceLogService
    {
       
        public AttendanceLogService()
        {
            
        }

        public List<AttendanceLogItem> GetAttendanceHistory()
        {
            List<AttendanceLogItem> logs = new List<AttendanceLogItem>();
            AttendanceLogRepository _attendanceLogRepository = new AttendanceLogRepository();
            List<DbContextFiles.EmployeeAttendance> employeeAttendances = _attendanceLogRepository.GetLogs(100);


            employeeAttendances.ForEach(x => logs.Add(new AttendanceLogItem()
            {
                AttendanceLogItemId = x.EmployeeAttendanceId,
                EmployeeName = x.Employee.Firstname + " " + x.Employee.Surname,
                DateAttended = x.AttendanceDate,
                AttendanceStatusLabel = x.AttendanceStatu.Status,
                SelectedStatus = new AttendanceStatusDto(){AttendanceStatusId = x.AttendanceStatu.AttendanceStatusId,AttendanceStatusLabel = x.AttendanceStatu.Status}
            }));
            return logs;
        }

        public BaseServiceMessage AddAttendanceLog(List<AttendanceLogItem> logs)
        {
         AttendanceLogRepository _attendanceLogRepository = new AttendanceLogRepository();
            List<DbContextFiles.EmployeeAttendance> attendanceLogs = new List<DbContextFiles.EmployeeAttendance>();
            foreach (var l in logs)
            {
                DbContextFiles.EmployeeAttendance employeeAttendance = new DbContextFiles.EmployeeAttendance();

                // get logs for this employee 
                List<DbContextFiles.EmployeeAttendance> employeeAttendances = _attendanceLogRepository.GetLogs(l.EmployeeId, l.DateAttended);

                if (employeeAttendances != null)
                {
                    if(employeeAttendances.Count > 0)
                        continue;
                }

               
                // if here then no existing logs and add a log
                employeeAttendance.AttendanceDate = l.DateAttended;
                employeeAttendance.EmployeeId = l.EmployeeId;
                employeeAttendance.DateAddedOnUtc = DateTime.UtcNow;
                employeeAttendance.IsDeleted = false;
                employeeAttendance.AttendanceStatusId = l.SelectedStatus.AttendanceStatusId;

                attendanceLogs.Add(employeeAttendance);
            }
            // add logs and save
            if (attendanceLogs.Count > 0)
            {
                _attendanceLogRepository.AddAttendanceLog(attendanceLogs);
                bool DbResponse = _attendanceLogRepository.SaveDbChanges();

                if(DbResponse)
                    return new BaseServiceMessage(){WasSuccess = DbResponse,Message = "Successfully Save Attendance Entries"};

                return new BaseServiceMessage(){WasSuccess = DbResponse,Message = "There was an error when trying to save attendance entries to the Db "};
            }

            return new BaseServiceMessage(){WasSuccess = false,Message = "Looks like there was already entries save in the Db for those dates"};

           
        }

        public BaseServiceMessage UpdateAttendanceLog(int logId, int attendanceStatusId)
        {

            AttendanceLogRepository _attendanceLogRepository = new AttendanceLogRepository();
            bool response = _attendanceLogRepository.UpdateAttendanceLogStatus(logId, attendanceStatusId);

            if (response)
            {
                bool didsave = _attendanceLogRepository.SaveDbChanges();

                if (didsave)
                {
                    return new BaseServiceMessage(){Message = "Updated Successfully", WasSuccess = true};
                }
                
            }

            return new BaseServiceMessage(){Message = "There was a problem trying to update the log, contact dev@", WasSuccess = false};
        }
    }
}
