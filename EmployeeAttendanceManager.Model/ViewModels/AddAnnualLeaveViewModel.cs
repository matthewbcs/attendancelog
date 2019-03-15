using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.AnnualLeave;
using EmployeeAttendanceManager.Model.Dto.Employee;

namespace EmployeeAttendanceManager.Model.ViewModels
{
    public class AddAnnualLeaveViewModel
    {
        public List<EmployeeDto> Employees { get; set; }
        public List<AnnualLeaveDto> AnnualLeaveData { get; set; }
    }
}
