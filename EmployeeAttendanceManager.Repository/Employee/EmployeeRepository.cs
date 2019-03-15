using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAttendanceManager.Model.Dto.Employee;
using EmployeeAttendanceManager.Model.Messaging;

namespace EmployeeAttendanceManager.Repository.Employee
{
    public class EmployeeRepository:BaseContext
    {
        public List<EmployeeDto> GetEmployees()
        { 
            List<EmployeeDto> l = new List<EmployeeDto>();
            Context.Employees.ToList().ForEach(x => l.Add(new EmployeeDto()
            {
                Firstname = x.Firstname,
                Surname = x.Surname,
                EmployeeId = x.EmployeeId
            }));

            return l;
        }

        public EmployeeDto GetEmployee(int id)
        {
            DbContextFiles.Employee employee = Context.Employees.FirstOrDefault(x => x.EmployeeId == id);

            if (employee == null)
            {
                return null;
            }
            EmployeeDto dto = new EmployeeDto();
            dto.Surname = employee.Surname;
            dto.Firstname = employee.Firstname;
            dto.EmployeeId = employee.EmployeeId;
            return dto;


        }

        public BaseServiceMessage AddEmployee(EmployeeDto employee)
        {
            DbContextFiles.Employee employeeDbObj = new DbContextFiles.Employee();

            employeeDbObj.Firstname = employee.Firstname;
            employeeDbObj.Surname = employee.Surname;
            Context.Employees.Add(employeeDbObj);

            bool saveDbChanges = SaveDbChanges();

            if(saveDbChanges)
                return new BaseServiceMessage(){WasSuccess = true};

            return new BaseServiceMessage(){WasSuccess = false, Message = "There was an error when trying to save to the DB"}; 
        }
    }
}
