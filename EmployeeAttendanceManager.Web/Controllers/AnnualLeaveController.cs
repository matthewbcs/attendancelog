using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeAttendanceManager.Model.Dto.AnnualLeave;
using EmployeeAttendanceManager.Model.Messaging;
using EmployeeAttendanceManager.Model.ViewModels;
using EmployeeAttendanceManager.Service.AnnualLeave;
using EmployeeAttendanceManager.Service.Employee;

namespace EmployeeAttendanceManager.Web.Controllers
{
    public class AnnualLeaveController : Controller
    {
        private EmployeeService _employeeService;
        private AnnualLeaveService _annualLeaveService;
        public AnnualLeaveController()
        {
            _employeeService = new EmployeeService();
            _annualLeaveService = new AnnualLeaveService();
        }
        [HttpGet]// GET: AnnualLeave
        public ActionResult Calender()
        {
            AnnualLeaveCalenderViewModel model = _annualLeaveService.PopulateAnnualLeaveCalenderView();
 
            return View(model);
        }
        [HttpPost]// GET: AnnualLeave
        public ActionResult GetCalenderEvents()
        {
            AnnualLeaveCalenderViewModel model = _annualLeaveService.PopulateAnnualLeaveCalenderView();
 
            return Json(model.EmployeeAnnualLeaveForCalender);
        }

        [HttpGet]// GET: AnnualLeave
        public ActionResult AnnualLeave()
        {
            AnnualLeaveViewModel model = _annualLeaveService.PopulateAnnualLeaveView();
            return View(model);
        }

        [HttpGet]// GET: AnnualLeave
        public ActionResult AddAnnualLeave()
        {
            AddAnnualLeaveViewModel model = new AddAnnualLeaveViewModel();
            model.Employees = _employeeService.GetEmployees();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddAnnualLeave(int employeeId, DateTime fromDate, DateTime toDate)
        {
            BaseServiceMessage message = _annualLeaveService.AddNewAnnualLeave(employeeId, fromDate, toDate);
            return Json(message);
        }

        [HttpPost]
        public ActionResult CheckAvailability(DateTime fromDate, DateTime toDate)
        {
            List<AnnualLeaveDto> annualLeaveDtos = _annualLeaveService.CheckAvailability(fromDate, toDate);
            return Json(annualLeaveDtos);
        }
    }
}