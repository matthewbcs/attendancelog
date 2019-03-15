using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeAttendanceManager.Model.Dto.Attendance;
using EmployeeAttendanceManager.Model.Messaging;
using EmployeeAttendanceManager.Model.ViewModels;
using EmployeeAttendanceManager.Service.Attendance;
using EmployeeAttendanceManager.Service.Employee;

namespace EmployeeAttendanceManager.Web.Controllers
{
    public class AttendanceController : Controller
    {
        private AttendanceStatusService _attendanceStatusService;
        private AttendanceLogService _attendanceLogService;
        private EmployeeService _employeeService;
        public AttendanceController()
        {
            _attendanceStatusService = new AttendanceStatusService();
            _employeeService = new EmployeeService();
            _attendanceLogService = new AttendanceLogService();
        }
        [HttpGet]// GET: Attendance
        public ActionResult CreateAttendanceLog()
        {
            AddAttendanceLogViewModel model = _employeeService.PopulateViewModel();
            model.Statuses = _attendanceStatusService.GetAttendanceStatus();
            
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAttendanceLog(List<AttendanceLogItem> attendanceLogs)
        {
            BaseServiceMessage message = _attendanceLogService.AddAttendanceLog(attendanceLogs);

            return Json(message);
        }

        [HttpPost]
        public ActionResult UpdateAttendanceStatus(int logId, int statusId)
        {
            BaseServiceMessage message = _attendanceLogService.UpdateAttendanceLog(logId, statusId);
            return Json(message);
        }

        [HttpGet]// GET: Attendance
        public ActionResult AttendanceHistory()
        {
            AttendanceHistoryViewModel model = new AttendanceHistoryViewModel();
            model.Logs = _attendanceLogService.GetAttendanceHistory();
            model.Statuses = _attendanceStatusService.GetAttendanceStatus();
            
            return View(model);
        }
    }
}