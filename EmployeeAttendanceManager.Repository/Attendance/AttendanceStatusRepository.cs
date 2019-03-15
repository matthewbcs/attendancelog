using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.AttendanceStatus;
using EmployeeAttendanceManager.Model.Enums;
using EmployeeAttendanceManager.Model.Messaging;

namespace EmployeeAttendanceManager.Repository.Attendance
{
    public class AttendanceStatusRepository: BaseContext
    {
        public List<AttendanceStatusDto> GetAllAttendanceStatus()
        {
            List<AttendanceStatusDto> r = new List<AttendanceStatusDto>();
            Context.AttendanceStatus.ToList().ForEach(x => r.Add(new AttendanceStatusDto(){AttendanceStatusId = x.AttendanceStatusId, AttendanceStatusLabel = x.Status}));

            return r;
        }

        public AttendanceStatusDto GeAttendanceStatus(int statusId)
        {
            
            List<AttendanceStatusDto> r = new List<AttendanceStatusDto>();
            DbContextFiles.AttendanceStatu attendanceStatu = Context.AttendanceStatus.FirstOrDefault(x => x.AttendanceStatusId == statusId);
            if (attendanceStatu == null)
                return null;

            AttendanceStatusDto t = new AttendanceStatusDto()
            {
                AttendanceStatusId = attendanceStatu.AttendanceStatusId, AttendanceStatusLabel = attendanceStatu.Status
            };
            return t;
        }

        
    }
}
