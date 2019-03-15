using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.AnnualLeave;
using EmployeeAttendanceManager.Model.Messaging;

namespace EmployeeAttendanceManager.Repository.AnnualLeave
{
    public class AnnualLeaveRepository: BaseContext
    {
        public BaseServiceMessage AddAnnualLeave(DbContextFiles.EmployeeAnnualLeave annualLeave)
        {
            Context.EmployeeAnnualLeaves.Add(annualLeave);

            bool saveDbChanges = SaveDbChanges();

            if(saveDbChanges)
                return new BaseServiceMessage(){WasSuccess = true};

            return new BaseServiceMessage(){WasSuccess = false, Message = "There was an error when trying to save to the DB"}; 
        }

        public List<DbContextFiles.EmployeeAnnualLeave> GetAnnualLeave(int employeeId, DateTime fromDate,
            DateTime toDate)
        {
            return Context.EmployeeAnnualLeaves
                .Where(x => x.AnnualLeaveDateOnUtc <= toDate && x.AnnualLeaveDateOnUtc >= fromDate).ToList();
        }

        public List<AnnualLeaveDto> GetAnnualLeave(int employeeId)
        {
            List<AnnualLeaveDto> a = new List<AnnualLeaveDto>();
            Context.EmployeeAnnualLeaves.Where(x => x.EmployeeId == employeeId).ToList().ForEach(x =>a.Add(new AnnualLeaveDto()
            {
                AnnualLeaveDate = x.AnnualLeaveDateOnUtc,
                EmployeeId = x.EmployeeId,
                IsHalfDay = x.IsHalfDay
            }));

            return a;
        }
        public List<AnnualLeaveDto> GetAnnualLeave(int employeeId, DateTime fromDate)
        {
            List<AnnualLeaveDto> a = new List<AnnualLeaveDto>();
            Context.EmployeeAnnualLeaves.Where(x => x.EmployeeId == employeeId && x.AnnualLeaveDateOnUtc > fromDate).ToList().ForEach(x =>a.Add(new AnnualLeaveDto()
            {
                AnnualLeaveDate = x.AnnualLeaveDateOnUtc,
                EmployeeId = x.EmployeeId,
                IsHalfDay = x.IsHalfDay
            }));

            return a;
        }

        public List<AnnualLeaveDto> GetAnnualLeave( DateTime fromDate, DateTime toDate)
        {
            List<AnnualLeaveDto> a = new List<AnnualLeaveDto>();
            Context.EmployeeAnnualLeaves.Include("Employee").Where(x => x.AnnualLeaveDateOnUtc <= toDate && x.AnnualLeaveDateOnUtc >= fromDate).ToList().ForEach(x =>a.Add(new AnnualLeaveDto()
            {
                AnnualLeaveDate = x.AnnualLeaveDateOnUtc,
                AnnualLeaveDateAsString = x.AnnualLeaveDateOnUtc.ToShortDateString(),
                EmployeeName = x.Employee.Firstname + " " + x.Employee.Surname,
                EmployeeId = x.EmployeeId,
                IsHalfDay = x.IsHalfDay
            }));

            return a;
        }

        

        public BaseServiceMessage AddAnnualLeave(List<DbContextFiles.EmployeeAnnualLeave> annualLeave)
        {
            Context.EmployeeAnnualLeaves.AddRange(annualLeave);

            bool saveDbChanges = SaveDbChanges();

            if(saveDbChanges)
                return new BaseServiceMessage(){WasSuccess = true,Message = "Successfully booked Annual Leave"};

            return new BaseServiceMessage(){WasSuccess = false, Message = "There was an error when trying to save to the DB"}; 
        }
    }
}
