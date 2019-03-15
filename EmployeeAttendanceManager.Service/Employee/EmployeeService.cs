using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.Attendance;
using EmployeeAttendanceManager.Model.Dto.AttendanceStatus;
using EmployeeAttendanceManager.Model.Dto.Employee;
using EmployeeAttendanceManager.Model.Enums;
using EmployeeAttendanceManager.Model.Messaging;
using EmployeeAttendanceManager.Model.ViewModels;
using EmployeeAttendanceManager.Repository;
using EmployeeAttendanceManager.Repository.Employee;
using EmployeeAttendanceManager.Service.AnnualLeave;
using EmployeeAttendanceManager.Service.Attendance;

namespace EmployeeAttendanceManager.Service.Employee
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;
        //private AnnualLeaveService _annualLeaveService;
        private AttendanceStatusService _attendanceStatusService;

        public EmployeeService()
        {
            //_annualLeaveService = new AnnualLeaveService();
            _employeeRepository = new EmployeeRepository();
            _attendanceStatusService = new AttendanceStatusService();
        }

        public List<EmployeeDto> GetEmployees() => _employeeRepository.GetEmployees();

        public BaseServiceMessage AddNewEmployee(string firstName, string surname)
        {
            EmployeeDto employee = new EmployeeDto();
            employee.Firstname = firstName;
            employee.Surname = surname;

            return _employeeRepository.AddEmployee(employee);
        }

        public EmployeeDto GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }

        public AddAttendanceLogViewModel PopulateViewModel()
        {
            AddAttendanceLogViewModel model = new AddAttendanceLogViewModel();
            AnnualLeaveService _annualLeaveService = new AnnualLeaveService();
            List<EmployeeDto> employeeDtos = _employeeRepository.GetEmployees();
            

            List<AttendanceLogItem> attendanceLogItems = new List<AttendanceLogItem>();
            foreach (var e in employeeDtos)
            {
                // check if employee has annual leave booked today 
                DateTime startDate = DateTime.UtcNow;
                DateTime endDate = DateTime.UtcNow;
                List<DbContextFiles.EmployeeAnnualLeave> employeeAnnualLeaves = _annualLeaveService.GetAnnualLeaveBooked(e.EmployeeId, startDate, endDate);

                int attendenceStatusIdToUse;
                AttendanceStatusDto dto = new AttendanceStatusDto();
                if (employeeAnnualLeaves.Count == 0)
                {
                    // no annual leave booked can default type to present
                     dto = _attendanceStatusService.GetAttendanceStatus(EAttendanceStatus.Present);
                    attendenceStatusIdToUse = dto?.AttendanceStatusId ?? 0;
                }
                else
                {
                    DateTime today = DateTime.UtcNow.Date;
                    
                    DbContextFiles.EmployeeAnnualLeave employeeAnnualLeave = employeeAnnualLeaves.FirstOrDefault(x => DbFunctions.TruncateTime(x.AnnualLeaveDateOnUtc) == DbFunctions.TruncateTime(today));

                    if(employeeAnnualLeave == null)
                        continue;

                    if(employeeAnnualLeave.AnnualLeavePm == null)
                        continue;

                    if(employeeAnnualLeave.AnnualLeaveAm == null)
                        continue;

                    // todo need to write this really crap code i cant even stand to look at it but go not time to write this 
                    bool? f = false;
                    bool isAm = false;
                    bool isPm = false;

                    if (employeeAnnualLeave.AnnualLeavePm == true)
                    {
                        isPm = true;
                        
                    }
                    if (employeeAnnualLeave.AnnualLeaveAm == true)
                    {
                        isAm = true;
                     
                    }

                    if (isPm == true && isAm == true)
                    {
                        dto = _attendanceStatusService.GetAttendanceStatus(EAttendanceStatus.AnnualLeave);// must be a full days AL
                    }
                    else if(isPm == true)
                    {
                        dto = _attendanceStatusService.GetAttendanceStatus(EAttendanceStatus.AnnualLeavePm);
                    }
                    else
                    {
                        dto = _attendanceStatusService.GetAttendanceStatus(EAttendanceStatus.AnnualLeaveAm);
                    }

                    
                    attendenceStatusIdToUse = dto?.AttendanceStatusId ?? 0;
                }


                AttendanceLogItem n = new AttendanceLogItem()
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.Firstname + " " + e.Surname,
                    DateAttended = DateTime.UtcNow.Date,
                    SelectedAttendanceStatusId = attendenceStatusIdToUse,
                    SelectedStatus = dto 
              

                };
                attendanceLogItems.Add(n);
            }

            model.AttendanceLog = attendanceLogItems;

            return model;
        }
    }
}
