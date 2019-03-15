using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.AnnualLeave;
using EmployeeAttendanceManager.Model.Dto.Employee;
using EmployeeAttendanceManager.Model.Messaging;
using EmployeeAttendanceManager.Model.ViewModels;
using EmployeeAttendanceManager.Repository;
using EmployeeAttendanceManager.Repository.AnnualLeave;
using EmployeeAttendanceManager.Service.Employee;

namespace EmployeeAttendanceManager.Service.AnnualLeave
{
    public class AnnualLeaveService
    {
        private AnnualLeaveRepository _annualLeaveRepository;
        private EmployeeService _employeeService;

        public AnnualLeaveService()
        {
            _annualLeaveRepository = new AnnualLeaveRepository();
            _employeeService = new EmployeeService();
        }

        public AnnualLeaveViewModel PopulateAnnualLeaveView()
        {
            DateTime fromDate = DateTime.Parse("31/12/2018");
            AnnualLeaveViewModel m = new AnnualLeaveViewModel();
            List<AnnualLeaveItem> l = new List<AnnualLeaveItem>(); 
            List<EmployeeDto> employees = _employeeService.GetEmployees();

            foreach (var e in employees)
            {
                List<AnnualLeaveDto> annualLeave = _annualLeaveRepository.GetAnnualLeave(e.EmployeeId,fromDate);
                l.Add(new AnnualLeaveItem()
                {
                    EmployeeName = e.Firstname  + " " + e.Surname,
                    AnnualLeaveData = annualLeave

                });

            }

            m.EmployeeAnnualLeaveListing = l;
            return m;
        }

        public AnnualLeaveCalenderViewModel PopulateAnnualLeaveCalenderView()
        {
            DateTime fromDate = DateTime.Parse("31/12/2018");
            AnnualLeaveCalenderViewModel m = new AnnualLeaveCalenderViewModel();
            List<AnnualLeaveItem> l = new List<AnnualLeaveItem>(); 
            List<EmployeeDto> employees = _employeeService.GetEmployees();

            foreach (var e in employees)
            {
                List<AnnualLeaveDto> annualLeave = _annualLeaveRepository.GetAnnualLeave(e.EmployeeId,fromDate);
                if (annualLeave.Count > 0)
                {
                    l.Add(new AnnualLeaveItem()
                    {
                        EmployeeName = e.Firstname  + " " + e.Surname,
                        AnnualLeaveData = annualLeave

                    });
                }
                

            }

            // process for calender
            int year = DateTime.Now.Year;
            DateTime firstDay = new DateTime(year , 1, 1);
            DateTime lastDay = new DateTime(year , 12, 31);

            List<AnnualLeaveCalenderDto> alDto= new List<AnnualLeaveCalenderDto>();
            foreach (AnnualLeaveDto annualLeaveDto in _annualLeaveRepository.GetAnnualLeave(firstDay, lastDay))
            {
                alDto.Add(new AnnualLeaveCalenderDto()
                {
                    title = annualLeaveDto.EmployeeName + " is on AL",
                    start = annualLeaveDto.AnnualLeaveDate.ToString("O"),
                    end = annualLeaveDto.AnnualLeaveDate.ToString("O"),
                    editable = "false",
                    backgroundColor =  "yellow",
                    textColor = "black"
              
                });
            }

            m.EmployeeAnnualLeaveForCalender = alDto;
            m.EmployeeAnnualLeaveListing = l;
            return m;
        }

        public BaseServiceMessage AddNewAnnualLeave(int employeeId, DateTime fromDate, DateTime toDate)
        {
            EmployeeDto employeeDto = _employeeService.GetEmployee(employeeId);
            if(employeeDto == null)
                return new BaseServiceMessage(){WasSuccess = false, Message = "That Employee Id does not exist"};

            List<DbContextFiles.EmployeeAnnualLeave> employeeAnnualLeaves = _annualLeaveRepository.GetAnnualLeave(employeeId, fromDate, toDate);

            // check annual leave isnt already booked 
            if(employeeAnnualLeaves.Count > 0)
                return new BaseServiceMessage(){WasSuccess = false, Message = "There is already annual leave booked within that date range"}; 

            // process date range and create Db object
            List<DbContextFiles.EmployeeAnnualLeave> annualLeaveDates = new List<DbContextFiles.EmployeeAnnualLeave>();
            foreach (DateTime day in EachDay(fromDate, toDate))
            {
                if (day.DayOfWeek == DayOfWeek.Sunday && day.DayOfWeek == DayOfWeek.Saturday) continue;

                DbContextFiles.EmployeeAnnualLeave annualLeave = new DbContextFiles.EmployeeAnnualLeave();
                annualLeave.EmployeeId = employeeDto.EmployeeId;
                annualLeave.AddedOnUtc = DateTime.UtcNow;
                annualLeave.AnnualLeaveDateOnUtc = day;
                annualLeave.IsHalfDay = false;
                annualLeaveDates.Add(annualLeave);
            }
            // update db
            return _annualLeaveRepository.AddAnnualLeave(annualLeaveDates);

        }

        public List<AnnualLeaveDto> CheckAvailability(DateTime fromDate, DateTime toDate)
        {
            return _annualLeaveRepository.GetAnnualLeave(fromDate, toDate);
        }

        public List<DbContextFiles.EmployeeAnnualLeave> GetAnnualLeaveBooked(int employeeId, DateTime fromDate,
            DateTime toDate)
        {
            return _annualLeaveRepository.GetAnnualLeave(employeeId, fromDate, toDate);
        }

        #region helpers

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for(var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        #endregion
    }
}
