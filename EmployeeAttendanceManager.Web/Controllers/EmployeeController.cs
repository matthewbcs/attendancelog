using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeAttendanceManager.Model.Messaging;
using EmployeeAttendanceManager.Model.ViewModels;
using EmployeeAttendanceManager.Service.Employee;

namespace EmployeeAttendanceManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        [HttpGet] // GET: Employee}
        public ActionResult AddEmployee()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();
            model.Employees = _employeeService.GetEmployees();
            return View(model);
        }
        [HttpPost] // GET: Employee}
        public ActionResult AddNewEmployee(string firstName, string surName)
        {
            BaseServiceMessage response = _employeeService.AddNewEmployee(firstName, surName);
            return Json(response);
        }
    }
}